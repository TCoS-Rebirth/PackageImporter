using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TCosReborn.Framework.Common;

namespace TCosReborn.Framework.PackageExtractor
{
    public class ReferenceResolver
    {

        string basePath;

        string[] subfolderNames = {"appearance", "factions", "items", "quests", "shops", "skills", "tables"};

        public ReferenceResolver(string basePath)
        {
            this.basePath = basePath;
        }

        Dictionary<string, SBResourcePackage> packages = new Dictionary<string, SBResourcePackage>(); 

        public void ResolveSingle(SBResourcePackage pkg)
        {
            Debug.LogError("fixit! load packages first");
            ResolvePackage(pkg);
            Debug.Log("Done");
        }

        public void Verify()
        {
            Debug.LogError("fixit! load packages first");
            //if (LoadAllPackages())
            //{
                foreach (var package in packages.Values)
                {
                    VerifyPackage(package);
                }
                Debug.Log("Done");
            //}
            //else
            //{
            //    Debug.Log("Error loading packages");
            //}
        }

        void VerifyPackage(SBResourcePackage target)
        {
            foreach (var resource in target.exports)
            {
                if (resource is SBResourcePackage) VerifyPackage(resource as SBResourcePackage);
                if (resource.IsExternalReference)
                {
                    Debug.Log("External ref found in packageObjects (should not happen!): " + resource.ReferenceObjectName + "(" + resource.ReferencePackageName + ")");
                    continue;
                }
                if (target.ReferencePackageName.Equals("SkillsTestGP") && resource.ReferenceObjectName.Equals("Void_Cast_1_Emitter")) continue; //skip that one in particular
                VerifyObject(resource, new HashSet<object>());
            }
        }

        void VerifyObject(object res, HashSet<object> alreadyEntered)
        {
            if (alreadyEntered.Contains(res))
            {
                return; //correct?
            }
            alreadyEntered.Add(res);
            var fields = res.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy).ToList();
            for (var i = fields.Count; i-- > 0;)
            {
                if (!fields[i].FieldType.IsClass) fields.RemoveAt(i);
            }
            for (var x = 0; x < fields.Count; x++)
            {
                var fieldInfo = fields[x];
                var fieldValue = fieldInfo.GetValue(res);
                if (fieldValue == null) continue; //nothing to Test
                var sbp = fieldValue as SBPackageResource;
                if (sbp != null)
                {
                    if (sbp.IsExternalReference)
                    {
                        Debug.Log("External ref: " + sbp.ReferenceObjectName + "(" + sbp.ReferencePackageName + ") in: "+ res);
                    }
                    continue;
                }
                if (fieldInfo.FieldType.IsGenericType && fieldInfo.FieldType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var list = fieldValue as IList;
                    for (var i = 0; i < list.Count; i++)
                    {
                        if (list[i] == null) continue;
                        if (!list[i].GetType().IsClass) continue;
                        var listres = list[i] as SBPackageResource;
                        if (listres == null) continue;
                        if (listres.IsExternalReference)
                        {
                            Debug.Log("External ref: " + listres.ReferenceObjectName + "(" + listres.ReferencePackageName + ") in: " + res);
                        }
                        VerifyObject(listres, alreadyEntered);
                    }
                    continue;
                }
                if (fieldInfo.FieldType.IsArray)
                {
                    var array = fieldValue as Array;
                    for (var i = 0; i < array.Length; i++)
                    {
                        if (array.GetValue(i) == null) continue;
                        if (!array.GetValue(i).GetType().IsClass) continue;
                        var arrayRes = array.GetValue(i) as SBPackageResource;
                        if (arrayRes == null) continue;
                        if (arrayRes.IsExternalReference)
                        {
                            Debug.Log("External ref: " + arrayRes.ReferenceObjectName + "(" + arrayRes.ReferencePackageName + ") in: " + res);
                        }
                        VerifyObject(arrayRes, alreadyEntered);
                    }
                }
            }
        } 

        bool TestReferenceAvailability(SBResourcePackage target)
        {
            for (int i = 0; i < target.allObjects.Count; i++)
            {
                if (!target.allObjects[i].IsExternalReference) continue;
                if (target.ReferencePackageName.Equals("SkillsTestGP") && target.allObjects[i].ReferenceObjectName.Equals("Void_Cast_1_Emitter")) continue; //this one is really missing in the packages
                var original = FindOriginalResource(target.allObjects[i]);
                if (original == null)
                {
                    Debug.Log("Missing original: " + target.allObjects[i].ReferenceObjectName);
                    return false;
                }
            }
            return true;
        }

