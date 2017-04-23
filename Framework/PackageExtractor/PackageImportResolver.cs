using System;
using System.Collections.Generic;
using TCosReborn.Application;
using TCosReborn.Framework.Utility;

namespace TCosReborn.Framework.PackageExtractor
{

    public static class PackageImportResolver
    {
        public static readonly Dictionary<string, object> ObjectsByName = new Dictionary<string, object>(System.StringComparer.OrdinalIgnoreCase);

        public static void Resolve(Queue<ImportLink> links)
        {
            Logger.Log("------------linking imports-----------");
            Logger.Log(links.Count + " objects to link");
            int unlinked = 0;
            int skipped = 0;
            while(links.Count > 0)
            {
                var link = links.Dequeue();
                var result = Resolve(link);
                switch (result)
                {
                    case ResolveResult.Skipped:
                        skipped++;
                        break;
                    case ResolveResult.Error:
                    case ResolveResult.NotFound:
                        unlinked++;
                    break;
                }
            }
            Logger.Log(skipped + " imported objects were skipped");
            Logger.LogWarning(unlinked + "imported objects could not be linked");
        }

        enum ResolveResult
        {
            Skipped,
            NotFound,
            Error,
            Success
        }

        static ResolveResult Resolve(ImportLink link)
        {
            if (link.AbsoluteObjectReference.StartsWith("SBParticles"))
            {
                //Logger.Log("Skipping: " + link.AbsoluteObjectReference);
                return ResolveResult.Skipped;
            }
            if (link.AbsoluteObjectReference.StartsWith("GlobalsTX"))
            {
                //Logger.Log("Skipping: " + link.AbsoluteObjectReference);
                return ResolveResult.Skipped;
            }
            object imported;
            if (ObjectsByName.TryGetValue(link.AbsoluteObjectReference, out imported))
            {
                try
                {
                    link.Link(imported);
                    return ResolveResult.Success;
                }
                catch (Exception e)
                {
                    if (link.fieldReference != null && link.fieldReference.FieldType.IsArray && !imported.GetType().IsArray)
                    {
                        var arr = link.fieldReference.GetValue(link.targetReference) as Array;
                        if (arr.Length <= link.indexReference)
                        {
                            var arrResized = Array.CreateInstance(arr.GetType().GetElementType(), link.indexReference + 1);
                            arr.CopyTo(arrResized, 0);
                            arr = arrResized;
                        }
                        try
                        {
                            arr.SetValue(imported, link.indexReference);
                            return ResolveResult.Success;
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex.Message);
                            return ResolveResult.Error;
                        }
                    }
                    Logger.LogError(e.Message);
                    return ResolveResult.Error;
                }
            }
            if (link.IsTypeReference)
            {
                var type = ReflectionHelper.GetTypeFromName(link.AbsoluteObjectReference);
                if (type != null)
                {
                    try
                    {
                        link.Link(type);
                        return ResolveResult.Success;
                    }
                    catch (Exception e)
                    {
                        Logger.LogWarning(e.Message);
                        return ResolveResult.Error;
                    }
                }
            }
            Logger.LogError("Could not find imported object: " + link.AbsoluteObjectReference);
            return ResolveResult.NotFound;
        }

        public static bool ResolveWithoutLogging(ImportLink link)
        {
            object imported;
            if (ObjectsByName.TryGetValue(link.AbsoluteObjectReference, out imported))
            {
                try
                {
                    link.Link(imported);
                    return true;
                }
                catch (Exception)
                {
                    if (link.fieldReference != null && link.fieldReference.FieldType.IsArray && !imported.GetType().IsArray)
                    {
                        var arr = link.fieldReference.GetValue(link.targetReference) as Array;
                        if (arr.Length <= link.indexReference)
                        {
                            var arrResized = Array.CreateInstance(arr.GetType().GetElementType(), link.indexReference + 1);
                            arr.CopyTo(arrResized, 0);
                            arr = arrResized;
                        }
                        try
                        {
                            arr.SetValue(imported, link.indexReference);
                            return true;
                        }
                        catch (Exception)
                        {
                            return false;
                        }
                    }
                    return false;
                }
            }
            if (link.IsTypeReference)
            {
                var type = ReflectionHelper.GetTypeFromName(link.AbsoluteObjectReference);
                if (type != null)
                {
                    try
                    {
                        link.Link(type);
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
