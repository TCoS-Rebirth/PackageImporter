using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class Volume : Actor
    {
        public Actor AssociatedActor;

        [FoldoutGroup("Volume")]
        public NameProperty AssociatedActorTag;

        [FoldoutGroup("Volume")]
        public string LocationName = string.Empty;

        public Volume()
        {
        }
    }
}
/*
function DisplayDebug(Canvas Canvas,out float YL,out float YPos) {
Super.DisplayDebug(Canvas,YL,YPos);                                         
Canvas.DrawText("AssociatedActor " $ string(AssociatedActor),False);        
YPos += YL;                                                                 
Canvas.SetPos(4.00000000,YPos);                                             
}
function PostBeginPlay() {
Super.PostBeginPlay();                                                      
if (AssociatedActorTag != 'None') {                                         
foreach AllActors(Class'Actor',AssociatedActor,AssociatedActorTag) {      
goto jl002E;                                                            
}
}
if (AssociatedActor != None) {                                              
GotoState('AssociatedTouch');                                             
InitialState = GetStateName();                                            
}
}
native function bool Encompasses(Actor Other);
state AssociatedTouch {
function BeginState() {
local Actor A;
foreach TouchingActors(Class'Actor',A) {                                
Touch(A);                                                             
}
}
event UnTouch(Actor Other) {
AssociatedActor.UnTouch(Other);                                         
}
event Touch(Actor Other) {
if (AssociatedActor != self) {                                          
AssociatedActor.Touch(Other);                                         
goto jl0022;                                                          
}
}
}
*/