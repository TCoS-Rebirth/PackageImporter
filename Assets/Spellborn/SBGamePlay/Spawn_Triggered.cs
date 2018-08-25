﻿using Engine;
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SBGamePlay
{
    [System.Serializable] public class Spawn_Triggered : Spawn_Area
    {
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public Vector SpawnerLocation;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public SpawnConfig CurrentlySpawning;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public int WaveCount;
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public List<SpawnConfig> SpawnerConfig = new List<SpawnConfig>();
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public float MinSpawnsPerWave;
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public float MaxSpawnsPerWave;
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public float MaxSpawnsAlive;
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public float MaxWaves;
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public bool UseChanceAsCount;
        
        [Sirenix.OdinInspector.FoldoutGroup("aI")]
        [TypeProxyDefinition(TypeName="AIStateMachine")]
        public System.Type StateMachine;
        
        [System.Serializable] public struct SpawnConfig
        {
            
            public NPC_Type NPCType;
            
            public NPC_Taxonomy Faction;
            
            public int Chance;
            
            public int MinLevel;
            
            public int MaxLevel;
            
            public int PePRank;
        }
    }
}
/*
function sv_Despawn() {
local int is;
is = 0;                                                                     
while (is < Spawns.Length) {                                                
Spawns[is].sv_Despawn();                                                  
Spawns[is] = None;                                                        
is++;                                                                     
}
Spawns.Length = 0;                                                          
}
function PostBeginPlay() {
local int i;
i = 0;                                                                      
while (i < SpawnerConfig.Length) {                                          
i++;                                                                      
}
Super.PostBeginPlay();                                                      
}
*/
