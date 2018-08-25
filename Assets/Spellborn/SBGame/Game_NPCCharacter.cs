using System;

namespace SBGame
{
    [Serializable] public class Game_NPCCharacter : Game_Character
    {
        public Game_NPCCharacter()
        {
        }
    }
}
/*
function string cl_GetBaseFullName() {
if (Outer.NPCType != None) {                                                
return Outer.NPCType.GetLongName();                                       
} else {                                                                    
return "<Unqualified Unnamed>";                                           
}
}
function string cl_GetBaseName() {
if (Outer.NPCType != None) {                                                
return Outer.NPCType.GetShortName();                                      
} else {                                                                    
return "<unnamed>";                                                       
}
}
*/