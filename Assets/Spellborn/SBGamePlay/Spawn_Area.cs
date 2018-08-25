

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
    
    
    [System.Serializable] public class Spawn_Area : NPC_Spawner
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("Policy")]
        public float MaxSpawnDistance;
        
        [Sirenix.OdinInspector.FoldoutGroup("Policy")]
        public bool LoSSpawning;
        
        [Sirenix.OdinInspector.FoldoutGroup("Policy")]
        public float MaxSpawnHeight;
        
        public Spawn_Area()
        {
        }
    }
}
