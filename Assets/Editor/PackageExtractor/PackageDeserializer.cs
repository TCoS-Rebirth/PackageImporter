using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Engine;
using SBGame;
using SBGamePlay;
using TCosReborn;
using UnityEditor;
using UnityEngine;
using Color = Engine.Color;

namespace Framework.PackageExtractor
{
    public class PackageDeserializer:IDisposable
    {
        GlobalHeader Header;

        string[] NameTable { get; set; }
        ExportEntry[] ExportTable { get; set; }
        ImportEntry[] ImportTable { get; set; }

        public string PackageName { get; }

        const string NULL = "null";
        const string NONE = "none";
        const string DRFORTHEWIN = "DRFORTHEWIN";

        //Queue<DelayedLink> LinkerLinks;

        string FindReferenceName(int reference, bool showAncestors = true)
        {
            if (reference > 0)
            {
                var result = GetName(ExportTable[reference - 1].ObjectNameReference);
                if (!showAncestors) return result;
                var ancestors = FindReferenceName(ExportTable[reference - 1].PackageReference);
                if (!string.Equals(ancestors, NULL, StringComparison.OrdinalIgnoreCase))
                    result = ancestors + "." + result;
                return result;
            }
            if (reference == 0) return NULL;
            else
            {
                var result = GetName(ImportTable[-reference - 1].ObjectReference);
                if (!showAncestors) return result;
                var ancestors = FindReferenceName(ImportTable[-reference - 1].PackageReference);
                if (!string.Equals(ancestors, NULL, StringComparison.OrdinalIgnoreCase))
                    result = ancestors + "." + result;
                return result;
            }
        }

        string FindAbsoluteObjectReference(int reference, out string className, out string absoluteClassPath)
        {
            if (reference > 0)
            {
                var refe = ExportTable[reference - 1];
                className = refe.ClassName;
                absoluteClassPath = refe.AbsoluteObjectTypeReference;
                return refe.AbsoluteObjectReference;
            }
            if (reference == 0)
            {
                className = NULL;
                absoluteClassPath = NULL;
                return NULL;
            }
            else
            {
                var refe = ImportTable[-reference - 1];
                className = refe.ClassName;
                absoluteClassPath = refe.AbsoluteObjectTypeReference;
                return refe.AbsoluteObjectReference;
            }
        }

        NameProperty GetName(int reference)
        {
            return NameTable[reference].Replace("\0", string.Empty);
        }

        string filePath;

        SBFileReader fileReader;

        public void Dispose()
        {
            if (fileReader == null) return;
            fileReader.Dispose();
        }

        IResourceLocator resourceLocator;

        string targetFolder;

        public PackageDeserializer(string filePath, string targetProjectFolder, IResourceLocator resourceLocator)
        {
            targetFolder = targetProjectFolder;
            this.resourceLocator = resourceLocator;
            this.filePath = filePath;
            PackageName = Path.GetFileNameWithoutExtension(filePath);
        }

