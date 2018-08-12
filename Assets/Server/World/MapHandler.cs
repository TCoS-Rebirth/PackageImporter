using UnityEngine;
using UnityEngine.SceneManagement;

namespace World
{
    public class MapHandler: IMapHandler
    {

        public MapHandler()
        {
            SceneManager.sceneLoaded += OnLevelLoaded;
        }

        public void LoadMap(MapIDs map)
        {
            SceneManager.LoadScene(map.ToString(), LoadSceneMode.Additive);
        }

        public void UnloadMap(MapIDs map)
        {
            if (SceneManager.GetSceneByName(map.ToString()).isLoaded) SceneManager.UnloadSceneAsync(map.ToString());
        }

        void OnLevelLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log(string.Format("Map loaded: {0}", scene.name));
        }

        public void Update()
        {

        }
    }
}
