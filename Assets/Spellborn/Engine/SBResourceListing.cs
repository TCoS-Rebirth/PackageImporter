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

        [ContextMenu("Export to file")]
        void ExportTextFile()
        {
            var path = UnityEditor.EditorUtility.SaveFilePanel("Save", "", "Resources", "txt");
            if (string.IsNullOrEmpty(path)) return;
            var strings = new string[resources.Count];
            for (var i = 0; i < strings.Length; i++)
            {
                strings[i] = string.Format("{0} - {1}", resources[i].ID, resources[i].Resource);
            }
            System.IO.File.WriteAllLines(path, strings);
        }
#endif

        public Dictionary<string, int> GetIDs(bool useFirstOccurences = false)
        {
            var indexedCache = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            for (var i = 0; i < resources.Count; i++)
            {
                if (indexedCache.ContainsKey(resources[i].Resource))
                {
                    if (useFirstOccurences) continue;
                    var res = resources[i].Resource;
                    indexedCache[res] = resources[i].ID;
                    continue;
                }
                indexedCache.Add(resources[i].Resource.Trim(), resources[i].ID);
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