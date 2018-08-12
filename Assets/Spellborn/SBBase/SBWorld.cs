using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBBase
{
    [InlineEditor(InlineEditorObjectFieldModes.Foldout)]
    [Serializable]
    public class SBWorld : UObject
    {
        public MapIDs worldID;

        [FoldoutGroup("world")]
        public string WorldName = string.Empty;

        [FoldoutGroup("world")]
        public string WorldFile = string.Empty;

        [FoldoutGroup("world")]
        public Base_GameInfo GameInfo;

        [FoldoutGroup("world")]
        public SBWorldRules GameRules;

        [FoldoutGroup("world")]
        public eZoneWorldTypes WorldType;

        [FoldoutGroup("world")]
        public int InstanceMaxPlayers;

        [FoldoutGroup("world")]
        public int InstanceMaxInstances;

        [FoldoutGroup("world")]
        public int InstanceLingerTime;

        [FoldoutGroup("world")]
        public bool InstanceAutoDestroy;

        [FoldoutGroup("world")]
        public bool FreeToPlayAllowed;

        public List<SBRoute> ExitRoutes = new List<SBRoute>();

        public List<SBPortal> EntryPortals = new List<SBPortal>();

        public List<SBTravel> TravelNPCs = new List<SBTravel>();

        [FoldoutGroup("world")]
        public float WorldWeight;

        public SBWorld()
        {
        }

        public enum eZoneWorldTypes
        {
            eZoneWorldTypes_RESERVED_0,

            ZWT_PERSISTENT,

            ZWT_INSTANCED,

            eZoneWorldTypes_RESERVED_3,

            ZWT_SUBINSTANCED,
        }
    }
}