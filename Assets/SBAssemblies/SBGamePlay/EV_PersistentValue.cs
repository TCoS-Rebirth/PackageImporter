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
    
    
    [System.Serializable] public class EV_PersistentValue : Content_Event
    {
        
        public Content_Type context;
        
        [Sirenix.OdinInspector.FoldoutGroup("Action")]
        public int VariableID;
        
        [Sirenix.OdinInspector.FoldoutGroup("Action")]
        public int Value;
        
        public EV_PersistentValue()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
SetPersistentVariable(aSubject,VariableID,Value);                           
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
if (VariableID < 0) {                                                       
return False;                                                             
}
if (!aSubject.IsPlayerPawn()) {                                             
return False;                                                             
}
return True;                                                                
}
*/
