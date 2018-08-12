using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_Claustroport : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public NameProperty DestinationTag;

        [FoldoutGroup("Action")]
        [FieldConst()]
        public float MaxDistance;

        [FoldoutGroup("Action")]
        [FieldConst()]
        public bool UseOrientation;

        public EV_Claustroport()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
local Actor A;
local Vector pos;
A = FindClosestActor(Class'Actor',aSubject,DestinationTag);                 
if (A == None) {                                                            
return;                                                                   
}
pos = RandomRadiusLocation(A,MaxDistance,-1.00000000,True,aSubject.GetCollisionExtent(),aSubject.IsGrounded());
if (pos == vect(0.000000, 0.000000, 0.000000)) {                            
return;                                                                   
}
if (UseOrientation) {                                                       
ClaustroportPawn(aSubject,pos,A.Rotation);                                
} else {                                                                    
ClaustroportPawn(aSubject,pos,aSubject.Rotation);                         
}
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
local Actor A;
if (aSubject == None) {                                                     
return False;                                                             
}
A = FindClosestActor(Class'Actor',aSubject,DestinationTag);                 
if (A == None) {                                                            
return False;                                                             
}
return True;                                                                
}
*/