using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class Door : NavigationPoint
    {
        [FoldoutGroup("Door")]
        public NameProperty DoorTag;

        public Mover MyDoor;

        [FoldoutGroup("Door")]
        public NameProperty DoorTrigger;

        public Actor RecommendedTrigger;

        [FoldoutGroup("Door")]
        public bool bInitiallyClosed;

        [FoldoutGroup("Door")]
        public bool bBlockedWhenClosed;

        public bool bDoorOpen;

        public Door()
        {
        }
    }
}
/*
event bool SuggestMovePreparation(Pawn Other) {
if (bDoorOpen) {                                                            
return False;                                                             
}
if (MyDoor.bOpening || MyDoor.bDelaying) {                                  
Other.Controller.WaitForMover(MyDoor);                                    
return True;                                                              
}
if (MyDoor.bDamageTriggered) {                                              
MyDoor.Trigger(Other,Other);                                              
Other.Controller.WaitForMover(MyDoor);                                    
return True;                                                              
}
return False;                                                               
}
function bool ProceedWithMove(Pawn Other) {
if (bDoorOpen || !MyDoor.bDamageTriggered) {                                
return True;                                                              
}
MyDoor.Trigger(Other,Other);                                                
Other.Controller.WaitForMover(MyDoor);                                      
return False;                                                               
}
function Actor SpecialHandling(Pawn Other) {
if (MyDoor == None) {                                                       
return self;                                                              
}
if (MyDoor.BumpType == 0 && !Other.IsPlayerPawn()) {                        
return None;                                                              
}
if (bInitiallyClosed == (bDoorOpen || MyDoor.bOpening || MyDoor.bDelaying)) {
return self;                                                              
}
if (RecommendedTrigger != None) {                                           
if (Trigger(RecommendedTrigger) != None) {                                
return RecommendedTrigger.SpecialHandling(Other);                       
}
return RecommendedTrigger;                                                
}
return self;                                                                
}
function MoverClosed() {
bBlocked = bInitiallyClosed && bBlockedWhenClosed;                          
bDoorOpen = !bInitiallyClosed;                                              
}
function MoverOpened() {
bBlocked = !bInitiallyClosed && bBlockedWhenClosed;                         
bDoorOpen = bInitiallyClosed;                                               
}
function PostBeginPlay() {
local Vector dist;
if (DoorTrigger != 'None') {                                                
foreach AllActors(Class'Actor',RecommendedTrigger,DoorTrigger) {          
goto jl0028;                                                            
}
if (RecommendedTrigger != None) {                                         
dist = Location - RecommendedTrigger.Location;                          
if (Abs(dist.Z) < RecommendedTrigger.CollisionHeight) {                 
dist.Z = 0.00000000;                                                  
if (VSize(dist) < RecommendedTrigger.CollisionRadius) {               
RecommendedTrigger = None;                                          
}
}
}
}
bBlocked = bInitiallyClosed && bBlockedWhenClosed;                          
bDoorOpen = !bInitiallyClosed;                                              
Super.PostBeginPlay();                                                      
}
*/