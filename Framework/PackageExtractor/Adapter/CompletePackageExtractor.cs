using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Engine;
using TCosReborn.Framework.Attributes;
using TCosReborn.Framework.Common;
using TCosReborn.Framework.PackageExtractor;
using TCosReborn.Framework.PackageExtractor.Adapter;

// ReSharper disable once CheckNamespace
namespace PackageExtractor.Adapter
{
    public class CompletePackageExtractor : ExtractorAdapter
    {
        public override string Name
        {
            get { return "Complete Package Extractor"; }
        }

        public override string Description
        {
            get { return "Extracts complete packages"; }
        }

        SBResourceListing resRef;
        SBLocalizedStrings stringsRef;
        SBResourcePackage activePackage;

        SBPackageResource ExtractObject(SBObject sbo, SBResourceListing res, ResourceStash saveStash)
        {
            var exName = sbo.Name.Replace("\0", string.Empty);
            var exPkg = sbo.Package.Replace("\0", string.Empty);
            SBPackageResource existingInstance;
            if (saveStash.TryGetObject(exName, exPkg, out existingInstance))
            {
                return existingInstance;
            }
            var className = GetClassName(sbo);
            var type = GetTypeFromName(className);
            var instance = Activator.CreateInstance(type) as SBPackageResource;
            instance.IsExternalReference = false;
            instance.ReferenceObjectName = exName;
            instance.ReferencePackageName = exPkg;
            instance.ResourceID = FindResourceID(sbo, "PackageName", res); //TODO fix PackageName=real
            var yetStillExistingInstance = saveStash.Add(instance);
            if (yetStillExistingInstance != null)
            {
                if (yetStillExistingInstance.GetType() == instance.GetType())
                {
                    Log("First missed yet still existing instance used.(this should not happen)?");
                    return yetStillExistingInstance;
                }
            }

            ExtractProps(instance, sbo, saveStash, instance.ReferenceObjectName);
            return instance;
        }

        void ExtractProps(object instance, SBObject sbo, ResourceStash saveStash, string parentHint = "")
        {
            var fieldInfos = new List<FieldInfo>(GetTypeFromName(GetClassName(sbo)).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy));
            foreach (var prop in sbo.IterateProperties())
            {
                ExtractPropertyIntoObject(instance, prop, fieldInfos, saveStash, parentHint);
            }
        }

