using System.Collections.Generic;

namespace TCosReborn
{
    [System.Serializable] public class SBResourcePackage: SBPackageResource
    {
        public string Name;
        public Dictionary<string, object> Resources = new Dictionary<string, object>();

        public override string ToString()
        {
            return string.Format("{0} (SBResourcePackage)", Name);
        }
    }
}
