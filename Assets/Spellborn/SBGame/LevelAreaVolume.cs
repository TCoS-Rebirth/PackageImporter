using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class LevelAreaVolume : Volume
    {
        [FoldoutGroup("LevelAreaVolume")]
        public Actor TriggeredActor;

        [FoldoutGroup("LevelAreaVolume")]
        public string RespawnPoint = string.Empty;

        [FoldoutGroup("LevelAreaVolume")]
        public LocalizedString LevelAreaName;

        [FoldoutGroup("ShardMap")]
        public bool IsShardMap;

        [FoldoutGroup("ShardMap")]
        public int MapSectionID;

        [FoldoutGroup("ShardMap")]
        public bool IsDiscovered;

        [FoldoutGroup("ShardMap")]
        public string mGEDFile = string.Empty;

        [FoldoutGroup("PvP")]
        public PvPSettings PvPSettings;

        public LevelAreaVolume()
        {
        }
    }
}
/*
event Touch(Actor anActor) {
if (SBRole == 9 || SBRole == 1) {                                           
if (TriggeredActor != None && anActor.IsA('Game_PlayerPawn')) {           
TriggeredActor.Trigger(self,Game_PlayerPawn(anActor));                  
}
}
}
*/