using System.Collections.Generic;
using TCosReborn.Application;
using TCosReborn.Framework.Utility;

namespace TCosReborn.Framework.PackageExtractor
{

    public static class GameplayPackageResolver
    {
        public static void Resolve(Dictionary<string, object> packages, List<PackageDeserializer.LinkerLink> links)
        {
            Logger.Log("------------linking imports-----------");
            Logger.Log(links.Count + " objects to link");
            System.Console.ReadKey();
            int unlinked = 0;
            var queue = new Queue<PackageDeserializer.LinkerLink>(links);
            while(queue.Count > 0)
            {
                var link = queue.Dequeue();
                object imported;
                if (packages.TryGetValue(link.AbsoluteObjectReference, out imported))
                {
                    try
                    {
                        link.Link(imported);
                    }
                    catch (System.Exception e)
                    {
                        //if (!link.AbsoluteObjectReference.StartsWith("ItemsBrokenGP."))
                        //{
                            Logger.LogError(e.Message);
                        unlinked++;
                        //}
                    }
                }
                else
                {
                    if (link.IsTypeReference)
                    {
                        var type = ReflectionHelper.GetTypeFromName(link.AbsoluteObjectReference);
                        if (type != null)
                        {
                            var success = false;
                            try
                            {
                                link.Link(type);
                                success = true;
                            }
                            catch(System.Exception e)
                            {
                                Logger.LogError(e.Message);
                                unlinked++;
                            }
                            if (success)
                            {
                                continue;
                            }
                        }
                    }
                    Logger.LogError("Could not link imported object: " + link.AbsoluteObjectReference);
                    unlinked++;
                }
            }
            Logger.LogWarning(unlinked + " objects could not be linked");
            System.Console.ReadKey();
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
