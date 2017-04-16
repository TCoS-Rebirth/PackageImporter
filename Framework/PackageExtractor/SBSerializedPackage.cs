﻿using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using TCosReborn.Application;

namespace TCosReborn.Framework.PackageExtractor
{
    [StructLayout(LayoutKind.Sequential, Size = 44, Pack = 1)]
    public struct GlobalHeader
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

    public struct ImportEntry
    {
        public int ClassPackageName;
        public int ClassName;
        public int PackageReference;
        public int ObjectName;
    }

    public struct ExportEntry
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

    public class SBSerializedPackage
    {
        GlobalHeader Header;

        string packageFileFullName;
        List<SBObject> PackageObjects;

        public SBSerializedPackage(string fileFullName)
        {
            packageFileFullName = fileFullName;
            Name = Path.GetFileNameWithoutExtension(fileFullName);
            if (Name != null) Name = Name.Replace("\0", string.Empty);
        }

        public string[] NameTable { get; set; }
        public ExportEntry[] ExportTable { get; set; }
        public ImportEntry[] ImportTable { get; set; }

        public List<SBObject> Objects
        {
            get { return PackageObjects; }
        }

        public string Name { get; }

        public void Log(string msg, int importance)
        {
            Logger.Log(msg);
        }

        public void Load()
        {
            var fileReader = new SBFileReader(packageFileFullName);
            fileReader.Read(out Header, Marshal.SizeOf(Header));
            fileReader.Seek(Header.NameOffset, SeekOrigin.Begin);

            NameTable = new string[Header.NameCount];
            //----------- READ NAME TABLE --------------

            #region NameTable

            for (uint k = 0; k < Header.NameCount; ++k)
            {
                int nameSize = fileReader.ReadByte();
                byte[] stringArray;
                stringArray = fileReader.ReadBytes(nameSize);
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

            PackageObjects = new List<SBObject>();

            var objectReader = new SBObjectReader(this);
            Log("Reading objects", 0);
            for (var i = 0; i < ExportTable.Length; i++)
            {
                var entry = ExportTable[i];
                var obj = objectReader.ReadObject(fileReader, entry, true);
                if (obj != null)
                {
                    PackageObjects.Add(obj);
                    entry.Obj = obj;
                }
            }
            Log(string.Format("{0} Objects read", PackageObjects.Count), 0);

            #endregion
        }

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
    }
}