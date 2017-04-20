using System.Collections.Generic;
using TCosReborn.Application;

namespace TCosReborn.Framework.PackageExtractor
{

    public static class GameplayPackageResolver
    {
        public static void Resolve(Dictionary<string, object> packages, List<PackageDeserializer.LinkerLink> links)
        {
            var queue = new Queue<PackageDeserializer.LinkerLink>(links);
            while(queue.Count > 0)
            {
                var link = queue.Dequeue();
                object imported;
                if (packages.TryGetValue(string.Format("{0}.{1}", link.SelfPackageName,link.ObjName), out imported))
                {
                    link.Link(imported);
                    Logger.LogOk("Reference found");
                }
                else if (packages.TryGetValue(string.Format("{0}.{1}.{2}", link.SelfPackageName, link.PackageRefName, link.ObjName), out imported))
                {
                    link.Link(imported);
                    Logger.LogOk("Reference found");
                }
                else
                {
                    if (packages.TryGetValue(string.Format("{0}.{1}", link.PackageRefName, link.ObjName), out imported))
                    {
                        link.Link(imported);
                        Logger.LogOk("Reference found");
                    }
                    else
                    {
                        Logger.LogError("Reference not found: " + link.ObjName);
                    }
                }
            }
        }

        //readonly char[] split = { '.' };
        //void ResolveItem(PackageDeserializer.LinkerLink link, Dictionary<string, SBResourcePackage> packages)
        //{
        //    var searchedItem = link.ObjName;
        //    var parts = searchedItem.Split(split, StringSplitOptions.RemoveEmptyEntries);
        //    if (parts.Length > 1)
        //    {
        //        //Logger.Log("import from pkg or subpkg");
        //        if (parts[0].Contains("GP"))
        //        {
        //            Logger.Log("pkg is external: "+parts[0]);
        //        }
        //        else
        //        {
        //            Logger.Log("pkg is internal: "+parts[0]);
        //        }
        //        //SBResourcePackage pkg;
        //        //if (!packages.TryGetValue(parts[0], out pkg))
        //        //{
        //        //    Logger.LogError(string.Format("Package ({0}) not found for: {1}", parts[0], searchedItem));
        //        //}
        //    }
        //    else
        //    {
        //        Logger.Log("import from own pkg level");
        //    }
        //}
    }
}
