using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace World
{
    public class MapHandler: IMapHandler
    {

        Dictionary<MapIDs, GameMap> loadedMaps = new Dictionary<MapIDs, GameMap>();
        Dictionary<Scene, GameMap> loadedScenes = new Dictionary<Scene, GameMap>();

        HashSet<int> instanceIDs = new HashSet<int>();

        int AllocateInstanceID()
        {
            var id = 0;
            while (instanceIDs.Contains(id)) id++;
            return id;
        }

        public MapHandler()
        {
            SceneManager.sceneLoaded += OnLevelLoaded;
            SceneManager.sceneUnloaded += OnLevelUnloaded;
        }

        public void LoadPersistentMap(MapIDs map)
        {
            SceneManager.LoadScene(map.ToString(), LoadSceneMode.Additive);
        }

        public void UnloadPersistentMap(MapIDs map)
        {
            if (SceneManager.GetSceneByName(map.ToString()).isLoaded) SceneManager.UnloadSceneAsync(map.ToString());
        }

        public GameMap GetPersistentMap(MapIDs map)
        {
            GameMap scene;
            return loadedMaps.TryGetValue(map, out scene) ? scene : null;
        }

        void OnLevelLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "Main") return; //ignore
            Debug.Log(string.Format("Map loaded: {0}", scene.name));
            var mapID = (MapIDs) Enum.Parse(typeof(MapIDs), scene.name, true);
            var universe = ServiceContainer.GetService<IGameResources>().Universe;
            var world = universe.Worlds.FirstOrDefault(sbWorld => sbWorld.worldID == mapID);
            if (world == null) throw new NullReferenceException("World is null");
            var map = new GameMap(scene, mapID, world, AllocateInstanceID());
            loadedMaps.Add(map.ID, map);
            loadedScenes.Add(scene, map);
        }

        void OnLevelUnloaded(Scene scene)
        {
            Debug.Log(string.Format("Map unloaded: {0}", scene.name));
            var map = (MapIDs) Enum.Parse(typeof(MapIDs), scene.name, true);
            loadedMaps.Remove(map);
            loadedScenes.Remove(scene);
        }

        public void Update()
        {

        }
    }
}
