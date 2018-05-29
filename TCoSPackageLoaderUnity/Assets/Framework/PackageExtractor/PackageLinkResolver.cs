using System;
using System.Collections.Generic;
using Engine;
using UnityEngine;
using UnityEditor;

namespace Framework.PackageExtractor
{

    public static class PackageLinkResolver
    {

        public static void Resolve(Queue<DelayedLink> links, params List<PackageObject>[] descriptions)
        {
            Debug.Log(links.Count + " objects to link");
            var unlinked = 0;
            var skipped = 0;
            var start = links.Count;
            var skipProgressBar = links.Count < 1000;
            if (!skipProgressBar) EditorUtility.DisplayProgressBar("Creating object index", string.Empty, 0.5f);
            var objects = new Dictionary<string, UObject>(StringComparer.OrdinalIgnoreCase);
            for (var i = 0; i < descriptions.Length; i++)
            {
                for (var j = 0; j < descriptions[i].Count; j++)
                {
                    var desc = descriptions[i][j];
                    if (desc == null) continue;
                    if (objects.ContainsKey(desc.AbsoluteObjectNamePath))
                    {
                        Debug.LogError("Duplicate object: " + desc.AbsoluteObjectNamePath);
                        continue;
                    }
                    objects.Add(desc.AbsoluteObjectNamePath, desc.Instance);
                }
            }
            try
            {
                while (links.Count > 0)
                {
                    if (!skipProgressBar && links.Count % 100 == 0)
                    {
                        if (EditorUtility.DisplayCancelableProgressBar("Resolving Links", string.Format("{0}/{1}", start - links.Count, start), Mathf.Clamp01(1f - (float) links.Count / start)))
                        {
                            if (EditorUtility.DisplayDialog("Cancel?", "this will leave objects in a broken state", "Yes", "No"))
                                throw new Exception("Linking canceled");
                        }
                    }
                    var link = links.Dequeue();
                    var result = Resolve(link, objects);
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
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
            Debug.Log(skipped + " links were skipped");
            Debug.LogWarning(unlinked + " objects could not be linked");
        }

        enum ResolveResult
        {
            Skipped,
            NotFound,
            Error,
            Success
        }

        static ResolveResult Resolve(DelayedLink link, Dictionary<string, UObject> objects)
        {
            if (link.AbsoluteObjectReference.StartsWith("SBParticles", StringComparison.Ordinal))
            {
                return ResolveResult.Skipped;
            }
            if (link.AbsoluteObjectReference.StartsWith("GlobalsTX", StringComparison.Ordinal))
            {
                return ResolveResult.Skipped;
            }
            UObject imported;
            if (objects.TryGetValue(link.AbsoluteObjectReference, out imported))
            {
                try
                {
                    link.Assign(imported);
                    return ResolveResult.Success;
                }
                catch (Exception e)
                {
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
                        link.Assign(type);
                        return ResolveResult.Success;
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                        return ResolveResult.Error;
                    }
                }
            }
            Debug.LogError(string.Format("Could not find imported object: {0} for {1}", link.AbsoluteObjectReference, link));
            return ResolveResult.NotFound;
        }
    }
}
