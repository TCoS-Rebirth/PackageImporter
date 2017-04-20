using System;
using System.Collections.Generic;
using TCosReborn.Application;
using TCosReborn.Framework.PackageExtractor;

namespace TCosReborn.Framework.Common
{
    public class SBResourcePackage: SBPackageResource
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        //public List<SBPackageResource> objects = new List<SBPackageResource>();

        //public Dictionary<string, SBPackageResource> objects = new Dictionary<string, SBPackageResource>();

        //public Dictionary<string, SBResourcePackage> packages = new Dictionary<string, SBResourcePackage>();

        //public List<PackageDeserializer.LinkerLink> Imports = new List<PackageDeserializer.LinkerLink>();

        //#region Package referencing

        //public SBResourcePackage GetOrAddPackage(Queue<string> fullPath)
        //{
        //    if (fullPath.Count > 0)
        //    {
        //        var nextPath = fullPath.Dequeue();
        //        if (!packages.ContainsKey(nextPath)) packages.Add(nextPath, new SBResourcePackage() { ReferenceObjectName = nextPath });
        //        return packages[nextPath].GetOrAddPackage(fullPath);
        //    }
        //    return this;
        //}

        //public void AddSubPackage(SBResourcePackage pkg, Queue<string> pkgPath)
        //{
        //    if (pkgPath.Count > 0)
        //    {
        //        var nextPath = pkgPath.Dequeue();
        //        if (!packages.ContainsKey(nextPath)) packages.Add(nextPath, new SBResourcePackage() { ReferenceObjectName = nextPath });
        //        packages[nextPath].AddSubPackage(pkg, pkgPath);
        //    }else
        //    {
        //        if (!packages.ContainsKey(pkg.ReferenceObjectName))
        //        {
        //            packages.Add(pkg.ReferenceObjectName, pkg);
        //        }
        //    }
        //}

        //#endregion

        //[SerializeField] public List<SBPackageResource> allObjects = new List<SBPackageResource>();

        //public SBPackageResource GetResource(int id)
        //{
        //    if (id <= 0) return null;
        //    for (var i = 0; i < objects.Count; i++)
        //    {
        //        if (objects[i].ResourceID == id) return objects[i];
        //    }
        //    return null;
        //}

        //public T GetResource<T>(int id) where T:SBPackageResource
        //{
        //    if (id <= 0) return null;
        //    for (var i = 0; i < objects.Count; i++)
        //    {
        //        if (objects[i].ResourceID == id) return objects[i] as T;
        //    }
        //    return null;
        //}

        /// <summary>
        /// returns the resource with <see cref="objectName"/>, if found
        /// </summary>
        /// <param name="objectName">the name of the object</param>
        /// <param name="subPackageName">must be string.Empty or '""' if null (not "null")</param>
        //public SBPackageResource FindResource(string objectName, string subPackageName)
        //{
        //    for (var i = 0; i < objects.Count; i++)
        //    {
        //        if (objects[i] == null)
        //        {
        //            Logger.LogError("packageobject is null in: " + ReferencePackageName + "(index: " + i + " )");
        //            throw new NullReferenceException();
        //        }
        //        if (objects[i].ReferenceObjectName.Equals(objectName, StringComparison.OrdinalIgnoreCase) &
        //            objects[i].ReferencePackageName.Replace("null", string.Empty).Equals(subPackageName, StringComparison.OrdinalIgnoreCase)) return objects[i];
        //    }
        //    return null;
        //}

        /// <summary>
        /// returns the resource with <see cref="objectName"/>, if found
        /// </summary>
        /// <param name="objectName">the name of the object</param>
        /// <param name="subPackageName">must be string.Empty or '""' if null (not "null")</param>
        //public T FindResource<T>(string objectName, string subPackageName) where T: SBPackageResource
        //{
        //    for (var i = 0; i < objects.Count; i++)
        //    {
        //        if (objects[i] == null)
        //        {
        //            Logger.LogError("packageobject is null in: " + ReferencePackageName + "(index: " + i + " )");
        //            throw new NullReferenceException();
        //        }
        //        if (objects[i].ReferenceObjectName.Equals(objectName, StringComparison.OrdinalIgnoreCase) &
        //            objects[i].ReferencePackageName.Replace("null", string.Empty).Equals(subPackageName, StringComparison.OrdinalIgnoreCase))
        //            return objects[i] as T;
        //    }
        //    return null;
        //}
    }
}
