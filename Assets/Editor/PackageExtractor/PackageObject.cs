using System.Collections.Generic;
using Engine;
using Framework.PackageExtractor;
using SBAssemblies;

namespace Framework
{
    public class PackageObject
    {
        SBResourcePackage package;

        public string ClassName;
        public string ClassPath;
        public PackageDeserializer.SBClass Class = new PackageDeserializer.SBClass();
        public List<ObjectFlags> Flags = new List<ObjectFlags>();
        public int SerialOffset;
        public int SerialSize;
        public int ObjectFlags;

        public long ReaderOffset;

        public string ObjectName;
        public UObject Instance;
        public int ID;
        public string AbsoluteObjectNamePath;
        public string PackageName;

        static int idCounter;

        public static void ResetIDs()
        {
            idCounter = 0;
        }

        public static int NextID()
        {
            idCounter++;
            return idCounter;
        }
    }
}
