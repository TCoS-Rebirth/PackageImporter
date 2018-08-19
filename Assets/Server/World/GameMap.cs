using System;
using System.Collections.Generic;
using Engine;
using SBBase;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace World
{
    public class GameMap
    {
        //Scene scene;
        List<Actor> actors = new List<Actor>();

        public MapIDs ID { get; private set; }
        public int InstanceID { get; private set; }
        public SBWorld SBWorld { get; private set; }

        public GameMap(Scene scene, MapIDs id, SBWorld sbWorld, int instanceID)
        {
            //this.scene = scene;
            ID = id;
            InstanceID = instanceID;
            SBWorld = sbWorld;
            foreach (var rootObject in scene.GetRootGameObjects())
            {
                actors.AddRange(rootObject.GetComponentsInChildren<Actor>(true));
            }
        }

        public IEnumerator<T> Actors<T>() where T : Actor
        {
            foreach (var rootObject in actors)
            {
                var t = rootObject as T;
                if (t != null) yield return t;
            }
        }

        public void Add<T>(T actor) where T : Actor
        {
            if (!actors.Contains(actor)) actors.Add(actor);
        }

        public bool Remove<T>(T actor) where T : Actor
        {
            return actors.Remove(actor);
        }

        public T Spawn<T>(T prefab, Vector3 location, Quaternion rotation, Action<T> initCallback = null, Actor owner=null, string spawnTag="") where T:Controller
        {
            var t = UnityEngine.Object.Instantiate(prefab);
            t.transform.SetPositionAndRotation(location, rotation);
            actors.Add(t);
            if (initCallback != null) initCallback(t);
            t.SetOwner(owner);
            t.PreBeginPlay();
            t.Tag = spawnTag;
            t.BeginPlay();
            t.PostBeginPlay();
            t.SetInitialState();
            return t;
        }

        public T Find<T>(Predicate<T> predicate) where T:Actor
        {
            foreach (var actor in actors)
            {
                var t = actor as T;
                if (t != null && predicate(t)) return t;
            }
            return null;
        }
    }
}
