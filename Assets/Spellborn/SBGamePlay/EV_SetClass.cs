using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_SetClass : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public byte DesiredClass;

        public EV_SetClass()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
local export editinline Game_PlayerStats playerStats;
playerStats = Game_PlayerStats(aSubject.CharacterStats);                    
playerStats.sv_SetClass(DesiredClass);                                      
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
local export editinline Game_PlayerStats playerStats;
playerStats = Game_PlayerStats(aSubject.CharacterStats);                    
if (playerStats == None) {                                                  
return False;                                                             
}
return True;                                                                
}
*/