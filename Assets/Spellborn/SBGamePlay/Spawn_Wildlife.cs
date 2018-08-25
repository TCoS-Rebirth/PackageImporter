﻿

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

namespace SBGamePlay
{
    
    
    [System.Serializable] public class Spawn_Wildlife : Spawn_Area
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        [FieldConst()]
        public NPC_Type NPCType;
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public int LevelMin;
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public int LevelMax;
        
        [Sirenix.OdinInspector.FoldoutGroup("Policy")]
        public int SpawnMin;
        
        [Sirenix.OdinInspector.FoldoutGroup("Policy")]
        public int SpawnMax;
        
        [Sirenix.OdinInspector.FoldoutGroup("Policy")]
        public bool UseAbsoluteAmounts;
        
        [Sirenix.OdinInspector.FoldoutGroup("Policy")]
        public float RespawnTime;
        
        [Sirenix.OdinInspector.FoldoutGroup("Policy")]
        public float RespawnVariation;
        
        [Sirenix.OdinInspector.FoldoutGroup("aI")]
        [TypeProxyDefinition(TypeName="AIStateMachine")]
        public System.Type StateMachine;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public int SpawnAmount;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public float mTimer;
        
        public Spawn_Wildlife()
        {
        }
    }
}
/*
event sv_Despawn() {
local int spawnI;
spawnI = 0;                                                                 
while (spawnI < Spawns.Length) {                                            
Spawns[spawnI].sv_Despawn();                                              
Spawns[spawnI] = None;                                                    
spawnI++;                                                                 
}
Spawns.Length = 0;                                                          
SpawnAmount = 0;                                                            
}
*/
