using System;

namespace Engine
{
    [Serializable] public class Ladder : SmallNavigationPoint
    {
        public LadderVolume MyLadder;

        public Ladder LadderList;

        public Ladder()
        {
        }
    }
}
/*
event bool SuggestMovePreparation(Pawn Other) {
if (MyLadder == None) {                                                     
return False;                                                             
}
if (!MyLadder.InUse(Other)) {                                               
MyLadder.PendingClimber = Other;                                          
return False;                                                             
}
Other.Controller.bPreparingMove = True;                                     
Other.Acceleration = vect(0.000000, 0.000000, 0.000000);                    
return True;                                                                
}
*/