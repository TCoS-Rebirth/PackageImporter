﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using TCosReborn.Framework.Common;


namespace SBGame
{


    public class Game_ActiveTextItem : SBPackageResource
    {
        
        public int Type;
        
        public string Tag = string.Empty;
        
        public int Ordinality;
        
        public List<string> FreeOptions = new List<string>();
        
        public Game_ActiveTextItem SubItem;
        
        public Game_ActiveTextItem()
        {
        }
        
        public enum EActiveTextString
        {
            
            ATS_None ,
            
            ATS_GenderNoun ,
            
            ATS_GenderGender ,
            
            ATS_GenderObjective ,
            
            ATS_GenderSubjective ,
            
            ATS_GenderPossessive ,
            
            ATS_House ,
            
            ATS_DayPart ,
            
            ATS_Greeting,
        }
        
        public enum EActiveTextType
        {
            
            ATT_None ,
            
            ATT_Speaker ,
            
            ATT_Subject ,
            
            ATT_Target ,
            
            ATT_Reference ,
            
            ATT_World,
        }
    }
}
