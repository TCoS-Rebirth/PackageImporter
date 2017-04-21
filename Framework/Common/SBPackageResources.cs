using System.Collections.Generic;

namespace TCosReborn.Framework.Common
{
    public static class SBPackageResources
    {
        public static Dictionary<string, object> ObjectsByName = new Dictionary<string, object>(System.StringComparer.OrdinalIgnoreCase);

        public static Dictionary<int, object> ObjectsByResourceID = new Dictionary<int, object>();

    }
}
