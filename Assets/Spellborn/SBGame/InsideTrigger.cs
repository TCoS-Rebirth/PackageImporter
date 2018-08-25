using System;
using System.Collections.Generic;
using Engine;

namespace SBGame
{
    [Serializable] public class InsideTrigger : Trigger
    {
        public List<Game_Pawn> PawnsInside = new List<Game_Pawn>();

        public InsideTrigger()
        {
        }
    }
}
/*
final native function bool Inside(Game_Pawn aPawn);
event OnLeavePawn(Game_Pawn aPawn) {
UntriggerEvent(Event,self,aPawn);                                           
}
event OnEnterPawn(Game_Pawn aPawn) {
TriggerEvent(Event,self,aPawn);                                             
}
event bool CheckPawn(Game_Pawn aPawn) {
return True;                                                                
}
*/