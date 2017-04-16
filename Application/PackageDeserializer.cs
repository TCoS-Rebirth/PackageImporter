using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using TCosReborn.Framework.Common;
using TCosReborn.Framework.PackageExtractor;
using TCosReborn.Framework.Utility;

namespace TCosReborn.Application
{
    class PackageDeserializer
    {

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

        struct ImportEntry
        {
            public int ClassPackageName;
            public int ClassName;
            public int PackageReference;
            public int ObjectName;
        }

        struct ExportEntry
        {
            public int ClassReference;
            public int SuperReference;
            public int PackageReference;
            public int ObjectName;
            public int ObjectFlags;
            public int SerialSize;
            public int SerialOffset;
            public SBObject Obj;
        }

        GlobalHeader Header;

        public string[] NameTable { get; set; }
        ExportEntry[] ExportTable { get; set; }
        ImportEntry[] ImportTable { get; set; }

        List<SBPackageResource> exportedObjects = new List<SBPackageResource>();

        public string FindReferenceName(int reference, bool showAncestors = true)
        {
            if (reference > 0)
            {
                var result = NameTable[ExportTable[reference - 1].ObjectName];
                if (showAncestors)
                {
                    var ancestors = FindReferenceName(ExportTable[reference - 1].PackageReference);
                    if (ancestors != "null")
                        result = ancestors + "." + result;
                }
                return result.Replace("\0", string.Empty);
            }
            if (reference < 0)
            {
                var result = NameTable[ImportTable[-reference - 1].ObjectName];
                if (showAncestors)
                {
                    var ancestors = FindReferenceName(ImportTable[-reference - 1].PackageReference);
                    if (ancestors != "null")
                        result = ancestors + "." + result;
                }

                return result.Replace("\0", string.Empty);
            }
            return "null";
        }

        public void Log(string msg, int importance)
        {
            Logger.Log(msg);
        }

        public SBResourcePackage DeserializePackage(string filePath)
        {
            var fileReader = new SBFileReader(filePath);
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
            Log(string.Format("NameTable: {0} names read", NameTable.Length), 0);

            #endregion

            //------------- READ IMPORT TABLE -----------------------------

            #region ImportTable

            ImportTable = new ImportEntry[Header.ImportCount];
            fileReader.Seek(Header.ImportOffset, SeekOrigin.Begin);
            for (uint k = 0; k < Header.ImportCount; ++k)
            {
                ImportEntry entry;
                entry.ClassPackageName = fileReader.ReadIndex();
                entry.ClassName = fileReader.ReadIndex();
                entry.PackageReference = fileReader.ReadInt32();
                entry.ObjectName = fileReader.ReadIndex();

                ImportTable[k] = entry;
            }
            Log(string.Format("ImportTable: {0} imports read", ImportTable.Length), 0);

            #endregion

            //----------- READ EXPORT TABLE ------------------------

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
                    ObjectName = fileReader.ReadIndex(),
                    ObjectFlags = fileReader.ReadInt32(),
                    SerialSize = fileReader.ReadIndex()
                };
                if (entry.SerialSize > 0)
                {
                    entry.SerialOffset = fileReader.ReadIndex();
                }
                ExportTable[k] = entry;
            }
            Log(string.Format("ExportTable: {0} exports read", ExportTable.Length), 0);

            #endregion

            //--------------- READ ALL OBJECTS EXPORTED -----------------------

            #region Objects

            exportedObjects.Clear();

            Log("Reading objects", 0);
            for (var i = 0; i < ExportTable.Length; i++)
            {
                var entry = ExportTable[i];
                var obj = ReadObject(fileReader, entry);
                if (obj != null)
                {
                    exportedObjects.Add(obj);
                }
            }
            Log(string.Format("{0} Objects read", exportedObjects.Count), 0);

            #endregion

