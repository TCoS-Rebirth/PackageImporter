using System;
using System.Collections.Generic;
using System.Diagnostics;
using TCosReborn.Application;
using TCosReborn.Framework.Attributes;

namespace TCosReborn.Framework.Common
{
    public class SBResourcePackage: SBPackageResource
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        [SerializeField, ReadOnly] public List<SBPackageResource> exports = new List<SBPackageResource>();

        [SerializeField] public List<SBPackageResource> allObjects = new List<SBPackageResource>();

        public SBPackageResource GetResource(int id)
        {
            if (id <= 0) return null;
            for (var i = 0; i < allObjects.Count; i++)
            {
                if (allObjects[i].ResourceID == id) return allObjects[i];
            }
            return null;
        }

        public T GetResource<T>(int id) where T:SBPackageResource
        {
            if (id <= 0) return null;
            for (var i = 0; i < allObjects.Count; i++)
            {
                if (allObjects[i].ResourceID == id) return allObjects[i] as T;
            }
            return null;
        }

        /// <summary>
        /// returns the resource with <see cref="objectName"/>, if found
        /// </summary>
        /// <param name="objectName">the name of the object</param>
        /// <param name="subPackageName">must be string.Empty or '""' if null (not "null")</param>
        public SBPackageResource FindResource(string objectName, string subPackageName)
        {
            for (var i = 0; i < allObjects.Count; i++)
            {
                if (allObjects[i] == null)
                {
                    Logger.LogError("packageobject is null in: " + ReferencePackageName + "(index: " + i + " )");
                    throw new NullReferenceException();
                }
                if (allObjects[i].ReferenceObjectName.Equals(objectName, StringComparison.OrdinalIgnoreCase) &
                    allObjects[i].ReferencePackageName.Replace("null", string.Empty).Equals(subPackageName, StringComparison.OrdinalIgnoreCase)) return allObjects[i];
            }
            return null;
        }

        /// <summary>
        /// returns the resource with <see cref="objectName"/>, if found
        /// </summary>
        /// <param name="objectName">the name of the object</param>
        /// <param name="subPackageName">must be string.Empty or '""' if null (not "null")</param>
        public T FindResource<T>(string objectName, string subPackageName) where T: SBPackageResource
        {
            for (var i = 0; i < allObjects.Count; i++)
            {
                if (allObjects[i] == null)
                {
                    Logger.LogError("packageobject is null in: " + ReferencePackageName + "(index: " + i + " )");
                    throw new NullReferenceException();
                }
                if (allObjects[i].ReferenceObjectName.Equals(objectName, StringComparison.OrdinalIgnoreCase) &
                    allObjects[i].ReferencePackageName.Replace("null", string.Empty).Equals(subPackageName, StringComparison.OrdinalIgnoreCase))
                    return allObjects[i] as T;
            }
            return null;
        }
    }
}
