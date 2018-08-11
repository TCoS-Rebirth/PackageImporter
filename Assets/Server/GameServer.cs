
using SBBase;
using Server.Accounts;
using Server.Database;
using Server.World;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Server
{
    public class GameServer: MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Init()
        {
            RegisterServices();
            LoadStartupScene();
        }

        public static readonly UniverseInfo UniverseInfo = new UniverseInfo("TCoSReborn", "Any", "PVE");
        static SessionHandler sessionHandler;
        static MapHandler mapHandler;
        static TransientDatabase database;

        WorldServer worldServer;
        LoginServer loginServer;

        [SerializeField] SBUniverse universe;

        static void RegisterServices()
        {
            sessionHandler = new SessionHandler();
            mapHandler = new MapHandler();
            database = new TransientDatabase();

            ServiceLocator.AddService<ISessionHandler>(sessionHandler);
            ServiceLocator.AddService<IMapHandler>(mapHandler);
            ServiceLocator.AddService<IDatabase>(database);
            
        }

        static void LoadStartupScene()
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }

        void Awake()
        {
            worldServer = new WorldServer("127.0.0.1", 22234);
            ServiceLocator.AddService<IWorldServer>(worldServer);
            loginServer = new LoginServer(22233);
        }

        void Start()
        {
            mapHandler.LoadMap(MapIDs.PT_HAWKSMOUTH);
        }

        void Update()
        {
            loginServer.Update();
            worldServer.Update();
            mapHandler.Update();
        }

    }
}