        public void Load(ref SBResourcePackage targetPackage, List<PackageObject> exportedObjects, bool createPrefabs)
        {
            fileReader = new SBFileReader(filePath);
            fileReader.Read(out Header, Marshal.SizeOf(Header));
            fileReader.Seek(Header.NameOffset, SeekOrigin.Begin);

            NameTable = new string[Header.NameCount];
            //----------- READ NAME TABLE --------------

            #region NameTable

            for (uint k = 0; k < Header.NameCount; ++k)
            {
                int nameSize = fileReader.ReadByte();
                var stringArray = fileReader.ReadBytes(nameSize);
                fileReader.ReadUInt32(); //uint objectFlags
                var name = Encoding.ASCII.GetString(stringArray).Replace("\0", string.Empty);
                NameTable[k] = name;
            }
            //Log(string.Format("NameTable: {0} names read", NameTable.Length), 0);

            #endregion

            //------------------ READ IMPORT TABLE ---------------------------

            #region ImportTable

            ImportTable = new ImportEntry[Header.ImportCount];
            fileReader.Seek(Header.ImportOffset, SeekOrigin.Begin);
            for (uint k = 0; k < Header.ImportCount; ++k)
            {
                var entry = new ImportEntry
                {
                    ClassPackageReference = fileReader.ReadIndex(),
                    ClassReference = fileReader.ReadIndex(),
                    PackageReference = fileReader.ReadInt32(),
                    ObjectReference = fileReader.ReadIndex()
                };
                ImportTable[k] = entry;
            }
            //Log(string.Format("ImportTable: {0} imports read", ImportTable.Length), 0);

            #endregion

            //------------------- READ EXPORT TABLE --------------------------

            #region ExportTable

            ExportTable = new ExportEntry[Header.ExportCount];
            fileReader.Seek(Header.ExportOffset, SeekOrigin.Begin);
            for (uint k = 0; k < Header.ExportCount; ++k)
            {
                var entry = new ExportEntry
                {
                    ClassReference = fileReader.ReadIndex(),
                    SuperReference = fileReader.ReadIndex(),
                    PackageReference = fileReader.ReadInt32(),
                    ObjectNameReference = fileReader.ReadIndex(),
                    ObjectFlags = fileReader.ReadInt32(),
                    SerialSize = fileReader.ReadIndex()
                };
                if (entry.SerialSize > 0)
                {
                    entry.SerialOffset = fileReader.ReadIndex();
                }
                ExportTable[k] = entry;
            }
            //Log(string.Format("ExportTable: {0} exports read", ExportTable.Length), 0);

            #endregion

            //------------------- Resolve Import & Export references to readable names--------------------

            for (var i = 0; i < ImportTable.Length; i++)
            {
                ImportTable[i].ObjectPackageName = FindReferenceName(ImportTable[i].PackageReference);
                ImportTable[i].ClassPackageName = GetName(ImportTable[i].ClassPackageReference);
                ImportTable[i].ClassName = GetName(ImportTable[i].ClassReference);
                ImportTable[i].ObjectName = GetName(ImportTable[i].ObjectReference);

                var objFormatted = (ImportTable[i].ObjectPackageName != NULL ? ImportTable[i].ObjectPackageName : "") + (ImportTable[i].ObjectName != NULL ? (ImportTable[i].ObjectPackageName != NULL ? "." : "") + ImportTable[i].ObjectName : "");
                var classFormatted = (ImportTable[i].ClassPackageName != NULL ? ImportTable[i].ClassPackageName : "") + (ImportTable[i].ClassName != NULL ? (ImportTable[i].ClassPackageName != NULL ? "." : "") + ImportTable[i].ClassName : "");
                ImportTable[i].AbsoluteObjectReference = objFormatted;
                ImportTable[i].AbsoluteObjectTypeReference = classFormatted;
                ImportTable[i].IsClassType = classFormatted.Equals("Core.Class", StringComparison.OrdinalIgnoreCase);
            }

            for (var i = 0; i < ExportTable.Length; i++)
            {
                ExportTable[i].ClassName = FindReferenceName(ExportTable[i].ClassReference);
                ExportTable[i].ClassParentName = FindReferenceName(ExportTable[i].SuperReference);
                ExportTable[i].ObjectPackageName = FindReferenceName(ExportTable[i].PackageReference);
                ExportTable[i].ObjectName = GetName(ExportTable[i].ObjectNameReference);

                var objFormatted = (ExportTable[i].ObjectPackageName != NULL ? ExportTable[i].ObjectPackageName : "") + (ExportTable[i].ObjectName != NULL ? (ExportTable[i].ObjectPackageName != NULL ? "." : "") + ExportTable[i].ObjectName : "");
                var classFormatted = (ExportTable[i].ClassParentName != NULL ? ExportTable[i].ClassParentName : "") + (ExportTable[i].ClassName != NULL ? (ExportTable[i].ClassParentName != NULL ? "." : "") + ExportTable[i].ClassName : "");
                ExportTable[i].AbsoluteObjectReference = string.Format("{0}.{1}", PackageName, objFormatted);
                ExportTable[i].AbsoluteObjectTypeReference = classFormatted;
                ExportTable[i].IsClassType = classFormatted.Equals("Core.Class", StringComparison.OrdinalIgnoreCase);
            }

            //--------------- READ ALL OBJECTS EXPORTED -----------------------

            #region Objects

            var packageObjects = new List<PackageObject>(ExportTable.Length);
            for (var i = 0; i < ExportTable.Length; i++)
            {
                var entry = ExportTable[i];
                var po = new PackageObject
                {
                    AbsoluteObjectNamePath = entry.AbsoluteObjectReference.Replace("\0", string.Empty),
                    ID = createPrefabs?PackageObject.NextID():-1,
                    Instance = null,
                    ClassName = entry.ClassName.Replace("\0", string.Empty),
                    ClassPath = entry.AbsoluteObjectTypeReference,
                    PackageName = entry.ObjectPackageName.Replace("\0", string.Empty),
                    ObjectFlags = entry.ObjectFlags,
                    SerialOffset = entry.SerialOffset,
                    SerialSize = entry.SerialSize,
                    ReaderOffset = entry.SerialOffset,
                    ObjectName = entry.ObjectName.Replace("\0", string.Empty)
                };
                po.Instance = ReadObjectPrepass(po);
                if (po.Instance == null)
                {
                    continue;
                }
                po.Instance.name = po.ObjectName;
                if (createPrefabs) po.Instance.ResourceID = po.ID;
                packageObjects.Add(po);
            }

            //Assemble hierarchy
            for (var i = 0; i < packageObjects.Count; i++)
            {
                if (packageObjects[i].Instance == null) continue;
                packageObjects[i].Instance.transform.SetParent(targetPackage.transform);
                if (packageObjects[i].PackageName.Equals(NULL, StringComparison.OrdinalIgnoreCase)) continue;
                var specificParent = packageObjects[i].PackageName.Replace("\0", string.Empty);
                var found = false;
                for (var j = 0; j < packageObjects.Count; j++)
                {
                    if (packageObjects[j].Instance == null) continue;
                    if (!packageObjects[j].AbsoluteObjectNamePath.Replace(PackageName+".", string.Empty).Equals(specificParent, StringComparison.OrdinalIgnoreCase)) continue;
                    found = true;
                    packageObjects[i].Instance.transform.SetParent(packageObjects[j].Instance.transform);
                    var pkg = packageObjects[j].Instance as SBResourcePackage;
                    if (pkg == null)
                    {
                        packageObjects[i].Instance.Outer = packageObjects[j].Instance;
                    }
                }
                if (!found)
                {
                    throw new Exception(string.Format("Parent {0} not found for {1}", specificParent, packageObjects[i].AbsoluteObjectNamePath));
                }
            }

            var resDict = new Dictionary<int, UObject>();
            if (createPrefabs)
            {
                var prefabPath = string.Format("Assets/{0}/{1}.prefab", targetFolder, PackageName);
                PrefabUtility.CreatePrefab(prefabPath, targetPackage.gameObject);
                UnityEngine.Object.DestroyImmediate(targetPackage.gameObject, false);
                targetPackage = AssetDatabase.LoadAssetAtPath<SBResourcePackage>(prefabPath);
                var prefabObjs = targetPackage.GetComponentsInChildren<UObject>(true);
                EditorUtility.SetDirty(targetPackage.gameObject);
                EditorUtility.SetDirty(targetPackage);
                for (var i = 0; i < prefabObjs.Length; i++)
                {
                    resDict.Add(prefabObjs[i].ResourceID, prefabObjs[i]);
                }
            }

            for (var i = packageObjects.Count; i-->0;)
            {
                if (createPrefabs)
                {
                    packageObjects[i].Instance = resDict[packageObjects[i].ID];
                    packageObjects[i].ID = -1;
                    packageObjects[i].Instance.ResourceID = -1;
                }
                if (!resourceLocator.RegisterExportedResource(packageObjects[i].AbsoluteObjectNamePath, packageObjects[i].Instance))
                {
                    UnityEngine.Object.DestroyImmediate(packageObjects[i].Instance, true);
                    Debug.LogWarning("Removed duplicate object: " + packageObjects[i].AbsoluteObjectNamePath);
                    packageObjects.RemoveAt(i);
                }
            }
            exportedObjects.AddRange(packageObjects);
            #endregion
        }

