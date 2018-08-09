using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Engine;
using Fasterflect;
using SBGame;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Editor
{
    class MapUtilities:EditorWindow
    {

        [MenuItem("Spellborn/Map Utilities")]
        static void Open()
        {
            GetWindow<MapUtilities>("Map Utils");
        }

        List<MapAction> actions = new List<MapAction>();

        class FindActorsWithNoLocation:MapAction
        {
            public override string Description
            {
                get { return "Count Actors with no location"; }
            }

            public override void Execute()
            {
                var sms = FindObjectsOfType<Actor>();
                var zeroCount = sms.Count(actor => actor.Location.X == 0 && actor.Location.Y == 0 && actor.Location.Z == 0);
                Debug.Log(string.Format("Zero location: {0}, NonZero:{1}", zeroCount, sms.Length - zeroCount));
                for (int i = 0; i < sms.Length; i++)
                {
                    if (sms[i].Location.X == 0 && sms[i].Location.Y == 0 && sms[i].Location.Z == 0) Debug.Log(sms[i]);
                }
            }
        }

        class SortNonActorTypesIntoSubhierarchy:MapAction
        {
            public override string Description
            {
                get { return "Sort non-Actor types into sub hierarchy"; }
            }

            public override void Execute()
            {
                var sms = FindObjectsOfType<UObject>();
                var types = new HashSet<Type>();
                var dataGO = new GameObject("NonActors");
                dataGO.transform.SetAsFirstSibling();
                for (var i = 0; i < sms.Length; i++)
                {
                    if (!(sms[i] is Actor))
                    {
                        types.Add(sms[i].GetType());
                    }
                }
                for (int i = 0; i < sms.Length; i++)
                {
                    if (types.Contains(sms[i].GetType()))
                    {
                        sms[i].transform.SetParent(dataGO.transform);
                    }
                }
            }
        }

        class CountReferencesToTarget : MapAction
        {
            public override string Description
            {
                get { return "Count References to Target"; }
            }
            public override void Execute()
            {
                var obj = Selection.activeGameObject;
                var tracer = new ReferenceTracer();
                var refs = new List<Component>();
                tracer.BacktraceSelection(obj.scene, obj, refs);
                Debug.Log(refs.Count);
            }
        }

        class CleanupHelper : MapAction
        {
            public override string Description
            {
                get { return "Cleanup"; }
            }
            public override void Execute()
            {
                try
                {
                    var objs = new List<GameObject>();
                    foreach (var staticMeshActor in FindObjectsOfType<StaticMeshActor>())
                    {
                        objs.Add(staticMeshActor.gameObject);
                    }
                    foreach (var staticMesh in FindObjectsOfType<StaticMesh>())
                    {
                        objs.Add(staticMesh.gameObject);
                    }
                    foreach (var staticMeshInstance in FindObjectsOfType<StaticMeshInstance>())
                    {
                        objs.Add(staticMeshInstance.gameObject);
                    }
                    foreach (var gameStaticMesh in FindObjectsOfType<GameStaticMesh>())
                    {
                        objs.Add(gameStaticMesh.gameObject);
                    }
                    for (int i = 0; i < objs.Count; i++)
                    {
                        DestroyImmediate(objs[i], false);
                    }
                    EditorSceneManager.MarkAllScenesDirty();
                }
                catch
                {
                    EditorUtility.ClearProgressBar();
                }
            }
        }

        void OnEnable()
        {
            actions.Clear();
            var types = typeof(MapUtilities).GetNestedTypes(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var type in types)
            {
                if (type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(MapAction)))
                {
                    actions.Add(type.CreateInstance() as MapAction);
                }
            }
        }

        void OnGUI()
        {
            for (var i = 0; i < actions.Count; i++)
            {
                if (GUILayout.Button(actions[i].Description)) actions[i].Execute();
            }
        }

        abstract class MapAction
        {
            public abstract string Description { get; }
            public abstract void Execute();
        }
    }
}
