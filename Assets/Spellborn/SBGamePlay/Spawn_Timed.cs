

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
    
    
    [System.Serializable] public class Spawn_Timed : Spawn_Triggered
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public float SpawnInterval;
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public bool StopTimerIfWiped;
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public bool OnlyStopTimerOnDespawn;
        
        public float SpawnTimer;
        
        public bool TimerStarted;
        
        public Spawn_Timed()
        {
        }
    }
}
/*
function sv_Despawn() {
if (!OnlyStopTimerOnDespawn) {                                              
Super.sv_Despawn();                                                       
}
TimerStarted = False;                                                       
SpawnTimer = 0.00000000;                                                    
}
*/
