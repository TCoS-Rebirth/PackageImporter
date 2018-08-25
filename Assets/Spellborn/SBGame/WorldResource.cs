using System;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class WorldResource : InteractiveLevelElement
    {
        [FoldoutGroup("WorldResource")]
        public WorldResourceManager Manager;

        [FoldoutGroup("WorldResource")]
        public string Animation = string.Empty;

        [FoldoutGroup("WorldResource")]
        public float InteractionTime;

        [FoldoutGroup("WorldResource")]
        public LootTable Loot;

        public WorldResource()
        {
        }
    }
}
/*
event sv_StopOptionActions() {
Super.sv_StopOptionActions();                                               
Manager.DisableResource(self);                                              
}
*/