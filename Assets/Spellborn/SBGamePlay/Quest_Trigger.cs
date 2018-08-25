using System;
using SBGame;

namespace SBGamePlay
{
    [Serializable] public class Quest_Trigger : InsideTrigger
    {
        public Quest_Trigger()
        {
        }
    }
}
/*
function OnLeavePawn(Game_Pawn aPawn) {
local Game_Controller Controller;
Controller = Game_Controller(aPawn.Controller);                             
if (Controller != None && aPawn.SBRole == 1) {                              
Controller.sv_FireHook(Class'Content_Type'.5,self,0);                     
}
Super.OnLeavePawn(aPawn);                                                   
}
function OnEnterPawn(Game_Pawn aPawn) {
local Game_Controller Controller;
Controller = Game_Controller(aPawn.Controller);                             
if (Controller != None && aPawn.SBRole == 1) {                              
Controller.sv_FireHook(Class'Content_Type'.5,self,1);                     
}
Super.OnEnterPawn(aPawn);                                                   
}
*/