        void ExtractProps(object instance, SBProperty sbp, ResourceStash saveStash, string parentHint = "")
        {
            var fieldInfos = new List<FieldInfo>(instance.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy));
            foreach (var prop in sbp.IterateInnerProperties())
            {
                ExtractPropertyIntoObject(instance, prop, fieldInfos, saveStash, parentHint);
            }
        }

        void ExtractPropertyIntoObject(object instance, SBProperty prop, List<FieldInfo> fieldInfos, ResourceStash saveStash, string parentHint)
        {
            var propName = prop.Name.Replace("\0", string.Empty);
            foreach (var fieldInfo in fieldInfos)
            {
                if (fieldInfo.Name.Equals(propName, StringComparison.OrdinalIgnoreCase))
                {
                    if (fieldInfo.GetCustomAttributes(typeof(IgnoreFieldExtractionAttribute), true).Length > 0)
                    {
                        break;
                    }
                    if (prop.Value.Equals("null", StringComparison.OrdinalIgnoreCase) & prop.Array.Count == 0)
                    {
                        break;
                    }
                    var arraySize = 0;
                    if (fieldInfo.FieldType.IsArray)
                    {
                        var attributes = fieldInfo.GetCustomAttributes(typeof(ArraySizeForExtractionAttribute), true);
                        if (attributes.Length > 0)
                        {
                            arraySize = ((ArraySizeForExtractionAttribute)attributes[0]).Size;
                        }
                        else
                        {
                            Log(string.Format("Array '{0}' must have a SizeAttribute!", fieldInfo.Name));
                            break;
                        }
                    }
                    var result = ExtractPropertyValue(prop, fieldInfo.FieldType, saveStash, arraySize);
                    if (result != null)
                    {
                        try
                        {
                            fieldInfo.SetValue(instance, result);
                        }
                        catch (Exception)
                        {
                            if (parentHint.Length > 0)
                            {
                                Log("Object: " + parentHint);
                            }
                            throw;
                        }
                    }
                    break;
                }
            }
        }

        object ExtractPropertyValue(SBProperty prop, Type type, ResourceStash saveStash, int optionalArraySize = 0)
        {
            var val = prop.Value.Replace("\0", string.Empty);
            if (type.IsArray)
            {
                if (optionalArraySize < prop.Array.Count)
                {
                    optionalArraySize = prop.Array.Count;
                    Log(string.Format("ArraySize specified for {0} is too small, resizing!", prop.Name));
                }
                var elementType = type.GetElementType();
                var array = Array.CreateInstance(elementType, optionalArraySize);
                int pos = 0;
                foreach (var listProp in prop.IterateInnerProperties())
                {
                    var content = ExtractPropertyValue(listProp, elementType, saveStash);
                    array.SetValue(content, pos);
                    pos++;
                }
                return array;
            }
            if (type.IsEnum)
            {
                try
                {
                    var enumVal = Enum.Parse(type, prop.Value.Replace("\0", string.Empty));
                    return enumVal;
                }
                catch (Exception)
                {
                    Log("Enum could not be converted: " + prop.Name);
                }
                return 0;
            }
            if (type == typeof(SerializableTypeProxy))
            {
                return new SerializableTypeProxy(val);
            }
            if (type == typeof(LocalizedString))
            {
                int converted;
                if (int.TryParse(val, out converted))
                {
                    return new LocalizedString(converted);
                }
                Log(string.Format("Error converting LocalizedString for '{0}'", prop.Name));
                return null;
            }
            if (type.IsValueType)
            {
                object converted;
                var errMsg = "";
                if (!CustomConvertType(type, val, out converted))
                {
                    try
                    {
                        converted = Convert.ChangeType(val, Type.GetTypeCode(type));
                    }
                    catch (Exception e)
                    {
                        errMsg = e.Message;
                    }
                }
                if (converted == null)
                {
                    Log(string.Format("Error converting value for '{0}' ({1})", prop.Name, errMsg));
                    return null;
                }
                return converted;
            }
            if (type.IsClass)
            {
                if (type == typeof(string))
                {
                    return val;
                }
                if ((val.Equals("null", StringComparison.OrdinalIgnoreCase) | val.Equals("", StringComparison.Ordinal)) & prop.Array.Count == 0)
                {
                    return null; //valid null?
                }
                var internalRef = FindInternalReference(prop.Value);
                if (internalRef != null)
                {
                    var extractedRef = ExtractObject(internalRef, resRef, saveStash);
                    if (extractedRef == null)
                    {
                        Log("Error extracting internal reference: " + type.Name);
                        return null;
                    }
                    return extractedRef;
                }
                var path = "";
                if (IsExternalReference(val, out path))
                {
                    var exName = ExtractObjectName(val);
                    var exPkg = ExtractPackageName(val);
                    var t = GetTypeFromName(type.Name); //to enable replacements
                    var sbp = Activator.CreateInstance(t) as SBPackageResource;
                    if (sbp == null)
                    {
                        Log("Error creating ExternalReference type for: " + prop.Name);
                        return null;
                    }
                    sbp.IsExternalReference = true;
                    sbp.ReferenceObjectName = exName;
                    sbp.ReferencePackageName = exPkg;
                    sbp.ResourceID = resRef.GetResourceID(val);
                    if (saveStash.Add(sbp) != null)
                    {
                        Log("adding external reference returned existing!");
                    }
                    return sbp;
                }
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var elementType = type.GetGenericArguments()[0];
                    if (elementType.IsClass && elementType.Assembly == Assembly.GetAssembly(typeof(LocalizedString))) //only replace user types
                    {
                        elementType = GetTypeFromName(elementType.Name); //to enable replacements
                    }
                    var newList = Activator.CreateInstance(type) as IList;
                    if (newList == null)
                    {
                        Log(string.Format("Error creating list<{0}>", elementType.Name));
                        return null;
                    }
                    foreach (var listProp in prop.IterateInnerProperties())
                    {
                        var content = ExtractPropertyValue(listProp, elementType, saveStash);
                        newList.Add(content);
                    }
                    return newList;
                }
                var fieldContent = CreateInstanceFromType(type, saveStash);
                if (fieldContent != null)
                {
                    ExtractProps(fieldContent, prop, saveStash);
                    return fieldContent;
                }
            }
            return null;
        }

    }
}
