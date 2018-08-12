using Accounts;
using Database;
using SBBase;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using World;

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

    [Button]
    void FixSceneLighting()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var scene = SceneManager.GetSceneAt(i);
            SceneManager.SetActiveScene(scene);
            UnityEditor.Lightmapping.realtimeGI = false;
            UnityEditor.Lightmapping.bakedGI = false;
            RenderSettings.ambientMode = AmbientMode.Flat;
            RenderSettings.skybox = null;
            UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(scene);
        }
    }

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
