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
using Framework.Attributes;

namespace SBGamePlay
{
    
    
    [System.Serializable] public class QT_Defeat : Quest_Target
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("Defeat")]
        [FieldConst()]
        public NPC_Type Target;
        
        [Sirenix.OdinInspector.FoldoutGroup("Defeat")]
        [FieldConst()]
        public float DefeatFraction;
        
        [Sirenix.OdinInspector.FoldoutGroup("Defeat")]
        [FieldConst()]
        public Conversation_Topic LastWords;
        
        public QT_Defeat()
        {
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
if (aItem.Tag == "T") {                                                     
return Target.GetActiveText(aItem.SubItem);                               
} else {                                                                    
return Super.GetActiveText(aItem);                                        
}
}
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QT_DefeatText.Text;                  
}
*/
