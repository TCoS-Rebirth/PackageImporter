using System;
using System.Collections.Generic;
using UnityEngine;
using Fasterflect;

namespace Framework.PackageExtractor
{

    public static class PackageImportResolver
    {

        public static void Resolve(Queue<ImportLink> links, Dictionary<string, object> objectsByName)
        {
            Debug.Log("------------linking imports-----------");
            Debug.Log(links.Count + " objects to link");
            int unlinked = 0;
            int skipped = 0;
            while(links.Count > 0)
            {
                var link = links.Dequeue();
                var result = Resolve(link, objectsByName);
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
            Debug.Log(skipped + " imported objects were skipped");
            Debug.LogWarning(unlinked + "imported objects could not be linked");
        }

        enum ResolveResult
        {
            Skipped,
            NotFound,
            Error,
            Success
        }

        static ResolveResult Resolve(ImportLink link, Dictionary<string, object> objectsByName)
        {
            if (link.AbsoluteObjectReference.StartsWith("SBParticles", StringComparison.Ordinal))
            {
                return ResolveResult.Skipped;
            }
            if (link.AbsoluteObjectReference.StartsWith("GlobalsTX", StringComparison.Ordinal))
            {
                return ResolveResult.Skipped;
            }
            //if (link.AbsoluteObjectReference.StartsWith("SBGuiTX", StringComparison.Ordinal))
            //{
            //    return ResolveResult.Skipped;
            //}
            //if (link.AbsoluteObjectReference.StartsWith("SBIconTX", StringComparison.Ordinal))
            //{
            //    return ResolveResult.Skipped;
            //}
            object imported;
            if (objectsByName.TryGetValue(link.AbsoluteObjectReference, out imported))
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
                        var arr = link.fieldReference.Get(link.targetReference) as Array;
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
                            Debug.LogException(ex);
                            return ResolveResult.Error;
                        }
                    }
                    Debug.LogException(e);
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
                        Debug.LogException(e);
                        return ResolveResult.Error;
                    }
                }
            }
            Debug.LogError(string.Format("Could not find imported object: {0} for {1} (field:{2})", link.AbsoluteObjectReference, link.targetReference, link.fieldReference));
            return ResolveResult.NotFound;
        }
    }
}
