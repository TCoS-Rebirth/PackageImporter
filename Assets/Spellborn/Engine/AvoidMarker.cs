using System;

namespace Engine
{
    [Serializable] public class AvoidMarker : Triggers
    {
        public byte TeamNum;

        public AvoidMarker()
        {
        }
    }
}
/*
function StartleBots() {
local Pawn P;
foreach CollidingActors(Class'Pawn',P,CollisionRadius) {                    
if (RelevantTo(P)) {                                                      
AIController(P.Controller).Startle(self);                               
}
}
}
function bool RelevantTo(Pawn P) {
return AIController(P.Controller) != None;                                  
}
function Touch(Actor Other) {
if (Pawn(Other) != None && RelevantTo(Pawn(Other))) {                       
Pawn(Other).Controller.FearThisSpot(self);                                
}
}
*/