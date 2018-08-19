using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Engine;
using Fasterflect;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Assets.Editor
{
    class EditorUtilities : OdinEditorWindow
    {

        [MenuItem("Spellborn/Editor Utilities")]
        static void Open()
        {
            GetWindow<EditorUtilities>("EditorUtils");
        }

        [ValueDropdown("SbTypes", ExcludeExistingValuesInList = true), PropertyOrder(0)]
        public List<Type> SelectedTypes = new List<Type>();

        [UsedImplicitly]
        readonly Type[] SbTypes = typeof(Actor).Assembly.GetExportedTypes().Where(type => type.IsSubclassOf(typeof(UObject))).ToArray();

        [ListDrawerSettings(HideAddButton = true)]
        [PropertyOrder(5)]
        public List<Type> unusedTypes = new List<Type>();

        [Button]
        [PropertyOrder(4)]
        void FindUnusedTypes()
        {
            unusedTypes.Clear();
            var refs = new List<Component>();
            var assetIDs = AssetDatabase.FindAssets("t:" + typeof(GameObject).Name);
            var searchableObjects = new List<GameObject>();
            for (int i = 0; i < assetIDs.Length; i++)
            {
                var go = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(assetIDs[i]));
                if (go != null) searchableObjects.Add(go);
            }
            searchableObjects.AddRange(GetAllSceneRootObjects());
            for (int j = 0; j < SbTypes.Length; j++)
            {
                refs.Clear();
                for (int i = 0; i < searchableObjects.Count; i++)
                {
                    refs.AddRange(searchableObjects[i].GetComponentsInChildren(SbTypes[j]));
                }
                if (refs.Count == 0) unusedTypes.Add(SbTypes[j]);
            }
        }

        List<GameObject> GetAllSceneRootObjects()
        {
            var gos = new List<GameObject>();
            for (var i = 0; i < EditorSceneManager.sceneCount; i++)
            {
                gos.AddRange(EditorSceneManager.GetSceneAt(i).GetRootGameObjects());
            }
            return gos;
        }

        [Button]
        [PropertyOrder(1)]
        void FindTypeReferencesInAssets()
        {
            if (SelectedTypes.Count == 0) return;
            references.Clear();
            var refs = new List<Component>();
            var gos = AssetDatabase.FindAssets("t:" + typeof(GameObject).Name);
            for (int i = 0; i < gos.Length; i++)
            {
                var go = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(gos[i]));
                if (go != null)
                {
                    for (int j = 0; j < SelectedTypes.Count; j++)
                    {
                        refs.AddRange(go.GetComponentsInChildren(SelectedTypes[j]));
                    }
                }
            }
            for (var i = 0; i < refs.Count; i++)
            {
                references.Add(refs[i].gameObject);
            }
        }

        [Button]
        [PropertyOrder(2)]
        void FindTypeReferencesInScene()
        {
            if (SelectedTypes.Count == 0) return;
            references.Clear();
            var refs = new List<Component>();
            foreach (var go in GetAllSceneRootObjects())
            {
                for (int j = 0; j < SelectedTypes.Count; j++)
                {
                    refs.AddRange(go.GetComponentsInChildren(SelectedTypes[j]));
                }
            }
            for (var i = 0; i < refs.Count; i++)
            {
                references.Add(refs[i].gameObject);
            }
        }

        [PropertyOrder(3), PropertySpace, ReadOnly, ListDrawerSettings(HideAddButton = true)]
        public List<UnityEngine.Object> references = new List<UnityEngine.Object>();

    }
}
