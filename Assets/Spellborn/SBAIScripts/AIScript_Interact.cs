using System;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBAIScripts
{
    [Serializable] public class AIScript_Interact : AIRegistered
    {
        [FoldoutGroup("Interact")]
        [FieldConst()]
        public string SuccessEvent = string.Empty;

        [FoldoutGroup("Interact")]
        [FieldConst()]
        public string FailEvent = string.Empty;

        [FoldoutGroup("Interact")]
        [FieldConst()]
        public bool LookAtLevelElement;

        [FoldoutGroup("Interact")]
        [FieldConst()]
        public InteractiveLevelElement InteractionObject;

        [FoldoutGroup("Interact")]
        [FieldConst()]
        public byte MenuOption;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_AIController InteractingController;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool Triggered;

        public AIScript_Interact()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local ActorRelation newRelation;
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(SuccessEvent,static.RGB(100,100,255),"SuccessEvent:" @ SuccessEvent,oRelations);
GetTaggedRelations(FailEvent,static.RGB(100,100,255),"FailEvent:" @ FailEvent,oRelations);
if (InteractionObject != None) {                                            
newRelation.mActor = InteractionObject;                                   
newRelation.mDescription = "Interact with";                               
newRelation.mColour = static.RGB(100,255,100);                            
oRelations[oRelations.Length] = newRelation;                              
}
}
protected function OnUnRegister(RegisteredAI aRegisteredAI) {
if (InteractingController != None
&& aRegisteredAI.Controller == InteractingController) {
GotoState('ReadyState');                                                  
}
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
GotoState('ReadyState');                                                    
}
state InteractingState {
event bool OnTick(Game_AIController aController,float DeltaTime) {
if (aController == InteractingController) {                             
if (!InteractionObject.IsActivated
|| InteractionObject.mTargetPawn != Game_Pawn(aController.Pawn)) {
if (SuccessEvent != "" && SuccessEvent != "none") {                 
TriggerEvent(name(SuccessEvent),self,aController.Pawn);           
}
ChangeToNextScript(InteractingController);                          
GotoState('ReadyState');                                            
}
}
return OnTick(aController,DeltaTime);                                   
}
function bool AnnotationDone(Game_AIController aController) {
return False;                                                           
}
function EndState() {
ContinueAI(InteractingController);                                      
}
function BeginState() {
PauseAI(InteractingController);                                         
if (LookAtLevelElement) {                                               
LookAt(InteractingController,InteractionObject.Location);             
}
if (!InteractionObject.sv_OnRadialMenuOption(Game_Pawn(InteractingController.Pawn),MenuOption)) {
if (FailEvent != "" && FailEvent != "none") {                         
TriggerEvent(name(FailEvent),self,InteractingController.Pawn);      
}
GotoState('ReadyState');                                              
}
}
}
state MovingInInteractionRangeState {
function MoveIntoPosition(Game_AIController aController) {
local Vector InteractionPosition;
InteractionPosition = InteractionObject.Location + InteractionObject.ActionPositionOffset;
if (VSize(aController.Pawn.Location - InteractionPosition) > InteractionObject.RequiredProximity) {
MoveTo(aController,InteractionPosition,InteractionObject.RequiredProximity * 0.60000002);
GotoState('MovingInInteractionRangeState');                           
} else {                                                                
GotoState('InteractingState');                                        
}
}
event bool OnUnreachable(Game_AIController aController,SBPoint aControlPoint,Vector aDestination) {
if (aController == InteractingController) {                             
GotoState('ReadyState');                                              
}
return OnUnreachable(aController,aControlPoint,aDestination);           
}
event bool OnArrived(Game_AIController aController,SBPoint aControlPoint,SBPoint aDestinationPoint,Vector aLocation) {
if (aController == InteractingController) {                             
MoveIntoPosition(aController);                                        
}
return OnArrived(aController,aControlPoint,aDestinationPoint,aLocation);
}
function bool AnnotationDone(Game_AIController aController) {
return False;                                                           
}
function EndState() {
ContinueAI(InteractingController);                                      
}
function BeginState() {
PauseAI(InteractingController);                                         
MoveIntoPosition(InteractingController);                                
}
}
auto state ReadyState {
event bool OnStateBegin(Game_AIController aController,AIState aState) {
if (aController == InteractingController
&& aState.IsA('AIIdleState')
&& Triggered) {
GotoState('MovingInInteractionRangeState');                           
}
return OnStateBegin(aController,aState);                                
}
event Trigger(Actor Other,Pawn EventInstigator) {
if (GetRegisterSize() > 0) {                                            
Triggered = True;                                                     
InteractingController = GetRandomRegistered().Controller;             
if (InAIState(InteractingController,'AIIdleState')
|| Other.IsA('AIPoint')) {
GotoState('MovingInInteractionRangeState');                         
} else {                                                              
Idle(InteractingController);                                        
}
}
}
function BeginState() {
Triggered = False;                                                      
}
}
*/