        void ResolvePackage(SBResourcePackage target)
        {
            foreach (var resource in target.allObjects)
            {
                if (resource is SBResourcePackage) continue;
                if (resource.IsExternalReference) continue;
                if (target.ReferencePackageName.Equals("SkillsTestGP") && resource.ReferenceObjectName.Equals("Void_Cast_1_Emitter")) continue; //skip that one in particular
                ResolveObject(resource, new HashSet<object>());
            }
        }

        void ResolveObject(object res, HashSet<object> alreadyEntered)
        {
            if (alreadyEntered.Contains(res))
            {
                return; //correct?
            }
            alreadyEntered.Add(res);
            var fields = res.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy).ToList();
            for (var i = fields.Count; i-- > 0;)
            {
                if (!fields[i].FieldType.IsClass) fields.RemoveAt(i);
            }
            for (var x = 0; x < fields.Count; x++)
            {
                var fieldInfo = fields[x];
                var fieldValue = fieldInfo.GetValue(res);
                if (fieldValue == null) continue; //nothing to resolve
                var sbp = fieldValue as SBPackageResource;
                if (sbp != null)
                {
                    if (sbp.IsExternalReference)
                    {
                        var foundReference = FindOriginalResource(sbp);
                        if (foundReference != null)
                        {
                            try
                            {
                                fieldInfo.SetValue(res, foundReference); //should prevent an infinite stackoverflow
                            }
                            catch (Exception)
                            {
                                Debug.LogError(string.Format("{0}'s found reference is problematic: {1} ({2}.{3})", sbp, foundReference, sbp.ReferencePackageName,
                                    sbp.ReferenceObjectName));
                                //return; //why? how can there be an Item_Broken in an Item_ClothChest slot?
                                continue; //skip for now
                            }
                            sbp = foundReference;
                        }
                    }
                    ResolveObject(sbp, alreadyEntered);
                    continue;
                }
                if (fieldInfo.FieldType.IsGenericType && fieldInfo.FieldType.GetGenericTypeDefinition() == typeof (List<>))
                {
                    var list = fieldValue as IList;
                    for (var i = 0; i < list.Count; i++)
                    {
                        if (list[i] == null) continue;
                        if (!list[i].GetType().IsClass) continue;
                        var listres = list[i] as SBPackageResource;
                        if (listres == null || !listres.IsExternalReference) continue;
                        var foundlistresRef = FindOriginalResource(listres);
                        if (foundlistresRef == null) continue;
                        try
                        {
                            list[i] = foundlistresRef;
                        }
                        catch (Exception)
                        {
                            Debug.LogError("Problem with assigning to list: " + res + " / " + foundlistresRef);
                        }
                    }
                    for (var i = 0; i < list.Count; i++)
                    {
                        if (list[i] == null) continue;
                        if (!list[i].GetType().IsClass) continue;
                        if (list[i] != null)
                        {
                            ResolveObject(list[i], alreadyEntered);
                        } 
                    }
                    continue;
                }
                if (fieldInfo.FieldType.IsArray)
                {
                    var array = fieldValue as Array;
                    for (var i = 0; i < array.Length; i++)
                    {
                        if (array.GetValue(i) == null) continue;
                        if (!array.GetValue(i).GetType().IsClass) continue;
                        var arrayRes = array.GetValue(i) as SBPackageResource;
                        if (arrayRes == null || !arrayRes.IsExternalReference) continue;
                        var foundArrayResRef = FindOriginalResource(arrayRes);
                        if (foundArrayResRef == null) continue;
                        try
                        {
                            array.SetValue(foundArrayResRef, i);
                        }
                        catch (Exception)
                        {
                            Debug.LogError("Problem with assinging to array: " + res + " / " + foundArrayResRef);
                        }
                    }
                    for (var i = 0; i < array.Length; i++)
                    {
                        if (array.GetValue(i) == null) continue;
                        if (!array.GetValue(i).GetType().IsClass) continue;
                        if (array.GetValue(i) != null)
                        {
                            ResolveObject(array.GetValue(i), alreadyEntered);
                        }
                    }
                }
            }
        }

        SBPackageResource FindOriginalResource(SBPackageResource replacement)
        {
            var pkgName = replacement.ReferencePackageName;
            var subPackage = "";
            if (pkgName.Contains("."))
            {
                pkgName = pkgName.Substring(0, pkgName.IndexOf(".", StringComparison.Ordinal));
                subPackage = replacement.ReferencePackageName.Replace(pkgName + ".", string.Empty);
            }
            SBResourcePackage refpkg;
            if (packages.TryGetValue(pkgName, out refpkg))
            {
                var refObj = refpkg.FindResource(replacement.ReferenceObjectName, subPackage);
                if (refObj != null) return refObj;
                Debug.LogWarning(string.Format("Reference not found: {0} ({1})", replacement.ReferenceObjectName, replacement.ReferencePackageName));
                return null;
            }
            Debug.LogWarning("Package not found? :" + pkgName);
            return null;
        }

        
    }
}
