using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Engine;
using TCosReborn.Framework.Attributes;
using TCosReborn.Framework.Common;
using TCosReborn.Framework.Utility;
using LocalizedString = TCosReborn.Framework.Common.LocalizedString;

namespace TCosReborn.Framework.PackageExtractor.Adapter
{
    public class MapExtractor : ExtractorAdapter
    {
        public override string Name
        {
            get { return "Map Extractor"; }
        }

        public override string Description
        {
            get { return "Tries to extract the Maps into a resource file"; }
        }

        #region Extraction
        enum SkipExtractionReason { Normal, Error, Skippable }
        SkipExtractionReason ExtractObject(SBObject sbo, SBResourceListing res, SBLocalizedStrings localizedStrings, ResourceStash saveStash, WorldHelper world, out SBPackageResource extracted)
        {
            var exName = sbo.Name.Replace("\0", string.Empty);
            var exPkg = sbo.Package.Replace("\0", string.Empty);
            SBPackageResource existingInstance;
            if (saveStash.TryGetObject(exName, exPkg, out existingInstance))
            {
                extracted = existingInstance;
                return SkipExtractionReason.Normal;
            }
            var className = GetClassName(sbo);
            if (ReflectionHelper.CanBeSkipped(sbo.ClassName.Replace("\0" ,string.Empty)))
            {
                extracted = null;
                return SkipExtractionReason.Skippable;
            }
            var type = GetTypeFromName(className);
            if (type.IsSubclassOf(typeof (Actor)))
            {
                Actor existingActor;
                if (world.TryGetActor(exName, out existingActor))
                {
                    extracted = null;
                    return SkipExtractionReason.Skippable;
                }
                //existingActor = new GameObject(exName).AddComponent(type) as Actor;
                existingActor = new Actor();
                world.AddActor(exName, existingActor);
                ExtractProps(existingActor, sbo, saveStash, res, localizedStrings, world, exName);
                extracted = null;
                return SkipExtractionReason.Skippable;
            }
            var instance = Activator.CreateInstance(type) as SBPackageResource;
            instance.IsExternalReference = false;
            instance.ReferenceObjectName = exName;
            instance.ReferencePackageName = exPkg;
            instance.ResourceID = FindResourceID(sbo,"PackageName", res); //TODO fix PackageName=real
            var yetStillExistingInstance = saveStash.Add(instance);
            if (yetStillExistingInstance != null)
            {
                if (yetStillExistingInstance.GetType() == instance.GetType())
                {
                    Log("First missed yet still existing instance used.(this should not happen)?");
                    extracted = yetStillExistingInstance;
                    return SkipExtractionReason.Error;
                }
            }

            ExtractProps(instance, sbo, saveStash, res, localizedStrings, world, instance.ReferenceObjectName);
            extracted = instance;
            return SkipExtractionReason.Normal;
        }

        void ExtractProps(object instance, SBObject sbo, ResourceStash saveStash, SBResourceListing res, SBLocalizedStrings strings, WorldHelper world, string parentHint = "")
        {
            var fieldInfos = new List<FieldInfo>(GetTypeFromName(GetClassName(sbo)).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy));
            foreach (var prop in sbo.IterateProperties())
            {
                ExtractPropertyIntoObject(instance, prop, fieldInfos, saveStash, res, strings, world, parentHint);
            }
        }