            var pkg = new SBResourcePackage
            {
                ReferencePackageName = Path.GetFileNameWithoutExtension(filePath),
                exports = exportedObjects
            };
            //pkg
            return pkg;
        }

        SBPackageResource ReadObject(SBFileReader fileReader, ExportEntry entry, bool showAncestors = true)
        {
            var activeObject = new SBObject
            {
                Class = new SBClass(),
                Name = NameTable[entry.ObjectName].Replace("\0", string.Empty),
                Flags = new List<ObjectFlags>(),
                Properties = new Dictionary<string, SBProperty>(StringComparer.OrdinalIgnoreCase),
                ClassName = FindReferenceName(entry.ClassReference, showAncestors).Replace("\0", string.Empty),
                Package = FindReferenceName(entry.PackageReference, showAncestors),
                Size = entry.SerialSize,
                SuperClassName = FindReferenceName(entry.SuperReference, showAncestors),
                PackageID = entry.PackageReference
            };

            SBPackageResource realObject = null;

            var hasExecutionStack = false;

            //Detect stack
            if ((entry.ObjectFlags & (int)ObjectFlags.RF_HasStack) != 0)
            {
                hasExecutionStack = true;
                activeObject.Flags.Add(ObjectFlags.RF_HasStack);
            }

            //Currently we cannot read null class
            if (entry.SerialSize <= 0 || activeObject.ClassName == "null") return null;

            //Read UObject data if present

            fileReader.Seek(entry.SerialOffset, SeekOrigin.Begin);

            foreach (var s in ReflectionHelper.skippableObjects)
            {
                if (activeObject.ClassName.Equals(s, StringComparison.OrdinalIgnoreCase))
                {
                    fileReader.Seek(entry.SerialSize, SeekOrigin.Current);
                    return null;
                }
            }

            var realType = ReflectionHelper.GetTypeFromName(activeObject.ClassName);
            ReflectionHelper.ReflectedRessourceType rType;
            if (realType != null && ReflectionHelper.TryGetTypeInfo(realType, out rType))
            {
                realObject = rType.CreateInstance();
            }

            if (realObject == null)
            {
                Logger.LogError("Could not create instance from class name: " + activeObject.ClassName);
                Console.ReadKey();
                return null;
            }
            realObject.ReferenceObjectName = activeObject.Name;

            //If UObject has a stack, read it but do nothing with it
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

            ReadProperties(fileReader, realObject, entry, showAncestors);

            //Try to read class

            string className;

            if (activeObject.ClassName.Contains("("))
            {
                className = activeObject.ClassName.Substring(0, activeObject.ClassName.IndexOf("(", StringComparison.Ordinal) - 1).Trim();
            }
            else
            {
                className = activeObject.ClassName;
            }

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
                case "null":
                case "None":
                    activeObject.Class = ReadNullClass(fileReader);
                    break;
                default:
                    //Log("Encountered unknown class while reading properties", 1);
                    break;
            }
            return realObject;
        }

        void ReadProperties(SBFileReader fileReader, SBPackageResource activeObject, ExportEntry entry, bool showAncestors)
        {
            //.::Loop through all the properties of the current object::.
            var returnBytesRead = 0;
            do
            {
                var activeProperty = ReadProperty(activeObject, fileReader, ref returnBytesRead);
                if (activeProperty == null)
                {
                    break;
                }
                //int fixedSize;
                //if (activeProperty.IsPartOfFixedArray && PackageTypeHelper.GetFixedArraySize(activeObject.ClassName, activeProperty.Name, out fixedSize))
                //{
                //    bool breakHere = true;
                //}
                var bytesRead = ReadPropertyValue(activeObject, fileReader, activeProperty, showAncestors);
                returnBytesRead += bytesRead;
                bool success;
                var key = activeProperty.Name;
                var cpt = 0;
                do
                {
                    try
                    {
                        //activeObject.Properties.Add(key, activeProperty);
                        success = true;
                    }
                    catch (ArgumentException)
                    {
                        success = false;
                        key = key + cpt;
                        ++cpt;
                    }
                } while (!success);
            } while (fileReader.Position < entry.SerialOffset + entry.SerialSize);
            if (returnBytesRead < entry.SerialSize)
            {
                bool breakHere = true;
                Console.WriteLine("skipping problematic entry");
                var diff = entry.SerialSize - returnBytesRead;
                fileReader.Seek(diff, SeekOrigin.Current);
            }
        }

        SBProperty ReadProperty(SBPackageResource activeObject, SBFileReader fileReader, ref int returnBytesRead, PropertyType overrideType = PropertyType.UnknownProperty)
        {
            var readIndexBytes = 0;
            var activeProperty = new SBProperty();
            var propertyNameIndex = fileReader.ReadIndex(ref readIndexBytes);
            returnBytesRead += readIndexBytes;
            try
            {
                activeProperty.Name = NameTable[propertyNameIndex].Replace("\0", string.Empty);
                if (activeProperty.Name.StartsWith("KeyPos", StringComparison.OrdinalIgnoreCase) && activeObject.ReferenceObjectName.StartsWith("Mover50", StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Log("fixme");
                }
                //activeProperty.Name = FindReferenceName(propertyNameIndex).Replace("\0", string.Empty);
            }
            catch (IndexOutOfRangeException)
            {
                Log("Error: failed to read a Property's name on: " + activeObject.ReferenceObjectName, 2);
                Console.ReadKey();
                return null;
            }

            //Detect end of property list
            if (activeProperty.Name == "DRFORTHEWIN" || activeProperty.Name == "None")
                return null;

            //Read the property info byte
            var infoByte = fileReader.ReadByte();
            returnBytesRead += 1;

            //Parse property info byte
            var type = (byte)(infoByte & 0x0F);
            var size = (byte)((infoByte & 0x70) >> 4);
            var arrayFlag = (byte)(infoByte & 0x80);

            if (overrideType != PropertyType.UnknownProperty)
            {
                activeProperty.Type = overrideType;
            }
            else
            {
                activeProperty.Type = (PropertyType)type;
            }

            //Display value if not array flag but boolean value
            if (activeProperty.Type == PropertyType.BooleanProperty)
            {
                activeProperty.Value = arrayFlag > 0 ? "True" : "False";
            }
            else if (arrayFlag != 0)
            {
                int arrayIndex /*= fileReader.ReadByte()*/;
                var b = fileReader.ReadByte();
                returnBytesRead += 1;
                if ((b & 0x80) == 0)
                {
                    arrayIndex = b;
                }
                else if ((b & 0xC0) == 0x80)
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
                activeProperty.IsPartOfFixedArray = true;
                activeProperty.ArrayIndex = arrayIndex;
            }

            //If type = struct, you have to read its name (but not always)
            if (activeProperty.Type == PropertyType.StructProperty)
            {
                var structNameIndex = fileReader.ReadIndex(ref readIndexBytes);
                returnBytesRead += readIndexBytes;
                activeProperty.StructName = NameTable[structNameIndex].Replace("\0", string.Empty);
            }
            //if (activeProperty.Type != PropertyType.BooleanProperty)
            //{
            var realSize = 0;
            //Read real size (see doc)
            if (size == 0)
                realSize = 1;
            else if (size == 1)
                realSize = 2;
            else if (size == 2)
                realSize = 4;
            else if (size == 3)
                realSize = 12;
            else if (size == 4)
                realSize = 16;
            else if (size == 5)
            {
                realSize = fileReader.ReadByte();
                returnBytesRead += 1;
            }
            else if (size == 6)
            {
                realSize = fileReader.ReadInt16();
                returnBytesRead += 2;
            }
            else if (size == 7)
            {
                realSize = fileReader.ReadInt32();
                returnBytesRead += 4;
            }

            activeProperty.Size = realSize.ToString();
            activeProperty.serialSize = realSize;
            //}
            //else
            //{
            //    activeProperty.Size = "1";
            //    activeProperty.serialSize = 1;
            //}
            return activeProperty;
        }

        int ReadPropertyValue(SBPackageResource activeObject, SBFileReader fileReader, SBProperty activeProperty, bool showAncestors)
        {
            var localBytesRead = 0;
            //Handle specific properties
            var readIndexBytes = 0;

            switch (activeProperty.Type)
            {
                case PropertyType.ByteProperty:
                    activeProperty.Value = fileReader.ReadByte().ToString();
                    //try parsing enum from custom definition
                    var enums = Assembly.GetAssembly(typeof(LocalizedString)).GetTypes().Where(t => t.IsEnum && t.IsPublic).ToList();
                    foreach (var et in enums)
                    {
                        if (et.Name.Equals(activeProperty.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            var nameIndexer = activeProperty.GetValue<int>();
                            var value = (Enum)Enum.ToObject(et, nameIndexer);
                            activeProperty.EnumValueName = value.ToString();
                            break;
                        }
                    }
                    //
                    localBytesRead += 1;
                    break;

                case PropertyType.IntegerProperty:
                    activeProperty.Value = fileReader.ReadInt32().ToString();
                    localBytesRead += 4;
                    break;

                case PropertyType.FloatProperty:
                    activeProperty.Value = fileReader.ReadFloat().ToString();
                    localBytesRead += 4;
                    break;

                case PropertyType.NameProperty:
                    activeProperty.Value = NameTable[fileReader.ReadIndex(ref readIndexBytes)].Replace("\0", string.Empty);
                    localBytesRead += readIndexBytes;
                    break;
                case PropertyType.VectorProperty:
                    activeProperty.Value = fileReader.ReadFloat() + "," + fileReader.ReadFloat() + "," + fileReader.ReadFloat();
                    localBytesRead += 12;
                    break;
                case PropertyType.RotatorProperty:
                    activeProperty.Value = fileReader.ReadInt32() + "," + fileReader.ReadInt32() + "," + fileReader.ReadInt32();
                    localBytesRead += 12;
                    break;
                case PropertyType.StrProperty:
                    var stringSize = fileReader.ReadIndex(ref readIndexBytes);
                    localBytesRead += readIndexBytes;
                    var stringBytes = fileReader.ReadBytes(stringSize);
                    var stringValue = Encoding.ASCII.GetString(stringBytes).Replace("\0", string.Empty);
                    activeProperty.Value = stringValue;
                    localBytesRead += stringSize;
                    break;

                case PropertyType.ObjectProperty:
                    var objectReference = fileReader.ReadIndex(ref readIndexBytes);
                    activeProperty.Value = FindReferenceName(objectReference, showAncestors) /*+ " (reference)"*/;
                    localBytesRead += readIndexBytes;
                    break;

                //Structs are a special case
                case PropertyType.CustomStruct:
                case PropertyType.StructProperty:
                    if (activeProperty.StructName == "Vector")
                    {
                        activeProperty.Value = fileReader.ReadFloat() + "," + fileReader.ReadFloat() + "," + fileReader.ReadFloat();
                        localBytesRead += 12;
                    }
                    else if (activeProperty.StructName == "Rotator")
                    {
                        activeProperty.Value = fileReader.ReadInt32() + "," + fileReader.ReadInt32() + "," + fileReader.ReadInt32();
                        localBytesRead += 12;
                    }
                    else if (activeProperty.StructName == "Color")
                    {
                        activeProperty.Value = "(R=" + fileReader.ReadByte() + "; G=" + fileReader.ReadByte() + "; B=" + fileReader.ReadByte() + "; A=" +
                                               fileReader.ReadByte() + ")";
                        localBytesRead += 4;
                    }
                    else if (activeProperty.StructName == "LightHSB")
                    {
                        activeProperty.Value = "(H=" + fileReader.ReadByte() + "; S=" + fileReader.ReadByte() + "; B=" + fileReader.ReadByte() + ")";
                        localBytesRead += 3;
                    }
                    else if (activeProperty.StructName == "LocalizedString")
                    {
                        activeProperty.Value = fileReader.ReadInt32().ToString();
                        localBytesRead += 4;
                    }
                    else if (activeProperty.StructName == "Slot")
                    {
                        activeProperty.Value = "Rank: " + fileReader.ReadInt32() + " SlotType: " + fileReader.ReadByte();
                        localBytesRead += 5;
                    }
                    else if (activeProperty.StructName == "Scale")
                    {
                        int vBytesRead = 0;
                        var vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                        activeProperty.Value += fileReader.ReadByte();
                        localBytesRead += 1;
                    }
                    else if (activeProperty.StructName == "Box")
                    {
                        int vBytesRead = 0;
                        var vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                        vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                        activeProperty.Value += fileReader.ReadByte();
                        localBytesRead += 1;
                    }
                    else if (activeProperty.StructName == "FloatBox")
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            fileReader.ReadFloat();
                        }
                        localBytesRead += 16;
                    }
                    else if (activeProperty.StructName == "IntBox")
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            fileReader.ReadFloat();
                        }
                        localBytesRead += 16;
                    }
                    else if (activeProperty.StructName == "Plane")
                    {
                        int vBytesRead = 0;
                        var vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                        fileReader.ReadFloat();
                        localBytesRead += 4;
                    }
                    else if (activeProperty.StructName == "Range")
                    {
                        fileReader.ReadFloat();
                        fileReader.ReadFloat();
                        localBytesRead += 8;
                    }
                    else if (activeProperty.StructName == "RangeVector")
                    {
                        int vBytesRead = 0;
                        var vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                        vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                        vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                    }
                    else if (activeProperty.StructName == "Quat")
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            fileReader.ReadFloat();
                        }
                        localBytesRead += 16;
                    }
                    else if (activeProperty.StructName == "Coords")
                    {
                        int vBytesRead = 0;
                        var vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                        vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                        vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                        vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                    }
                    else if (activeProperty.StructName == "CompressedPosition")
                    {
                        int vBytesRead = 0;
                        var vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                        vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                        vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                    }
                    else if (activeProperty.StructName == "Matrix")
                    {
                        int vBytesRead = 0;
                        var vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                        vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                        vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                        vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                    }
                    else if (activeProperty.StructName == "BoundingVolume")
                    {
                        int vBytesRead = 0;
                        var vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                        vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                        activeProperty.Value += fileReader.ReadByte();
                        localBytesRead += 1;
                        vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                        localBytesRead += vBytesRead;
                        localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                    }
                    else if (activeProperty.StructName == "Guid")
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            fileReader.ReadInt32();
                        }
                        localBytesRead += 16;
                    }
                    else if (activeProperty.StructName == "InterpCurvePoint")
                    {
                        fileReader.ReadFloat();
                        fileReader.ReadFloat();
                        localBytesRead += 8;
                    }
                    //else if (activeProperty.StructName == "RangedSpawn")
                    //{
                    //    fileReader.ReadFloat();
                    //    localBytesRead += 4;
                    //    int vBytesRead = 0;
                    //    var vecProp = ReadProperty(activeObject, fileReader, ref vBytesRead);
                    //    localBytesRead += vBytesRead;
                    //    localBytesRead += ReadPropertyValue(activeObject, fileReader, vecProp, false);
                    //}
                    else if (activeProperty.StructName == "InterpCurve")
                    {
                        SBProperty structProp; //correct? not sure
                        do
                        {
                            var structBytesRead = 0;
                            structProp = ReadProperty(activeObject, fileReader, ref structBytesRead);
                            localBytesRead += structBytesRead;
                            if (structProp == null)
                            {
                                break;
                            }
                            if (structProp.Type == PropertyType.ArrayProperty && activeProperty.StructName.Length > 1)
                            {
                                structProp.StructName = activeProperty.StructName;
                            }
                            localBytesRead += ReadPropertyValue(activeObject, fileReader, structProp, showAncestors);
                            activeProperty.Array.Add(structProp.Name, structProp);
                        } while (structProp != null);
                    }
                    else if (activeProperty.StructName == "PointRegion")
                    {
                        var objRef = fileReader.ReadIndex(ref readIndexBytes);
                        activeProperty.Value = FindReferenceName(objRef, showAncestors) /*+ " (reference)"*/;
                        localBytesRead += readIndexBytes;
                        fileReader.ReadInt32();
                        localBytesRead += 4; //iLeaf
                        fileReader.ReadByte();
                        localBytesRead += 1; //ZoneNumber
                    }
                    else
                    {
                        if (activeProperty.StructName.Length > 0)
                        {
                            Console.WriteLine("Unhandled custom struct: " + activeProperty.StructName);
                        }
                        SBProperty structProp;
                        do
                        {
                            var structBytesRead = 0;
                            structProp = ReadProperty(activeObject, fileReader, ref structBytesRead);
                            localBytesRead += structBytesRead;
                            if (structProp == null)
                            {
                                break;
                            }
                            if (structProp.Type == PropertyType.ArrayProperty && activeProperty.StructName.Length > 1)
                            {
                                structProp.StructName = activeProperty.StructName;
                            }
                            localBytesRead += ReadPropertyValue(activeObject, fileReader, structProp, showAncestors);
                            activeProperty.Array.Add(structProp.Name, structProp);
                        } while (structProp != null);
                    }
                    break;
                case PropertyType.ArrayProperty:
                    PropertyType insideType;
                    string insideName;
                    var classToSearch = (activeProperty.Type == PropertyType.ArrayProperty && activeProperty.StructName.Length > 1) ? activeProperty.StructName : string.Format("{0}.{1}", activeObject.GetType().Namespace, activeObject.GetType().Name);
                    if (ReflectionHelper.ReflectArrayType(classToSearch, activeProperty.Name, out insideType, out insideName))
                    {
                        var arraySize = fileReader.ReadIndex(ref readIndexBytes);
                        localBytesRead += readIndexBytes;
                        for (var i = 0; i < arraySize; i++)
                        {
                            var propBytesRead = 0;
                            SBProperty insideArrayProp;
                            if (insideType == PropertyType.StructProperty)
                            {
                                insideArrayProp = ReadProperty(activeObject, fileReader, ref propBytesRead, insideType);
                                localBytesRead += propBytesRead;
                            }
                            else
                            {
                                insideArrayProp = new SBProperty { Type = insideType };
                                if (insideType == PropertyType.CustomStruct)
                                {
                                    insideArrayProp.StructName = insideName;
                                }
                                else
                                {
                                    insideArrayProp.Name = insideName;
                                }
                            }
                            var currentPropSize = ReadPropertyValue(activeObject, fileReader, insideArrayProp, showAncestors);
                            localBytesRead += currentPropSize;
                            insideArrayProp.Size = currentPropSize.ToString();
                            activeProperty.Array.Add(i.ToString(), insideArrayProp);
                        }
                        if (localBytesRead < activeProperty.serialSize)
                        {
                            activeProperty.hasSkippedBytes = true;
                        }
                        activeProperty.Size = arraySize.ToString();
                    }
                    else
                    {
                        Log(string.Format("ArrayDefinition not found for ({2}){0} - {1}, skipping", activeObject.ReferenceObjectName, activeProperty.Name, activeObject.GetType()), 1);
                        fileReader.Seek(activeProperty.serialSize, SeekOrigin.Current);
                    }
                    break;
                //case PropertyType.FixedArrayProperty:
                //    SBProperty fixArrayProp = null;
                //    do
                //    {
                //        var structBytesRead = 0;
                //        fixArrayProp = ReadProperty(activeObject, fileReader, PackageTypeHelper, showAncestors, ref structBytesRead);
                //        localBytesRead += structBytesRead;
                //        if (fixArrayProp == null)
                //        {
                //            break;
                //        }
                //        if (fixArrayProp.Type == PropertyType.ArrayProperty && activeProperty.StructName.Length > 1)
                //        {
                //            fixArrayProp.StructName = activeProperty.StructName;
                //        }
                //        localBytesRead += ReadPropertyValue(activeObject, fileReader, fixArrayProp, PackageTypeHelper, showAncestors);
                //        activeProperty.Array.Add(fixArrayProp.Name, fixArrayProp);
                //    } while (fixArrayProp != null);
                //    break;
                default:
                    fileReader.Seek(activeProperty.serialSize, SeekOrigin.Current);
                    break;
            }
            return localBytesRead;
        }

        #region Unreal Specific
        SBClass ReadFieldClass(SBFileReader reader)
        {
            var superField = reader.ReadIndex();
            var next = reader.ReadIndex();
            var field = new SBClass();
            field.Name = "Field";
            field.Fields.Add("SuperField", superField.ToString());
            field.Fields.Add("Next", next.ToString());
            return field;
        }

        SBClass ReadConstClass(SBFileReader reader)
        {
            var constClass = new SBClass();
            constClass.Ancestor = ReadFieldClass(reader);
            constClass.Name = "Const";

            var size = reader.ReadIndex();
            var constant = Encoding.ASCII.GetString(reader.ReadBytes(size)).Replace("\0", string.Empty);
            constClass.Fields.Add("Size", size.ToString());
            constClass.Fields.Add("Constant", constant);
            return constClass;
        }

        SBClass ReadEnumClass(SBFileReader reader)
        {
            var enumClass = new SBClass();
            enumClass.Name = "Enum";
            enumClass.Ancestor = ReadFieldClass(reader);
            var arraySize = reader.ReadIndex();
            enumClass.Fields.Add("ArraySize", arraySize.ToString());
            for (var i = 0; i < arraySize; ++i)
            {
                enumClass.Fields.Add("ElementName" + i, NameTable[reader.ReadIndex()].Replace("\0", string.Empty));
            }

            return enumClass;
        }

        SBClass ReadPropertyClass(SBFileReader reader)
        {
            var property = new SBClass();
            property.Name = "Property";
            property.Ancestor = ReadFieldClass(reader);

            var arrayDimension = reader.ReadInt16();
            var elementSize = reader.ReadInt16();
            var propertyFlags = reader.ReadInt32();
            var category = reader.ReadIndex();
            property.Fields.Add("ArrayDimension", arrayDimension.ToString());
            property.Fields.Add("ElementSize", elementSize.ToString());
            property.Fields.Add("PropertyFlags", propertyFlags.ToString());
            property.Fields.Add("Category", NameTable[category].Replace("\0", string.Empty));
            if ((propertyFlags & (int)PropertyFlags.CPF_Net) != 0)
            {
                int replicationOffset = reader.ReadInt16();
                property.Fields.Add("Replication Offset", replicationOffset.ToString());
            }

            return property;
        }

        SBClass ReadBytePropertyClass(SBFileReader reader)
        {
            var byteProperty = new SBClass();
            byteProperty.Name = "ByteProperty";
            byteProperty.Ancestor = ReadPropertyClass(reader);
            var enumType = reader.ReadIndex();
            byteProperty.Fields.Add("EnumType", enumType.ToString());

            return byteProperty;
        }

        SBClass ReadObjectPropertyClass(SBFileReader reader)
        {
            var objectProperty = new SBClass();
            objectProperty.Name = "ObjectProperty";
            objectProperty.Ancestor = ReadPropertyClass(reader);
            var objectType = reader.ReadIndex();
            objectProperty.Fields.Add("ObjectType", FindReferenceName(objectType));

            return objectProperty;
        }

        SBClass ReadFixedArrayPropertyClass(SBFileReader reader)
        {
            var fixedArrayProperty = new SBClass();
            fixedArrayProperty.Name = "FixedArrayProperty";
            fixedArrayProperty.Ancestor = ReadPropertyClass(reader);

            var inner = reader.ReadIndex();
            var count = reader.ReadIndex();

            fixedArrayProperty.Fields.Add("Inner", FindReferenceName(inner));
            fixedArrayProperty.Fields.Add("Count", FindReferenceName(count));

            return fixedArrayProperty;
        }

        SBClass ReadArrayPropertyClass(SBFileReader reader)
        {
            var arrayProperty = new SBClass();
            arrayProperty.Name = "ArrayProperty";
            arrayProperty.Ancestor = ReadPropertyClass(reader);

            var inner = reader.ReadIndex();

            arrayProperty.Fields.Add("Inner", FindReferenceName(inner));

            return arrayProperty;
        }

        SBClass ReadMapPropertyClass(SBFileReader reader)
        {
            var mapProperty = new SBClass();
            mapProperty.Name = "MapProperty";
            mapProperty.Ancestor = ReadPropertyClass(reader);

            var key = reader.ReadIndex();
            var value = reader.ReadIndex();

            mapProperty.Fields.Add("Key", key.ToString());
            mapProperty.Fields.Add("Value", value.ToString());

            return mapProperty;
        }

        SBClass ReadClassPropertyClass(SBFileReader reader)
        {
            var classProperty = new SBClass();
            classProperty.Name = "ClassProperty";
            classProperty.Ancestor = ReadPropertyClass(reader);

            var mclass = reader.ReadIndex();
            classProperty.Fields.Add("Class", NameTable[mclass].Replace("\0", string.Empty));

            return classProperty;
        }

        SBClass ReadStructPropertyClass(SBFileReader reader)
        {
            var structProperty = new SBClass();
            structProperty.Name = "StructProperty";
            structProperty.Ancestor = ReadPropertyClass(reader);

            var structType = reader.ReadIndex();

            structProperty.Fields.Add("StructType", structType.ToString());

            return structProperty;
        }

        SBClass ReadIntPropertyClass(SBFileReader reader)
        {
            var intProperty = new SBClass();
            intProperty.Name = "IntProperty";
            intProperty.Ancestor = ReadPropertyClass(reader);

            return intProperty;
        }

        SBClass ReadBoolPropertyClass(SBFileReader reader)
        {
            var boolProperty = new SBClass();
            boolProperty.Name = "BoolProperty";
            boolProperty.Ancestor = ReadPropertyClass(reader);

            return boolProperty;
        }

        SBClass ReadFloatPropertyClass(SBFileReader reader)
        {
            var floatProperty = new SBClass();
            floatProperty.Name = "FloatProperty";
            floatProperty.Ancestor = ReadPropertyClass(reader);

            return floatProperty;
        }

        SBClass ReadNamePropertyClass(SBFileReader reader)
        {
            var nameProperty = new SBClass();
            nameProperty.Name = "NameProperty";
            nameProperty.Ancestor = ReadPropertyClass(reader);

            return nameProperty;
        }

        SBClass ReadStrPropertyClass(SBFileReader reader)
        {
            var strProperty = new SBClass();
            strProperty.Name = "StrProperty";
            strProperty.Ancestor = ReadPropertyClass(reader);

            return strProperty;
        }

        SBClass ReadStringPropertyClass(SBFileReader reader)
        {
            var stringProperty = new SBClass();
            stringProperty.Name = "StringProperty";
            stringProperty.Ancestor = ReadPropertyClass(reader);

            return stringProperty;
        }

        SBClass ReadStructClass(SBFileReader reader)
        {
            var structClass = new SBClass();
            structClass.Name = "Struct";
            structClass.Ancestor = ReadFieldClass(reader);
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
            structClass.Fields.Add("FriendlyName", NameTable[friendlyName].Replace("\0", string.Empty));
            structClass.Fields.Add("Line", line.ToString());
            structClass.Fields.Add("TextPos", textPos.ToString());
            structClass.Fields.Add("ScriptSize", scriptSize.ToString());

            return structClass;
        }

        SBClass ReadFunctionClass(SBFileReader reader)
        {
            var function = new SBClass();
            function.Name = "Function";
            function.Ancestor = ReadStructClass(reader);

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
            var state = new SBClass();
            state.Name = "State";
            state.Ancestor = ReadStructClass(reader);

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
            var nullClass = new SBClass();
            nullClass.Name = "null";
            nullClass.Ancestor = ReadStateClass(reader);

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
            nullClass.Fields.Add("Class Config Name", NameTable[classConfigName].Replace("\0", string.Empty));

            return nullClass;
        }
        #endregion

    }
}
