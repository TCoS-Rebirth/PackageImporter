using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Engine
{
    [Serializable] public class ZoneInfo : Info
    {
        [NonSerialized, HideInInspector]
        public SkyZoneInfo SkyZone;

        [FoldoutGroup("ZoneInfo")]
        public NameProperty ZoneTag;

        [FoldoutGroup("ZoneInfo")]
        public string LocationName = string.Empty;

        [FoldoutGroup("ZoneInfo")]
        public float KillZ;

        [FoldoutGroup("ZoneInfo")]
        public byte KillZType;

        [FoldoutGroup("ZoneInfo")]
        public bool bSoftKillZ;

        [FoldoutGroup("ZoneInfo")]
        public bool bTerrainZone;

        [FoldoutGroup("LevelArea")]
        public LocalizedString LevelAreaName;

        [FoldoutGroup("PvP")]
        public PvPSettings PvPSettings;

        [FoldoutGroup("LevelArea")]
        public string RespawnPoint = string.Empty;

        public ZoneInfo()
        {
        }
    }
}
/*
event ActorLeaving(Actor Other);
event ActorEntered(Actor Other);
simulated function PreBeginPlay() {
Super.PreBeginPlay();                                                       
LinkToSkybox();                                                             
}
simulated function LinkToSkybox() {
local SkyZoneInfo TempSkyZone;
foreach AllActors(Class'SkyZoneInfo',TempSkyZone,'None') {                  
SkyZone = TempSkyZone;                                                    
}
if (Level.DetailMode == 0) {                                                
foreach AllActors(Class'SkyZoneInfo',TempSkyZone,'None') {                
if (!TempSkyZone.bHighDetail && !TempSkyZone.bSuperHighDetail) {        
SkyZone = TempSkyZone;                                                
}
}
goto jl0117;                                                              
}
if (Level.DetailMode == 1) {                                                
foreach AllActors(Class'SkyZoneInfo',TempSkyZone,'None') {                
if (!TempSkyZone.bSuperHighDetail) {                                    
SkyZone = TempSkyZone;                                                
}
}
goto jl0117;                                                              
}
if (Level.DetailMode == 2) {                                                
foreach AllActors(Class'SkyZoneInfo',TempSkyZone,'None') {                
SkyZone = TempSkyZone;                                                  
}
}
}
final native(308) iterator function ZoneActors(class<Actor> BaseClass,out Actor Actor);
*/