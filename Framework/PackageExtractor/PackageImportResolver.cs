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
                        if (link.fieldReference != null && link.fieldReference.FieldType.IsArray && !imported.GetType().IsArray)
                        {
                            var arr = link.fieldReference.GetValue(link.targetReference) as System.Array;
                            if (arr.Length <= link.indexReference)
                            {
                                var arrResized = System.Array.CreateInstance(arr.GetType().GetElementType(), link.indexReference + 1);
                                arr.CopyTo(arrResized, 0);
                                arr = arrResized;
                            }
                            bool success = false;
                            try
                            {
                                arr.SetValue(imported, link.indexReference);
                                success = true;
                            }
                            catch (System.Exception ex)
                            {
                                Logger.LogError(ex.Message);
                                unlinked++;
                            }
                            if (success)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            Logger.LogError(e.Message);
                            unlinked++;
                        }
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
                    Logger.LogError("Could not find imported object: " + link.AbsoluteObjectReference);
                    unlinked++;
                }
            }
            Logger.LogWarning(unlinked + "imported objects could not be linked");
        }
    }
}
