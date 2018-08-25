using System;
using System.Collections.Generic;
using Database;
using Engine;
using Gameplay;
using SBBase;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu]
public class GameResources : ScriptableObject
{

    [SerializeField, InlineEditor(InlineEditorObjectFieldModes.Foldout)] SBUniverse universe;

    [SerializeField, InlineEditor(InlineEditorObjectFieldModes.Foldout)] CharacterCreationItemSets ccItemSets;

    [AssetList(Path = "Packages", AutoPopulate = true)]
    [SerializeField] List<SBResourcePackage> packages = new List<SBResourcePackage>();

    Dictionary<int, UObject> resourceCache = new Dictionary<int, UObject>();

    [SerializeField] Game_PlayerController playerPrefab;
    [SerializeField] Game_NPCController npcPrefab;

    [SerializeField] LevelProgression levelProgression;

    static GameResources instance;

    public static GameResources Instance
    {
        get
        {
            if (instance != null) return instance;
            instance = Resources.FindObjectsOfTypeAll<GameResources>()[0];
            return instance;
        }
    }

    void OnEnable()
    {
        instance = this;
    }

    public SBUniverse Universe
    {
        get { return universe; }
    }

    public CharacterCreationItemSets CCItemSets
    {
        get { return ccItemSets; }
    }

    public Game_PlayerController PlayerPrefab
    {
        get { return playerPrefab; }
    }

    public Game_NPCController NPCPrefab
    {
        get { return npcPrefab; }
    }

    public LevelProgression LevelProgression
    {
        get { return levelProgression; }
    }

    public SBResourcePackage GetPackage(string packageName)
    {
        for (var i = 0; i < packages.Count; i++)
        {
            if (packages[i].name.Equals(packageName, StringComparison.OrdinalIgnoreCase)) return packages[i];
        }
        return null;
    }

    void LoadResourceCache()
    {
        var objs = new List<UObject>();
        for (var i = 0; i < packages.Count; i++)
        {
            objs.Clear();
            packages[i].GetComponentsInChildren(objs);
            for (var j = 0; j < objs.Count; j++)
            {
                if (objs[j].ResourceID > 0) resourceCache[objs[j].ResourceID] = objs[j];
            }
        }
    }

    public T GetResource<T>(int id) where T : UObject
    {
        if (resourceCache.Count == 0) LoadResourceCache();
        UObject result;
        if (resourceCache.TryGetValue(id, out result))
        {
            return result as T;
        }
        return null;
    }

    /// <summary>
    /// slow, should be used in editor only
    /// </summary>
    public T FindResource<T>(Predicate<T> predicate) where T : UObject
    {
        if (resourceCache.Count == 0) LoadResourceCache();
        var objs = new List<T>();
        for (var i = 0; i < packages.Count; i++)
        {
            objs.Clear();
            packages[i].GetComponentsInChildren(objs);
            for (var j = 0; j < objs.Count; j++)
            {
                if (predicate(objs[j])) return objs[j];
            }
        }
        return null;
    }
}