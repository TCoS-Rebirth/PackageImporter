using System;
using System.Collections.Generic;
using UnityEngine;

namespace Engine
{
    public class SBResourceListing : ScriptableObject
    {
        [SerializeField, HideInInspector] List<ResourceIndex> resources = new List<ResourceIndex>();

#if UNITY_EDITOR
        public void EditorAddResource(int id, string resource)
        {
            resources.Add(new ResourceIndex {ID = id, Resource = resource});
        }
#endif

        public Dictionary<string, int> GetIDs(bool useFirstOccurences = false)
        {
            var indexedCache = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            for (var i = 0; i < resources.Count; i++)
            {
                if (indexedCache.ContainsKey(resources[i].Resource))
                {
                    var res = resources[i].Resource;
                    if (useFirstOccurences) continue;
                    indexedCache[res] = resources[i].ID;
                    continue;
                }
                indexedCache.Add(resources[i].Resource, resources[i].ID);
            }
            return indexedCache;
        }

        [Serializable]
        class ResourceIndex
        {
            public int ID;
            public string Resource;
        }
    }
}