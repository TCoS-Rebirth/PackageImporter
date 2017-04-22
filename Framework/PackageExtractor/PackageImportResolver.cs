using System.Collections.Generic;
using TCosReborn.Application;
using TCosReborn.Framework.Utility;

namespace TCosReborn.Framework.PackageExtractor
{

    public static class PackageImportResolver
    {
        public static void Resolve(Dictionary<string, object> packages, Queue<PackageDeserializer.LinkerLink> links)
        {
            Logger.Log("------------linking imports-----------");
            Logger.Log(links.Count + " objects to link");
            int unlinked = 0;
            while(links.Count > 0)
            {
                var link = links.Dequeue();
                if (!Resolve(packages, link)) unlinked++;               
            }
            Logger.LogWarning(unlinked + "imported objects could not be linked");
        }

        static bool Resolve(Dictionary<string, object> packages, PackageDeserializer.LinkerLink link)
        {
            if (link.SkipTestClassReference.Length > 0 && ReflectionHelper.CanBeSkipped(link.SkipTestClassReference) || link.AbsoluteObjectReference.StartsWith("SBParticles"))
            {
                //Logger.Log("Skipping: " + link.AbsoluteObjectReference + " as it is: " + link.SkipTestClassReference);
                return true;
            }
            object imported;
            if (packages.TryGetValue(link.AbsoluteObjectReference, out imported))
            {
                try
                {
                    link.Link(imported);
                    return true;
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
                        try
                        {
                            arr.SetValue(imported, link.indexReference);
                            return true;
                        }
                        catch (System.Exception ex)
                        {
                            Logger.LogWarning(ex.Message);
                            return false;
                        }
                    }
                    Logger.LogWarning(e.Message);
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
                    catch (System.Exception e)
                    {
                        Logger.LogWarning(e.Message);
                        return false;
                    }
                }
            }
            Logger.LogError("Could not find imported object: " + link.AbsoluteObjectReference);
            return false;
        }

        public static bool ResolveWithoutLogging(Dictionary<string, object> packages, PackageDeserializer.LinkerLink link)
        {
            object imported;
            if (packages.TryGetValue(link.AbsoluteObjectReference, out imported))
            {
                try
                {
                    link.Link(imported);
                    return true;
                }
                catch (System.Exception)
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
                        try
                        {
                            arr.SetValue(imported, link.indexReference);
                            return true;
                        }
                        catch (System.Exception)
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
                    catch (System.Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
