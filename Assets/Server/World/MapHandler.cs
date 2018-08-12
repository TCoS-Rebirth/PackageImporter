using System.Collections.Generic;
using Engine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace World
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
            Debug.Log(string.Format("Level loaded: {0}", info.gameObject.scene.name));
        }

        public void Update()
        {

        }
    }
}
