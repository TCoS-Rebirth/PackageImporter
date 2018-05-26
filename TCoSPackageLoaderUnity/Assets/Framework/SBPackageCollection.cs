using System.Collections.Generic;
using System.Runtime.Serialization;
using TCosReborn;

namespace Framework
{
    [DataContract]
    public class SBPackageCollection
    {
        public List<SBResourcePackage> Packages = new List<SBResourcePackage>();
    }
}
