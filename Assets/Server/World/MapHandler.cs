using System;
using System.Collections.Generic;
using Engine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Server.World
{
    public class MapHandler: IMapHandler
    {

        List<LevelInfo> loadedLevels = new List<LevelInfo>();

        public MapHandler()
        {
            LevelInfo.OnLevelLoaded += OnLevelLoaded;
        }

        public void LoadMap(MapIDs map)
        {
            SceneManager.LoadScene(map.ToString(), LoadSceneMode.Additive);
        }

        public void UnloadMap(MapIDs map)
        {
            if (SceneManager.GetSceneByName(map.ToString()).isLoaded) SceneManager.UnloadSceneAsync(map.ToString());
        }

        void OnLevelLoaded(LevelInfo info)
        {
            if (loadedLevels.Contains(info)) return;
            loadedLevels.Add(info);
            Debug.Log(string.Format("Level loaded: {0} ({1})", info.gameObject.scene.name, info.Title.Length > 0 ? info.Title : info.Description));
        }

        public void Update()
        {

        }
    }
}
