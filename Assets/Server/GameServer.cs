using System.Diagnostics;
using Accounts;
using Database;
using SBBase;
using SBGamePlay;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
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
    static TransientDatabase database;

    WorldServer worldServer;
    LoginServer loginServer;

    [SerializeField, InlineEditor(InlineEditorObjectFieldModes.Foldout)] SBUniverse universe;

    static void RegisterServices()
    {
        sessionHandler = new SessionHandler();
        mapHandler = new MapHandler();
        database = new TransientDatabase();

        ServiceRegistry.AddService<ISessionHandler>(sessionHandler);
        ServiceRegistry.AddService<IMapHandler>(mapHandler);
        ServiceRegistry.AddService<IDatabase>(database);
    }

    void Awake()
    {
        RegisterServices();
        worldServer = new WorldServer(worldIP, worldPort);
        ServiceRegistry.AddService<IWorldServer>(worldServer);
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
        Process.Start(@"C:\Program Files (x86)\The Chronicles of Spellborn\bin\client\Sb_client.exe");
    }
    #endif

    void LoadPersistentWorlds()
    {
        Debug.Log("Loading persistent worlds");
        var loadingStartTime = Time.realtimeSinceStartup;
        foreach (var sbWorld in universe.Worlds)
        {
            if (sbWorld.WorldFile.Contains("\\")) continue;
            if (sbWorld.WorldType == SBWorld.eZoneWorldTypes.ZWT_PERSISTENT) mapHandler.LoadMap(sbWorld.worldID);
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
