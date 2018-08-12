using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIAccompanyScript : AIEscortFramework
    {
        [FoldoutGroup("Escort")]
        public InsideTrigger Destination;

        public NameProperty AloneTag;

        [FoldoutGroup("Escort")]
        public float AloneTimeout;

        [FoldoutGroup("Escort")]
        public LocalizedString LostString;

        [FoldoutGroup("Escort")]
        public LocalizedString FoundString;

        [FoldoutGroup("Escort")]
        public NPC_Habitat Habitat;

        public AIAccompanyScript()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local ActorRelation newRelation;
Super.GetActorRelations(oRelations);                                        
if (Destination != None) {                                                  
newRelation.mActor = Destination;                                         
newRelation.mDescription = "Destination";                                 
newRelation.mColour = static.RGB(255,255,255);                            
oRelations[oRelations.Length] = newRelation;                              
}
}
function OnBegin(Game_AIController aController) {
Super.OnBegin(aController);                                                 
if (Destination == None) {                                                  
Failure("Accompany script has no destination specified");                 
}
}
state Arrived {
function EndState() {
local array<RegisteredAI> reg;
local int i;
reg = GetRegister();                                                    
i = 0;                                                                  
while (i < reg.Length) {                                                
ContinueAI(reg[i].Controller);                                        
i++;                                                                  
}
}
event bool OnUnreachable(Game_AIController aController,SBPoint aControlPoint,Vector aDestination) {
GotoState('Finished');                                                  
return OnUnreachable(aController,aControlPoint,aDestination);           
}
event bool OnArrived(Game_AIController aController,SBPoint aControlPoint,SBPoint aDestinationPoint,Vector aLocation) {
GotoState('Finished');                                                  
return OnArrived(aController,aControlPoint,aDestinationPoint,aLocation);
}
event bool OnStateChange(Game_AIController aController,AIState aState) {
return OnStateChange(aController,aState);                               
}
function bool OnCheckFriendly(Game_AIController aGame_AIController,Game_Pawn potentialEnemy) {
if (IsEscort(potentialEnemy)) {                                         
return True;                                                          
} else {                                                                
return OnCheckFriendly(aGame_AIController,potentialEnemy);            
}
}
function BeginState() {
local array<RegisteredAI> reg;
local int i;
local Vector Dest;
local Game_NPCPawn NPC;
local Vector Extent;
reg = GetRegister();                                                    
if (reg.Length == 1) {                                                  
i = 0;                                                                
while (i < reg.Length) {                                              
PauseAI(reg[i].Controller);                                         
i++;                                                                
}
NPC = Game_NPCPawn(reg[0].Controller.Pawn);                           
if (NPC != None) {                                                    
Extent.X = NPC.NPCType.GetCollisionRadius();                        
Extent.Y = NPC.NPCType.GetCollisionRadius();                        
Extent.Z = NPC.NPCType.GetCollisionHeight();                        
Dest = Class'Content_API'.NearestValidLocation(NPC,Destination.Location,Extent,NPC.IsGrounded());
if (Dest != vect(0.000000, 0.000000, 0.000000)) {                   
Debug("Nearest valid location of" @ string(Destination.Location)
@ "is"
@ string(Dest));
MoveTo(reg[0].Controller,Dest);                                   
}
}
} else {                                                                
Warning("No registered NPCs to arrive at the destination");           
GotoState('Failed');                                                  
}
}
}
state Active {
function EndState() {
Super.EndState();                                                       
}
event bool OnArrived(Game_AIController aController,SBPoint aControlPoint,SBPoint aDestinationPoint,Vector aLocation) {
if (EscortLeader != None) {                                             
SetHomeLocation(aController,EscortLeader.Location);                   
}
return OnArrived(aController,aControlPoint,aDestinationPoint,aLocation);
}
event bool OnDetectAlly(Game_AIController aController,Game_Pawn anAlly) {
local RegisteredAccompany escortee;
if (anAlly == EscortLeader) {                                           
escortee = RegisteredAccompany(GetRegistration(aController));         
if (escortee != None && escortee.Lost) {                              
Debug(CharName(aController.Pawn) @ "Not alone anymore, found"
@ CharName(anAlly)
@ "and leader"
@ CharName(EscortLeader));
escortee.Lost = False;                                              
StopTimer(aController,AloneTag);                                    
if (FoundString.Id != 0) {                                          
LocalizedChat(aController,FoundString,quest,EscortLeader);        
}
Follow(aController);                                                
}
}
return OnDetectAlly(aController,anAlly);                                
}
function bool OnTimerEnded(Game_AIController aGame_AIController,Actor aInstigator,name aTag) {
if (aTag == AloneTag) {                                                 
Debug("Alone timed out, quest failed!");                              
GotoState('Failed');                                                  
return False;                                                         
} else {                                                                
return OnTimerEnded(aGame_AIController,aInstigator,aTag);             
}
}
event bool OnAllyLost(Game_AIController aController,Game_Pawn anAlly) {
local RegisteredAccompany escortee;
Debug("OnAllyLost" @ CharName(anAlly));                                 
if (anAlly == EscortLeader) {                                           
escortee = RegisteredAccompany(GetRegistration(aController));         
if (escortee != None) {                                               
Debug(CharName(aController.Pawn) @ "Lost escort leader"
@ CharName(anAlly)
@ "failing in"
@ string(AloneTimeout));
if (LostString.Id != 0) {                                           
LocalizedChat(aController,LostString,quest,anAlly);               
}
Idle(aController);                                                  
StartTimer(aController,AloneTag,AloneTimeout);                      
escortee.Lost = True;                                               
}
}
return OnAllyLost(aController,anAlly);                                  
}
event bool OnCheckHabitat(Game_AIController aController,Vector aLocation,NPC_Habitat aHabitat) {
return Habitat == None
|| Habitat.CheckHabitat(aLocation);    
}
event bool OnCheckChaseRange(Game_AIController aController,Vector aLocation,float aRange) {
return True;                                                            
}
function bool OnTick(Game_AIController aController,float aDeltaTime) {
if (!OnTick(aController,aDeltaTime)) {                                  
if (Destination.Inside(Game_Pawn(aController.Pawn))) {                
GotoState('Arrived');                                               
}
} else {                                                                
Debug("OnTick: True");                                                
return True;                                                          
}
}
event bool OnStateComplete(Game_AIController aController,AIState aState,byte aResult) {
if (aState.IsA('AIFollowState') && aResult == 4
&& aController.mTargeting.GetTarget() != None) {
Debug(CharName(aController.Pawn)
@ "'s follow failed. Stuck. Teleport");
PauseAI(aController);                                                 
Teleport(aController,EscortLeader.Location,AIFollowState(aState).FollowDistance);
ContinueAI(aController);                                              
} else {                                                                
return OnStateComplete(aController,aState,aResult);                   
}
}
event bool OnStateChange(Game_AIController aController,AIState aState) {
local RegisteredAccompany escortee;
Debug("OnStateChange:" @ string(aState));                               
if (aState.IsA('AIIdleState')) {                                        
escortee = RegisteredAccompany(GetRegistration(aController));         
if (escortee != None && !escortee.Lost) {                             
Follow(aController);                                                
return True;                                                        
}
}
return OnStateChange(aController,aState);                               
}
function BeginState() {
local array<RegisteredAI> reg;
local int i;
Super.BeginState();                                                     
reg = GetRegister();                                                    
i = 0;                                                                  
while (i < reg.Length) {                                                
Follow(reg[i].Controller);                                            
i++;                                                                  
}
}
}
*/