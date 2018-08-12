

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
    
    
    [System.Serializable] public class Spawn_Deployer : Spawn_Group
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("Spawn")]
        public List<NPC_Type> Bosses = new List<NPC_Type>();
        
        public Spawn_Deployer()
        {
        }
    }
}
