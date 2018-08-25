using UnityEngine.SceneManagement;
using World;

public interface IMapHandler
{
    GameMap GetPersistentMap(MapIDs map);
}