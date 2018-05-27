using System;
using System.Collections.Generic;
using System.Linq;
using Engine;
using UnityEngine;
using Fasterflect;
using TCosReborn;
using UnityEditor;

namespace Framework.PackageExtractor
{

    public static class PackageImportResolver
    {

        public static void Resolve(Queue<ImportLink> links, params List<PackageObjectDescription>[] descriptions)
        {
            Debug.Log("------------linking imports-----------");
            Debug.Log(links.Count + " objects to link");
            var unlinked = 0;
            var skipped = 0;
            var start = links.Count;
            EditorUtility.DisplayProgressBar("Creating object index", string.Empty, 0.5f);
            var objects = new Dictionary<string, UObject>(StringComparer.OrdinalIgnoreCase);
            for (var i = 0; i < descriptions.Length; i++)
            {
                for (var j = 0; j < descriptions[i].Count; j++)
                {
                    var desc = descriptions[i][j];
                    if (desc == null) continue;
                    if (objects.ContainsKey(desc.AbsoluteObjectPath))
                    {
                        Debug.LogError("Duplicate object: " + desc.AbsoluteObjectPath);
                        continue;
                    }
                    objects.Add(desc.AbsoluteObjectPath, desc.Obj);
                }
            }
            try
            {
                while (links.Count > 0)
                {
                    if (links.Count % 1000 == 0)
                    {
                        if (EditorUtility.DisplayCancelableProgressBar("Resolving Imports", string.Format("{0}/{1}", start - links.Count, start),
                            0.5f + Mathf.Clamp01(1f - (float) links.Count / start) * 0.5f))
                        {
                            if (EditorUtility.DisplayDialog("Cancel?", "this will leave objects in a broken state", "Yes", "No"))
                                throw new Exception("Import resolve canceled");
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

        static ResolveResult Resolve(ImportLink link, Dictionary<string, UObject> objects)
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
