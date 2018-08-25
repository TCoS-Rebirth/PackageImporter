

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
    
    
    [System.Serializable] public class TooltipActor : Actor
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("TooltipActor")]
        public LocalizedString mTooltipText;
        
        public TooltipActor()
        {
        }
    }
}
/*
event string GetTooltipText() {
return mTooltipText.Text;                                                   
}
*/
