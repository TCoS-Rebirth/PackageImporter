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

namespace SBGame
{
    
    
    [System.Serializable] public class Help_Article : Content_Type
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("Article")]
        public string Tag = string.Empty;
        
        [Sirenix.OdinInspector.FoldoutGroup("Article")]
        public LocalizedString Title;
        
        [Sirenix.OdinInspector.FoldoutGroup("Article")]
        public LocalizedString Body;
        
        [Sirenix.OdinInspector.FoldoutGroup("Article")]
        public List<Help_Article> SubArticles = new List<Help_Article>();
        
        public Help_Article()
        {
        }
    }
}
/*
function string GetBody() {
return Body.Text;                                                           
}
function string GetTitle() {
return Title.Text;                                                          
}
*/
