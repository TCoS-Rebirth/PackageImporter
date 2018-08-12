namespace Server
{
    public interface IMapHandler
    {
        void LoadMap(MapIDs map);
        void UnloadMap(MapIDs map);
    }
}