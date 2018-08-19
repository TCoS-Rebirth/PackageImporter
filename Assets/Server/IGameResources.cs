using System;
using Database;
using Engine;
using SBBase;
using SBGame;

public interface IGameResources
{
    SBUniverse Universe { get; }
    CharacterCreationItemSets CCItemSets { get; }
    Game_PlayerController PlayerPrefab { get; }
    Game_NPCController NPCPrefab { get; }

    SBResourcePackage GetPackage(string packageName);
    T GetResource<T>(int id) where T : UObject;
    T FindResource<T>(Predicate<T> predicate) where T : UObject;
}