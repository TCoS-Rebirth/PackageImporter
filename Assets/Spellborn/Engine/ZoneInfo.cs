﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Engine;
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Engine
{
    
    
    [System.Serializable] public class ZoneInfo : Info
    {
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        public SkyZoneInfo SkyZone;
        
        [Sirenix.OdinInspector.FoldoutGroup("ZoneInfo")]
        public NameProperty ZoneTag;
        
        [Sirenix.OdinInspector.FoldoutGroup("ZoneInfo")]
        public string LocationName = string.Empty;
        
        [Sirenix.OdinInspector.FoldoutGroup("ZoneInfo")]
        public float KillZ;
        
        [Sirenix.OdinInspector.FoldoutGroup("ZoneInfo")]
        public byte KillZType;
        
        [Sirenix.OdinInspector.FoldoutGroup("ZoneInfo")]
        public bool bSoftKillZ;
        
        [Sirenix.OdinInspector.FoldoutGroup("ZoneInfo")]
        public bool bTerrainZone;
        
        [Sirenix.OdinInspector.FoldoutGroup("LevelArea")]
        public LocalizedString LevelAreaName;
        
        [Sirenix.OdinInspector.FoldoutGroup("PvP")]
        public PvPSettings PvPSettings;
        
        [Sirenix.OdinInspector.FoldoutGroup("LevelArea")]
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