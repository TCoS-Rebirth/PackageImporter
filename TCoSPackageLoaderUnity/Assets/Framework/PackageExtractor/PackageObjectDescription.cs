using Engine;

namespace Framework
{
    public class PackageObjectDescription
    {
        public UObject Obj;
        public int ID;
        public string AbsoluteObjectPath;
        public string InternalPackagePath;

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
