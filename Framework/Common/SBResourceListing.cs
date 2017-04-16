using System;
using System.Collections.Generic;
using Engine;
using TCosReborn.Framework.Attributes;

namespace TCosReborn.Framework.Common
{
    [Serializable]
    public class SBResource
    {
        public int ID;
        public string Name;

        public SBResource(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }

    public class SBResourceListing : UObject
    {
        [SerializeField] List<SBResource> resources = new List<SBResource>();

        static SBResourceListing instance;

        public static SBResourceListing Get
        {
            get {
                Debug.LogError("fixit!");
                //if (instance != null) return instance;
                //instance = Resources.Load<SBResourceListing>("SBResourceListing");
                //if (instance) return instance;
                //Debug.LogError("ResourceListing could not be loaded!");
                //instance = CreateInstance<SBResourceListing>();
                return instance;
            }
        }

        public List<SBResource> Res
        {
            get { return resources; }
        }

        public SBResource GetResource(int id)
        {
            for (var i = 0; i < resources.Count; i++)
            {
                if (resources[i].ID == id)
                {
                    return resources[i];
                }
            }
            return null;
        }

        public IEnumerable<SBResource> GetFilteredResources(string filter)
        {
            if (string.IsNullOrEmpty(filter) || filter == " ")
            {
                yield break;
            }
            for (var i = 0; i < resources.Count; i++)
            {
                if (resources[i].Name.Contains(filter))
                {
                    yield return resources[i];
                }
            }
        }

        public SBResource GetResource(string packageName, string objectName)
        {
            for (var i = 0; i < resources.Count; i++)
            {
                var resName = resources[i].Name.Split('.');
                if (!packageName.Equals(resName[0], StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                var resObjName = resName[resName.Length - 1];
                if (resObjName.Equals(objectName, StringComparison.OrdinalIgnoreCase))
                {
                    return resources[i];
                }
            }
            return null;
        }

        /// <summary>
        ///     containedIdentifier can be used for skills/subpackages
        /// </summary>
        public int GetResourceID(string packageName, string containedIdentifierString, string objectName)
        {
            for (var i = 0; i < resources.Count; i++)
            {
                if (resources[i].Name.Contains(packageName) && resources[i].Name.Contains(containedIdentifierString) && resources[i].Name.EndsWith(objectName, StringComparison.Ordinal))
                {
                    return resources[i].ID;
                }
            }
            return 0;
        }

        public int GetResourceID(string fullname)
        {
            for (var i = 0; i < resources.Count; i++)
            {
                if (resources[i].Name.Equals(fullname, StringComparison.OrdinalIgnoreCase))
                {
                    return resources[i].ID;
                }
            }
            return 0;
        }

        public SBResource GetResource(string fullName)
        {
            for (var i = 0; i < resources.Count; i++)
            {
                if (resources[i].Name.Equals(fullName, StringComparison.OrdinalIgnoreCase))
                {
                    return resources[i];
                }
            }
            return null;
        }
    }
}