        UObject ReadObjectPrepass(PackageObject activeObject)
        {
            //Currently we cannot read null class
            if (activeObject.SerialSize <= 0 || string.Equals(activeObject.ClassName, NULL, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            //Read Object data if present
            fileReader.Seek(activeObject.SerialOffset, SeekOrigin.Begin);

            if (ReflectionHelper.CanSkip(activeObject.ClassName))
            {
                fileReader.Seek(activeObject.SerialSize, SeekOrigin.Current);
                return null;
            }
            var realType = ReflectionHelper.GetTypeFromName(activeObject.ClassName);
            UObject realObject = null;
            if (realType != null)
            {
                try
                {
                    realObject = ReflectionHelper.CreateInstance(realType) as UObject;
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
            else Debug.LogWarning("Type not found: " + activeObject.ClassName);

            if (realObject == null)
            {
                Debug.LogError("Could not create instance from class name: " + activeObject.ClassName);
                return null;
            }

            //If Object has a stack, read it but do nothing with it
            var hasExecutionStack = false;
            if ((activeObject.ObjectFlags & (int)ObjectFlags.RF_HasStack) != 0)
            {
                hasExecutionStack = true;
                activeObject.Flags.Add(ObjectFlags.RF_HasStack);
            }
            if (hasExecutionStack)
            {
                var stateFrameNode = fileReader.ReadIndex();
                fileReader.ReadIndex();
                fileReader.ReadInt64();
                fileReader.ReadInt32();
                if (stateFrameNode != 0)
                {
                    fileReader.ReadIndex();
                }
            }
            activeObject.ReaderOffset = fileReader.Position;
            return realObject;
        }

        public void ReadObject(PackageObject activeObject)
        {
            fileReader.Seek(activeObject.ReaderOffset, SeekOrigin.Begin);
            ReadProperties(activeObject);
            EditorUtility.SetDirty(activeObject.Instance);
            EditorUtility.SetDirty(activeObject.Instance.gameObject);
            //Try to read class
            ReadClass(activeObject);
        }

        void ReadProperties(PackageObject activeObject)
        {
            var allPropsSize = 0;
            do
            {
                int propBytesRead;
                var activeProperty = ReadProperty(activeObject.Instance, out propBytesRead);
                allPropsSize += propBytesRead;
                if (activeProperty == null)
                {
                    break;
                }
                var targetField = ReflectionHelper.FindField(activeObject.Instance, activeProperty.Name);
                if (targetField == null)
                {
                    throw new Exception(string.Format("Field: {0} doesn't exist for: {1} ", activeProperty.Name, activeObject.Instance));
                }
                if (ReflectionHelper.IsMarkedAsIgnored(targetField))
                {
                    fileReader.Seek(activeProperty.ValueOffset + activeProperty.SerialSize, SeekOrigin.Begin);
                    allPropsSize += activeProperty.SerialSize;
                    continue;
                }
                var propValue = ReadPropertyValue(activeObject.Instance, activeProperty, out propBytesRead);
                allPropsSize += propBytesRead;
                if (propValue != null)
                {
                    ReflectionHelper.TrySetValue(activeObject.Instance, targetField, propValue, activeProperty.ArrayIndex, resourceLocator);
                }
            } while (true/*fileReader.Position < activeObject.SerialOffset + activeObject.SerialSize*/);
            if (allPropsSize == activeObject.SerialSize) return;
            var diff = (activeObject.SerialOffset + activeObject.SerialSize) - fileReader.Position;
            //if (diff > 17)
            //{
            //    Debug.LogWarning(string.Format("{1} has {0} bytes of additional data appended", diff, activeObject));
            //}
            fileReader.Seek(diff, SeekOrigin.Current);
        }

        SBProperty ReadProperty(object activeObject, out int returnBytesRead)
        {
            int readIndexBytes;
            var activeProperty = new SBProperty();
            var propertyNameIndex = fileReader.ReadIndex(out readIndexBytes);
            returnBytesRead = readIndexBytes;
            try
            {
                activeProperty.Name = GetName(propertyNameIndex);
            }
            catch (IndexOutOfRangeException)
            {
                Debug.LogError("Error: failed to read a Property's name for: " + activeObject);
                return null;
            }
            //Detect end of property list
            if (activeProperty.Name.Equals(DRFORTHEWIN) || activeProperty.Name.Equals(NONE, StringComparison.OrdinalIgnoreCase))
                return null;

            const byte typeMask = 0x0F;
            const byte sizeMask = 0x70;
            const byte arrayIndexMask = 0x80;

            //Read the property info byte
            var infoByte = fileReader.ReadByte();
            returnBytesRead += 1;

            //Parse property info byte
            activeProperty.Type = (PropertyType) (infoByte & typeMask);
            //var type = (byte)(infoByte & typeMask);
            //var size = (byte)((infoByte & sizeMask) >> 4);
            //var arrayIndexBit = (byte)(infoByte & arrayIndexMask);
            //activeProperty.Type = (PropertyType)type;

            if (activeProperty.Type == PropertyType.StructProperty)
            {
                var structNameIndex = fileReader.ReadIndex(out readIndexBytes);
                returnBytesRead += readIndexBytes;
                activeProperty.StructName = GetName(structNameIndex);
            }

            activeProperty.SerialSize = DeserializeSize((byte) (infoByte & sizeMask));

            //Display value if not array flag but boolean value
            if (activeProperty.Type == PropertyType.BooleanProperty)
            {
                activeProperty.boolValue = (infoByte & arrayIndexMask) != 0;
            }
            else
            {
                if ((infoByte & arrayIndexMask) != 0)
                {
                    int arrayBytesRead;
                    activeProperty.ArrayIndex = DeserializeArrayIndex(out arrayBytesRead);
                    returnBytesRead += arrayBytesRead;
                }
            }
            activeProperty.ValueOffset = fileReader.Position;
            return activeProperty;
        }

        int DeserializeArrayIndex(out int returnBytesRead)
        {
            int arrayIndex;
            var b = fileReader.ReadByte();
            returnBytesRead = 1;
            if( (b & 0x80) == 0 )
            {
                arrayIndex = b;
            }
            else if( (b & 0xC0) == 0x80)
            {
                arrayIndex = ((b & 0x7F) << 8) + fileReader.ReadByte();
                returnBytesRead += 1;
            }
            else
            {
                arrayIndex = ((b & 0x3F) << 24)
                             + (fileReader.ReadByte() << 16)
                             + (fileReader.ReadByte() << 8)
                             + fileReader.ReadByte();
                returnBytesRead += 3;
            }
            return arrayIndex;
        }

        int DeserializeSize( byte sizePack )
        {
            switch( sizePack )
            {
                case 0x00:
                    return 1;

                case 0x10:
                    return 2;

                case 0x20:
                    return 4;

                case 0x30:
                    return 12;

                case 0x40:
                    return 16;

                case 0x50:
                    return fileReader.ReadByte();

                case 0x60:
                    return fileReader.ReadInt16();

                case 0x70:
                    return fileReader.ReadInt32();

                default:
                    throw new NotImplementedException(string.Format( "Unknown packed size {0}", sizePack ) );
            }
        }

        object ReadPropertyValue(object activeObject, SBProperty activeProperty, out int propValueBytesRead)
        {
            int readIndexBytes;
            switch (activeProperty.Type)
            {
                case PropertyType.BooleanProperty:
                    if (activeProperty.SerialSize == 1)
                    {
                        propValueBytesRead = 1;
                        return fileReader.ReadByte() > 0;
                    }
                    propValueBytesRead = 0;
                    return activeProperty.boolValue;
                case PropertyType.ByteProperty:
                    propValueBytesRead = 1;
                    return fileReader.ReadByte();
                case PropertyType.IntegerProperty:
                    propValueBytesRead = 4;
                    return fileReader.ReadInt32();
                case PropertyType.FloatProperty:
                    propValueBytesRead = 4;
                    return fileReader.ReadFloat();
                case PropertyType.NameProperty:
                    return GetName(fileReader.ReadIndex(out propValueBytesRead));
                case PropertyType.StringProperty:
                case PropertyType.StrProperty:
                    var stringSize = fileReader.ReadIndex(out readIndexBytes);
                    propValueBytesRead = readIndexBytes;
                    var stringBytes = fileReader.ReadBytes(stringSize);
                    var stringValue = Encoding.ASCII.GetString(stringBytes).Replace("\0", string.Empty);
                    propValueBytesRead += stringSize;
                    return stringValue;
                case PropertyType.ObjectProperty:
                    var objectReference = fileReader.ReadIndex(out readIndexBytes);
                    propValueBytesRead = readIndexBytes;
                    string className;
                    string absoluteClassName;
                    var obj = FindAbsoluteObjectReference(objectReference, out className, out absoluteClassName);
                    if (obj.Equals(NULL, StringComparison.OrdinalIgnoreCase)) return null;
                    var link = new DelayedLink
                    {
                        IndexReference = activeProperty.ArrayIndex,
                        AbsoluteObjectReference = obj,
                        TargetReference = activeObject,
                        AbsoluteClassPath = absoluteClassName,
                        SkipTestClassReference = className
                    };
                    if (objectReference < 0)
                    {
                        var importRef = ImportTable[-objectReference - 1];
                        if (importRef.IsClassType)
                        {
                            link.IsTypeReference = true;
                        }
                        link.IsImport = true;
                    }
                    else
                    {
                        var exportRef = ExportTable[objectReference - 1];
                        if (exportRef.IsClassType)
                        {
                            link.IsTypeReference = true;
                        }
                        link.IsImport = false;
                    }
                    return link;
                case PropertyType.VectorProperty:
                    propValueBytesRead = 12;
                    return new Vector(fileReader.ReadFloat(), fileReader.ReadFloat(), fileReader.ReadFloat());
                case PropertyType.RotatorProperty:
                    propValueBytesRead = 12;
                    return new Rotator(fileReader.ReadInt32(), fileReader.ReadInt32(), fileReader.ReadInt32());
                case PropertyType.StructProperty:
                    switch (activeProperty.StructName)
                    {
                        case "Vector":
                            propValueBytesRead = 12;
                            return new Vector(fileReader.ReadFloat(), fileReader.ReadFloat(), fileReader.ReadFloat());
                        case "Rotator":
                            propValueBytesRead = 12;
                            return new Rotator(fileReader.ReadInt32(), fileReader.ReadInt32(), fileReader.ReadInt32());
                        case "Color":
                            propValueBytesRead = 4;
                            return new Color(fileReader.ReadByte(), fileReader.ReadByte(), fileReader.ReadByte(), fileReader.ReadByte());
                        case "LinearColor":
                            propValueBytesRead = 16;
                            return new Color(
                                (byte)(1f / 255 * fileReader.ReadFloat()),
                                (byte)(1f / 255 * fileReader.ReadFloat()),
                                (byte)(1f / 255 * fileReader.ReadFloat()),
                                (byte)(1f / 255 * fileReader.ReadFloat()));
                        case "LocalizedString":
                            propValueBytesRead = 4;
                            return new LocalizedString(fileReader.ReadInt32());
                        default:
                            if (activeProperty.StructName.Length == 0) throw new Exception("This should not happen");
                            var type = ReflectionHelper.GetTypeFromName(activeProperty.StructName);
                            if (type == null)
                            {
                                Debug.LogError("Type not found for struct: " + activeProperty.StructName);
                                propValueBytesRead = 0;
                                return null;
                            }
                            var realStruct = ReflectionHelper.CreateInstance(type);
                            if (realStruct == null) throw new Exception("This should not happen");
                            var structBytesRead = 0;
                            do
                            {
                                int insidePropBytesRead;
                                var structProp = ReadProperty(realStruct, out insidePropBytesRead);
                                structBytesRead += insidePropBytesRead;
                                if (structProp == null)
                                {
                                    break;
                                }
                                var targetField = ReflectionHelper.FindField(realStruct, structProp.Name);
                                if (targetField == null) throw new Exception(string.Format("Field '{0}' does not exist in struct {1}", structProp.Name, realStruct));
                                if (ReflectionHelper.IsMarkedAsIgnored(targetField))
                                {
                                    fileReader.Seek(structProp.ValueOffset + structProp.SerialSize, SeekOrigin.Begin);
                                    structBytesRead += structProp.SerialSize;
                                    continue;
                                }
                                var propValue = ReadPropertyValue(realStruct, structProp, out insidePropBytesRead);
                                structBytesRead += insidePropBytesRead;
                                if (propValue != null)
                                {
                                    ReflectionHelper.TrySetValue(realStruct, targetField, propValue, structProp.ArrayIndex, resourceLocator);
                                }
                            } while (true/*structBytesRead < activeProperty.SerialSize*/);
                            propValueBytesRead = structBytesRead;
                            return realStruct;
                    }
                case PropertyType.ArrayProperty:
                    var arrayField = ReflectionHelper.FindField(activeObject, activeProperty.Name);
                    if (arrayField == null)
                    {
                        throw new NullReferenceException("Field must exist");
                    }
                    if (ReflectionHelper.IsMarkedAsIgnored(arrayField))
                    {
                        throw new Exception("This should not happen. Parent must filter ignored fields");
                    }
                    Type arrayType;
                    Type arrayContentType;
                    var arrayContentUType = ReflectionHelper.GetArrayType(activeObject, activeProperty.Name, out arrayType, out arrayContentType);
                    if (arrayContentUType == PropertyType.UnknownProperty) throw new Exception("should not happen");
                    var arraySize = fileReader.ReadIndex(out readIndexBytes);
                    propValueBytesRead = readIndexBytes;
                    //if array
                    if (arrayType.IsArray)
                    {
                        var array = Array.CreateInstance(arrayContentType, arraySize);
                        var arrayBytesRead = 0;
                        for (var i = 0; i < arraySize; i++)
                        {
                            var arrayContentProp = new SBProperty { Type = arrayContentUType, StructName = arrayContentType.Name, SerialSize = activeProperty.SerialSize};
                            int propBytesRead;
                            var arrayContent = ReadPropertyValue(activeObject, arrayContentProp, out propBytesRead);
                            arrayBytesRead += propBytesRead;
                            if (arrayContent != null)
                            {
                                ReflectionHelper.TrySetValue(array, arrayField, arrayContent, i, resourceLocator);
                            }
                        }
                        propValueBytesRead += arrayBytesRead;
                        return array;
                    }
                    //if list
                    if (arrayType.GetGenericTypeDefinition() != typeof(List<>)) throw new Exception("should not happen");
                    {
                        var listType = typeof(List<>);
                        listType = listType.MakeGenericType(arrayContentType);
                        var list = ReflectionHelper.CreateInstance(listType) as IList;
                        var elementType = listType.GetGenericArguments()[0];
                        for (var i = 0; i < arraySize; i++) //resize
                        {
                            list.Add(elementType.IsValueType ? ReflectionHelper.CreateInstance(elementType) : null);
                        }
                        var listBytesRead = 0;
                        for (var i = 0; i < arraySize; i++)
                        {
                            var listContentProp = new SBProperty { Type = arrayContentUType, StructName = arrayContentType.Name, SerialSize = activeProperty.SerialSize};
                            int propBytesRead;
                            var listContent = ReadPropertyValue(activeObject, listContentProp, out propBytesRead);
                            listBytesRead += propBytesRead;
                            if (listContent != null)
                            {
                                ReflectionHelper.TrySetValue(list, arrayField, listContent, i, resourceLocator);
                            }
                        }
                        propValueBytesRead += listBytesRead;
                        return list;
                    }
                default:
                    fileReader.Seek(activeProperty.SerialSize, SeekOrigin.Current);
                    Debug.LogError("unhandled switch case: " + activeProperty.Type);
                    propValueBytesRead = activeProperty.SerialSize;
                    return null;
            }
        }
        
        void ReadClass(PackageObject activeObject)
        {
            var className = activeObject.ClassName.Contains("(") ? activeObject.ClassName.Substring(0, activeObject.ClassName.IndexOf("(", StringComparison.Ordinal) - 1).Trim() : activeObject.ClassName;
            switch (className)
            {
                case "Const":
                    activeObject.Class = ReadConstClass(fileReader);
                    break;
                case "Enum":
                    activeObject.Class = ReadEnumClass(fileReader);
                    break;
                case "Property":
                    activeObject.Class = ReadPropertyClass(fileReader);
                    break;
                case "ByteProperty":
                    activeObject.Class = ReadBytePropertyClass(fileReader);
                    break;
                case "ObjectProperty":
                    activeObject.Class = ReadObjectPropertyClass(fileReader);
                    break;
                case "FixedArrayProperty":
                    activeObject.Class = ReadFixedArrayPropertyClass(fileReader);
                    break;
                case "ArrayProperty":
                    activeObject.Class = ReadArrayPropertyClass(fileReader);
                    break;
                case "MapProperty":
                    activeObject.Class = ReadMapPropertyClass(fileReader);
                    break;
                case "ClassProperty":
                    activeObject.Class = ReadClassPropertyClass(fileReader);
                    break;
                case "StructProperty":
                    activeObject.Class = ReadStructPropertyClass(fileReader);
                    break;
                case "IntProperty":
                    activeObject.Class = ReadIntPropertyClass(fileReader);
                    break;
                case "BoolProperty":
                    activeObject.Class = ReadBoolPropertyClass(fileReader);
                    break;
                case "FloatProperty":
                    activeObject.Class = ReadFloatPropertyClass(fileReader);
                    break;
                case "NameProperty":
                    activeObject.Class = ReadNamePropertyClass(fileReader);
                    break;
                case "StrProperty":
                    activeObject.Class = ReadStrPropertyClass(fileReader);
                    break;
                case "StringProperty":
                    activeObject.Class = ReadIntPropertyClass(fileReader);
                    break;
                case "Struct":
                    activeObject.Class = ReadStructClass(fileReader);
                    break;
                case "Function":
                    activeObject.Class = ReadFunctionClass(fileReader);
                    break;
                case "State":
                    activeObject.Class = ReadStateClass(fileReader);
                    break;
                case NULL:
                case NONE:
                    activeObject.Class = ReadNullClass(fileReader);
                    break;
            }
            if (activeObject.Class != null && !string.Equals(activeObject.Class.Name, NULL, StringComparison.OrdinalIgnoreCase))
            {
                Debug.LogWarning("!Wow, a class was read!");
            }
        }


        #region Class reading Specific
        SBClass ReadFieldClass(SBFileReader reader)
        {
            var superField = reader.ReadIndex();
            var next = reader.ReadIndex();
            var field = new SBClass {Name = "Field"};
            field.Fields.Add("SuperField", superField.ToString());
            field.Fields.Add("Next", next.ToString());
            return field;
        }

        SBClass ReadConstClass(SBFileReader reader)
        {
            var constClass = new SBClass
            {
                Ancestor = ReadFieldClass(reader),
                Name = "Const"
            };

            var size = reader.ReadIndex();
            var constant = Encoding.ASCII.GetString(reader.ReadBytes(size)).Replace("\0", string.Empty);
            constClass.Fields.Add("Size", size.ToString());
            constClass.Fields.Add("Constant", constant);
            return constClass;
        }

        SBClass ReadEnumClass(SBFileReader reader)
        {
            var enumClass = new SBClass
            {
                Name = "Enum",
                Ancestor = ReadFieldClass(reader)
            };
            var arraySize = reader.ReadIndex();
            enumClass.Fields.Add("ArraySize", arraySize.ToString());
            for (var i = 0; i < arraySize; ++i)
            {
                enumClass.Fields.Add("ElementName" + i, GetName(reader.ReadIndex()));
            }

            return enumClass;
        }

        SBClass ReadPropertyClass(SBFileReader reader)
        {
            var property = new SBClass
            {
                Name = "Property",
                Ancestor = ReadFieldClass(reader)
            };

            var arrayDimension = reader.ReadInt16();
            var elementSize = reader.ReadInt16();
            var propertyFlags = reader.ReadInt32();
            var category = reader.ReadIndex();
            property.Fields.Add("ArrayDimension", arrayDimension.ToString());
            property.Fields.Add("ElementSize", elementSize.ToString());
            property.Fields.Add("PropertyFlags", propertyFlags.ToString());
            property.Fields.Add("Category", GetName(category));
            if ((propertyFlags & (int)PropertyFlags.CPF_Net) != 0)
            {
                int replicationOffset = reader.ReadInt16();
                property.Fields.Add("Replication Offset", replicationOffset.ToString());
            }

            return property;
        }

        SBClass ReadBytePropertyClass(SBFileReader reader)
        {
            var byteProperty = new SBClass
            {
                Name = "ByteProperty",
                Ancestor = ReadPropertyClass(reader)
            };
            var enumType = reader.ReadIndex();
            byteProperty.Fields.Add("EnumType", enumType.ToString());

            return byteProperty;
        }

        SBClass ReadObjectPropertyClass(SBFileReader reader)
        {
            var objectProperty = new SBClass
            {
                Name = "ObjectProperty",
                Ancestor = ReadPropertyClass(reader)
            };
            var objectType = reader.ReadIndex();
            objectProperty.Fields.Add("ObjectType", FindReferenceName(objectType));

            return objectProperty;
        }

        SBClass ReadFixedArrayPropertyClass(SBFileReader reader)
        {
            var fixedArrayProperty = new SBClass
            {
                Name = "FixedArrayProperty",
                Ancestor = ReadPropertyClass(reader)
            };

            var inner = reader.ReadIndex();
            var count = reader.ReadIndex();

            fixedArrayProperty.Fields.Add("Inner", FindReferenceName(inner));
            fixedArrayProperty.Fields.Add("Count", FindReferenceName(count));

            return fixedArrayProperty;
        }

        SBClass ReadArrayPropertyClass(SBFileReader reader)
        {
            var arrayProperty = new SBClass
            {
                Name = "ArrayProperty",
                Ancestor = ReadPropertyClass(reader)
            };

            var inner = reader.ReadIndex();

            arrayProperty.Fields.Add("Inner", FindReferenceName(inner));

            return arrayProperty;
        }

        SBClass ReadMapPropertyClass(SBFileReader reader)
        {
            var mapProperty = new SBClass
            {
                Name = "MapProperty",
                Ancestor = ReadPropertyClass(reader)
            };

            var key = reader.ReadIndex();
            var value = reader.ReadIndex();

            mapProperty.Fields.Add("Key", key.ToString());
            mapProperty.Fields.Add("Value", value.ToString());

            return mapProperty;
        }

        SBClass ReadClassPropertyClass(SBFileReader reader)
        {
            var classProperty = new SBClass
            {
                Name = "ClassProperty",
                Ancestor = ReadPropertyClass(reader)
            };

            var mclass = reader.ReadIndex();
            classProperty.Fields.Add("Class", GetName(mclass));

            return classProperty;
        }

        SBClass ReadStructPropertyClass(SBFileReader reader)
        {
            var structProperty = new SBClass
            {
                Name = "StructProperty",
                Ancestor = ReadPropertyClass(reader)
            };

            var structType = reader.ReadIndex();

            structProperty.Fields.Add("StructType", structType.ToString());

            return structProperty;
        }

        SBClass ReadIntPropertyClass(SBFileReader reader)
        {
            var intProperty = new SBClass
            {
                Name = "IntProperty",
                Ancestor = ReadPropertyClass(reader)
            };

            return intProperty;
        }

        SBClass ReadBoolPropertyClass(SBFileReader reader)
        {
            var boolProperty = new SBClass
            {
                Name = "BoolProperty",
                Ancestor = ReadPropertyClass(reader)
            };

            return boolProperty;
        }

        SBClass ReadFloatPropertyClass(SBFileReader reader)
        {
            var floatProperty = new SBClass
            {
                Name = "FloatProperty",
                Ancestor = ReadPropertyClass(reader)
            };

            return floatProperty;
        }

        SBClass ReadNamePropertyClass(SBFileReader reader)
        {
            var nameProperty = new SBClass
            {
                Name = "NameProperty",
                Ancestor = ReadPropertyClass(reader)
            };

            return nameProperty;
        }

        SBClass ReadStrPropertyClass(SBFileReader reader)
        {
            var strProperty = new SBClass
            {
                Name = "StrProperty",
                Ancestor = ReadPropertyClass(reader)
            };

            return strProperty;
        }

        SBClass ReadStringPropertyClass(SBFileReader reader)
        {
            var stringProperty = new SBClass
            {
                Name = "StringProperty",
                Ancestor = ReadPropertyClass(reader)
            };

            return stringProperty;
        }

        SBClass ReadStructClass(SBFileReader reader)
        {
            var structClass = new SBClass
            {
                Name = "Struct",
                Ancestor = ReadFieldClass(reader)
            };
            var scriptText = reader.ReadIndex();
            var children = reader.ReadIndex();
            var friendlyName = reader.ReadIndex();
            var line = reader.ReadInt32();
            var textPos = reader.ReadInt32();
            var scriptSize = reader.ReadInt32();
            //Try to "eat" the script code for children classes, but according
            //to the doc, it should not work, we have to reverse the bytecode...
            if (scriptSize > 0)
                reader.ReadBytes(scriptSize);
            structClass.Fields.Add("ScriptText", FindReferenceName(scriptText));
            structClass.Fields.Add("Children", FindReferenceName(children));
            structClass.Fields.Add("FriendlyName", GetName(friendlyName));
            structClass.Fields.Add("Line", line.ToString());
            structClass.Fields.Add("TextPos", textPos.ToString());
            structClass.Fields.Add("ScriptSize", scriptSize.ToString());

            return structClass;
        }

        SBClass ReadFunctionClass(SBFileReader reader)
        {
            var function = new SBClass
            {
                Name = "Function",
                Ancestor = ReadStructClass(reader)
            };

            var inative = reader.ReadInt16();
            var operatorPrecedence = reader.ReadByte();
            var functionFlags = reader.ReadInt32();
            function.Fields.Add("iNative", inative.ToString());
            function.Fields.Add("OperatorPrecedence", operatorPrecedence.ToString());
            function.Fields.Add("FunctionFlags", functionFlags.ToString());

            if ((functionFlags & (int)FunctionFlags.FUNC_Net) != 0)
            {
                var replicationOffset = reader.ReadInt16();
                function.Fields.Add("ReplicationOffset", replicationOffset.ToString());
            }

            return function;
        }

        SBClass ReadStateClass(SBFileReader reader)
        {
            var state = new SBClass
            {
                Name = "State",
                Ancestor = ReadStructClass(reader)
            };

            var probeMask = reader.ReadInt64();
            var ignoreMask = reader.ReadInt64();
            var labelTableOffset = reader.ReadInt16();
            var stateFlags = reader.ReadInt32();

            state.Fields.Add("ProbeMask", probeMask.ToString());
            state.Fields.Add("IgnoreMask", ignoreMask.ToString());
            state.Fields.Add("LabelTableOffset", labelTableOffset.ToString());
            state.Fields.Add("StateFlags", stateFlags.ToString());

            return state;
        }

        SBClass ReadNullClass(SBFileReader reader)
        {
            var nullClass = new SBClass
            {
                Name = NULL,
                Ancestor = ReadStateClass(reader)
            };

            var classFlags = reader.ReadInt32();
            var classGuid = reader.ReadInt32();
            var dependencies_count = reader.ReadIndex();
            //for now skip the dependencies, just "eat" them
            for (var i = 0; i < dependencies_count; ++i)
            {
                reader.ReadIndex(); //Class
                reader.ReadInt32(); //Deep
                reader.ReadInt32(); //ScriptTextCRC
            }
            var packageImports_count = reader.ReadIndex();
            //for now skip the package Imports, just "eat" them
            for (var i = 0; i < packageImports_count; ++i)
                reader.ReadIndex(); //PackageImport
            var classWithin = reader.ReadIndex();
            var classConfigName = reader.ReadIndex();

            nullClass.Fields.Add("ClassFlags", classFlags.ToString());
            nullClass.Fields.Add("ClassGuid", classGuid.ToString());
            nullClass.Fields.Add("Dependencies Count", dependencies_count.ToString());
            nullClass.Fields.Add("Package Imports Count", packageImports_count.ToString());
            nullClass.Fields.Add("Class Within", FindReferenceName(classWithin));
            nullClass.Fields.Add("Class Config Name", GetName(classConfigName));

            return nullClass;
        }

        [StructLayout(LayoutKind.Sequential, Size = 44, Pack = 1)]
        struct GlobalHeader
        {
            public uint Signature;
            public short FileVersion;
            public short LicenseeMode;
            public uint PackageFlags;
            public uint NameCount;
            public uint NameOffset;
            public uint ExportCount;
            public uint ExportOffset;
            public uint ImportCount;
            public uint ImportOffset;
            public uint HeritageCount;
            public uint HeritageOffset;
        }

        class ImportEntry
        {
            /// <summary>
            /// [NameTableIndex] Package (namespace) in which the type/class of the object is defined
            /// </summary>
            public int ClassPackageReference;
            /// <summary>
            /// [NameTableIndex] type/class of the object 
            /// </summary>
            public int ClassReference;
            /// <summary>
            /// [ObjectReference] Package file where the object resides in
            /// </summary>
            public int PackageReference;
            /// <summary>
            /// [NameTableIndex] name of the object
            /// </summary>
            public int ObjectReference;


            /// <summary>
            /// Namespace (package) of imported object type/class
            /// </summary>
            public string ClassPackageName;
            /// <summary>
            /// Type/class of imported object
            /// </summary>
            public string ClassName;

            /// <summary>
            /// Package of imported object
            /// </summary>
            public string ObjectPackageName;
            /// <summary>
            /// Name of imported object
            /// </summary>
            public string ObjectName;

            public string AbsoluteObjectReference;
            public string AbsoluteObjectTypeReference;
            public bool IsClassType;

            public override string ToString()
            {
                return string.Format("{0} ({1})", AbsoluteObjectReference, AbsoluteObjectTypeReference);
            }
        }

        public struct ExportEntry
        {

            /// <summary>
            /// [ObjectReference] class of the object
            /// </summary>
            public int ClassReference;
            /// <summary>
            /// [ObjectReference] object parent
            /// </summary>
            public int SuperReference;
            /// <summary>
            /// [ObjectReference] internal package/group of the object
            /// </summary>
            public int PackageReference;
            /// <summary>
            /// [NameTableIndex] name of the object
            /// </summary>
            public int ObjectNameReference;

            public int ObjectFlags;
            public int SerialSize;
            public int SerialOffset;

            /// <summary>
            /// Type of the exported object (can be imported or exported)
            /// </summary>
            public string ClassName;
            /// <summary>
            /// 'Parent' Type of the exported object
            /// </summary>
            public string ClassParentName;
            /// <summary>
            /// Namespace (Package) of the object
            /// </summary>
            public string ObjectPackageName;
            /// <summary>
            /// Name of exported object
            /// </summary>
            public string ObjectName;

            public string AbsoluteObjectReference;
            public string AbsoluteObjectTypeReference;
            public bool IsClassType;

            public override string ToString()
            {
                return string.Format("{0} ({1})", AbsoluteObjectReference, AbsoluteObjectTypeReference);
            }
        }

        class SBProperty
        {
            public int ArrayIndex;
            public string Name = "";
            public int SerialSize;
            public string StructName = "";
            public PropertyType Type;
            public bool boolValue;

            public long ValueOffset;
        }

        public class SBObject
        {
            public SBClass Class;

            /// <summary>
            /// Type of the object
            /// </summary>
            public string ClassName;
            public List<ObjectFlags> Flags;
            public string ObjectName;
            public string PackageName;

            public UObject Instance;
            public long PrepassOffset = 0;
        }

        public class SBClass
        {
            public SBClass Ancestor;
            public Dictionary<string, string> Fields;

            public string HexaDump;
            public string Name;

            public SBClass()
            {
                Name = NULL;
                Fields = new Dictionary<string, string>();
            }
        }


        #endregion
    }
}
