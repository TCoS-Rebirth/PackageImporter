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
    
    
    public class QR_QuestPoints : Quest_Reward
    {
        
        [FieldCategory(Category="reward")]
        [FieldConst()]
        public int QP;
        
        [FieldCategory(Category="reward")]
        [FieldConst()]
        public int QPFrac;
        
        public QR_QuestPoints()
        {
        }
    }
}
/*
function string GetText() {
return string(QP)
@ Class'SBGamePlayStrings'.default.Quest_Points.Text;
}
*/
