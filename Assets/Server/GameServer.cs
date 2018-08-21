using System.Diagnostics;
using User;
using Database;
using SBBase;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;
using World;
using Debug = UnityEngine.Debug;

public class GameServer : MonoBehaviour
{
    static int loginPort = 22233;
    static string worldIP = "127.0.0.1";
    static int worldPort = 22234;

    public static readonly UniverseInfo UniverseInfo = new UniverseInfo("TCoSReborn", "Any", "PVE");
    static SessionHandler sessionHandler;
    static MapHandler mapHandler;

    WorldServer worldServer;
    LoginServer loginServer;
    [SerializeField] GameResources resources;

    [SerializeField] TransientDatabase database;

    void Awake()
    {
        if (resources == null) resources = GetComponent<GameResources>();
        ServiceContainer.AddService<IGameResources>(resources);
        ServiceContainer.AddService<IDatabase>(database);
        sessionHandler = new SessionHandler();
        ServiceContainer.AddService<ISessionHandler>(sessionHandler);
        mapHandler = new MapHandler();
        ServiceContainer.AddService<IMapHandler>(mapHandler);
        worldServer = new WorldServer(worldIP, worldPort);
        ServiceContainer.AddService<IWorldServer>(worldServer);
        loginServer = new LoginServer(loginPort);
    }

    void Start()
    {
        LoadPersistentWorlds();
        worldServer.Start();
        loginServer.Start();
    }

    void OnDestroy()
    {
        sessionHandler.EndAllSessions();
        loginServer.Stop();
        worldServer.Stop();
    }

    #if UNITY_EDITOR
    [Button(ButtonSizes.Small, Expanded = false)]
    void LaunchClient()
    {
        Process.Start(@"C:\Program Files (x86)\The Chronicles of Spellborn\bin\client\Sb_client.exe", "--show_console --packet_log --world 1");
    }
    #endif

    void LoadPersistentWorlds()
    {
        Debug.Log("Loading persistent worlds");
        var loadingStartTime = Time.realtimeSinceStartup;
        foreach (var sbWorld in resources.Universe.Worlds)
        {
            if (sbWorld.WorldFile.Contains("\\")) continue;
            if (sbWorld.WorldType == SBWorld.eZoneWorldTypes.ZWT_PERSISTENT) mapHandler.LoadPersistentMap(sbWorld.worldID);
        }
        Debug.Log("Loading persistent worlds finished in " + (Time.realtimeSinceStartup - loadingStartTime).ToString("0.0") + "s");
    }

    void Update()
    {
        loginServer.Update();
        worldServer.Update();
        mapHandler.Update();
    }

}
