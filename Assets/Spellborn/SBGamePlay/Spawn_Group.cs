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
    
    
    [System.Serializable] public class Spawn_Group : Spawn_Area
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public NPC_Group ClassGroup;
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public NPC_Taxonomy Faction;
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public int MinLevel;
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public int MaxLevel;
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public int PePRank;
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public int rank;
        
        [Sirenix.OdinInspector.FoldoutGroup("Policy")]
        public float RespawnTimeout;
        
        [Sirenix.OdinInspector.FoldoutGroup("Policy")]
        public float RespawnVariation;
        
        [Sirenix.OdinInspector.FoldoutGroup("Policy")]
        public bool SpawnImmediatly;
        
        [Sirenix.OdinInspector.FoldoutGroup("aI")]
        [TypeProxyDefinition(TypeName="AIStateMachine")]
        public System.Type StateMachine;
        
        [Sirenix.OdinInspector.FoldoutGroup("aI")]
        [TypeProxyDefinition(TypeName="NPC_AI")]
        public System.Type GroupMind;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private float mTimer;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private bool mAllDead;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private bool mSomeDead;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public NPC_AI GroupAI;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public List<NPC_Type> Configuration = new List<NPC_Type>();
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public Vector SpawnerLocation;
        
        public Spawn_Group()
        {
        }
    }
}
/*
event sv_Despawn() {
local int spawnI;
spawnI = 0;                                                                 
while (spawnI < Spawns.Length) {                                            
if (Spawns[spawnI] != None && !Spawns[spawnI].IsDead()
&& !Spawns[spawnI].IsDespawned()) {
Spawns[spawnI].sv_Despawn();                                            
Spawns[spawnI] = None;                                                  
}
spawnI++;                                                                 
}
Spawns.Length = 0;                                                          
}
*/