        void ExtractProps(object instance, SBProperty sbp, ResourceStash saveStash, SBResourceListing res, SBLocalizedStrings strings, WorldHelper world, string parentHint = "")
        {
            var fieldInfos = new List<FieldInfo>(instance.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy));
            foreach (var prop in sbp.IterateInnerProperties())
            {
                ExtractPropertyIntoObject(instance, prop, fieldInfos, saveStash, res, strings, world, parentHint);
            }
        }

        void ExtractPropertyIntoObject(object instance, SBProperty prop, List<FieldInfo> fieldInfos, ResourceStash saveStash, SBResourceListing res, SBLocalizedStrings strings, WorldHelper world, string parentHint)
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
                    var result = ExtractPropertyValue(prop, fieldInfo.FieldType, saveStash, res, strings, world, arraySize);
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
                                Log(string.Format("Error setting field value ({0}) on object: {1}", fieldInfo.Name, parentHint));
                            }
                        }
                    }
                    break;
                }
            }
        }

        Object ExtractPropertyValue(SBProperty prop, Type type, ResourceStash saveStash, SBResourceListing resources, SBLocalizedStrings strings, WorldHelper world, int optionalArraySize = 0)
        {
            if (ReflectionHelper.CanBeSkipped(type))
            {
                //Log(string.Format("Skipping: {0} ({1})", prop.Name, type.Name));
                return null;
            }
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
                    var content = ExtractPropertyValue(listProp, elementType, saveStash, resources, strings, world);
                    if (content != null)
                    {
                        array.SetValue(content, pos);
                    }
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
                Object converted;
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
                    SBPackageResource extractedRef;
                    var reason = ExtractObject(internalRef, resources, strings, saveStash, world, out extractedRef);
                    if (reason == SkipExtractionReason.Error)
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
                    SBPackageResource res;
                    if (FindExternalResource(exName, exPkg, out res))
                    {
                        return res;
                    }
                    Debug.Log("external: " + exName + " / " + exPkg);
                    var sbp = Activator.CreateInstance(t) as SBPackageResource;
                    if (sbp == null)
                    {
                        Log("Error creating ExternalReference type for: " + prop.Name);
                        return null;
                    }
                    sbp.IsExternalReference = true;
                    sbp.ReferenceObjectName = exName;
                    sbp.ReferencePackageName = exPkg;
                    sbp.ResourceID = resources.GetResourceID(val);
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
                        var content = ExtractPropertyValue(listProp, elementType, saveStash, resources, strings, world);
                        newList.Add(content);
                    }
                    return newList;
                }
                if (prop.Type == PropertyType.ObjectProperty && !prop.Name.Contains("."))
                {
                    //Log("Skipped: (" + prop.Name + ") " + prop.Value);
                    return null;
                }
                if (type.IsSubclassOf(typeof(Actor)))
                {
                    Actor actor;
                    if (world.TryGetActor(val, out actor))
                    {
                        return actor;
                    }
                    actor = new Actor();
                    world.AddActor(val, actor);
                    ExtractProps(actor, prop, saveStash, resources, strings, world, prop.Name);
                    return actor;
                }
                var fieldContent = CreateInstanceFromType(type, saveStash);
                if (fieldContent != null)
                {
                    //if (fieldContent is Actor)
                    //{
                    //    Debug.Log("Actor from: " + prop.Value + " / " + prop.Name);
                    //}
                    ExtractProps(fieldContent, prop, saveStash, resources, strings, world, prop.Name);
                    return fieldContent;
                }
            }
            return null;
        }

        #endregion

        #region Helper
        Dictionary<string, SBResourcePackage> existingPackages = new Dictionary<string, SBResourcePackage>();

        bool FindExternalResource(string objectName, string packageName, out SBPackageResource resource)
        {
            var objPkg = string.Empty;
            if (packageName.Contains("."))
            {
                var firstOccurence = packageName.IndexOf(".", StringComparison.OrdinalIgnoreCase);
                objPkg = packageName.Substring(firstOccurence, packageName.Length - firstOccurence);
                packageName = packageName.Replace(objPkg, string.Empty);
                objPkg = objPkg.TrimStart('.');
            }
            if (existingPackages.Count == 0 || !existingPackages.ContainsKey(packageName))
            {
                resource = null;
                return false;
            }
            var pkg = existingPackages[packageName];
            resource = pkg.FindResource(objectName, objPkg);
            return resource != null;
        }

        new Object CreateInstanceFromType(Type t, ResourceStash saveStash)
        {
            if (t.IsSubclassOf(typeof(SBPackageResource)))
            {
                var ret = Activator.CreateInstance(t) as SBPackageResource;
                var existing = saveStash.Add(ret);
                if (existing != null)
                {
                    Log("this line should not be printed");
                }
                return ret;
            }
            if (!t.IsSerializable)
            {
                Log("Fieldtype (" + t.Name + ") is not serializable, not extracting!");
                return null;
            }
            return Activator.CreateInstance(t);
        }

        class WorldHelper
        {
            public WorldHelper(SBMapObjectPackage map)
            {
                MapFile = map;
            }

            public SBMapObjectPackage MapFile;
            Dictionary<string, Actor> Actors = new Dictionary<string, Actor>();

            public IEnumerable<Actor> ForeachActor()
            {
                foreach (var actor in Actors.Values)
                {
                    yield return actor;
                }
            }
            public bool TryGetActor(string name, out Actor actor)
            {
                return Actors.TryGetValue(name, out actor);
            }

            public void AddActor(string name, Actor actor)
            {
                Actors.Add(name, actor);
            }
        }
        #endregion

    }
}