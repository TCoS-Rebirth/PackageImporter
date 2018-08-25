

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
    
    
    [System.Serializable] public class Spawn_Placed : Spawn_Triggered
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn_Placed")]
        public bool UseRandomLocation;
        
        public Spawn_Placed()
        {
        }
    }
}
