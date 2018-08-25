

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
    
    
    [System.Serializable] public class Spawn_NPC : NPC_Spawner
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        [FieldConst()]
        public NPC_Type NPCType;
        
        [Sirenix.OdinInspector.FoldoutGroup("Policy")]
        public float RespawnTimeout;
        
        [Sirenix.OdinInspector.FoldoutGroup("aI")]
        [TypeProxyDefinition(TypeName="AIStateMachine")]
        public System.Type StateMachine;
        
        public float RespawnTimer;
        
        public Spawn_NPC()
        {
        }
    }
}
/*
event sv_Despawn() {
if (Spawns.Length > 0) {                                                    
Spawns[0].sv_Despawn();                                                   
Spawns.Length = 0;                                                        
}
}
*/
