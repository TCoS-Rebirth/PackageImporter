using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBAIScripts
{
    [Serializable] public class AIEscortFramework : AIRegistered
    {
        [FoldoutGroup("EscortQuest")]
        public Quest_Type quest;

        [FoldoutGroup("EscortQuest")]
        public int objective;

        [FoldoutGroup("Escort")]
        [TypeProxyDefinition(TypeName = "AIStateMachine")]
        public Type EscortMachine;

        [FoldoutGroup("Escort")]
        public bool Invulnerable;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool FinishDespawn;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float FinishSeconds;

        [FoldoutGroup("EscortSuccess")]
        public string SuccessEvent = string.Empty;

        [FoldoutGroup("EscortSuccess")]
        public LocalizedString ArrivedString;

        [FoldoutGroup("EscortFailure")]
        public LocalizedString FailedString;

        [FoldoutGroup("EscortFailure")]
        public AI_Script FailureScript;

        [FoldoutGroup("EscortFailure")]
        public string FailEvent = string.Empty;

        [FieldConst()]
        public float RecheckQuestTime;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<Game_Pawn> Reservation = new List<Game_Pawn>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<EscortStruct> Escort = new List<EscortStruct>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_Pawn EscortLeader;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool TriggeredByPusher;

        public AIEscortFramework()
        {
        }

        [Serializable] public struct EscortStruct
        {
            public Game_Pawn Pawn;

            public int CharacterID;

            public bool Active;
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local ActorRelation newRelation;
Super.GetActorRelations(oRelations);                                        
if (FailureScript != None) {                                                
newRelation.mActor = FailureScript;                                       
newRelation.mDescription = "FailureScript:" @ string(FailureScript.Name); 
newRelation.mColour = static.RGB(255,255,50);                             
oRelations[oRelations.Length] = newRelation;                              
}
}
protected function Game_Pawn SelectEscortLeader() {
local int i;
local Game_Pawn ret;
local float best_distance;
local float Distance;
ret = None;                                                                 
i = 0;                                                                      
while (i < Escort.Length) {                                                 
if (Escort[i].Active && Escort[i].Pawn != None
&& !Escort[i].Pawn.IsDead()) {
Distance = ComputeDistanceToEscortees(Escort[i].Pawn.Location);         
if (ret == None || Distance < best_distance) {                          
ret = Escort[i].Pawn;                                                 
best_distance = Distance;                                             
}
}
i++;                                                                      
}
Debug("Selecting new escortleader" @ CharName(ret));                        
return ret;                                                                 
}
protected function float ComputeDistanceToEscortees(Vector aPosition) {
local int i;
local array<RegisteredAI> reg;
local float ret;
reg = GetRegister();                                                        
i = 0;                                                                      
while (i < reg.Length) {                                                    
if (reg[i].Controller != None && reg[i].Controller.Pawn != None) {        
ret += VSize(aPosition - reg[i].Controller.Pawn.Location);              
}
i++;                                                                      
}
return ret;                                                                 
}
protected function RegisterEscortee(RegisteredEscort reg) {
local Game_AIController cont;
cont = reg.Controller;                                                      
reg.Invulnerable = GetInvulnerable(cont);                                   
SetInvulnerable(cont,Invulnerable);                                         
reg.Touching = SetTouching(cont,True);                                      
reg.HomeLocation = GetHomeLocation(cont);                                   
if (EscortMachine != None) {                                                
reg.OriginalMachine = SwapStateMachine(cont,new EscortMachine);           
}
}
function bool IsEscort(Game_Pawn aPawn) {
local int i;
if (aPawn == None) {                                                        
return False;                                                             
}
i = 0;                                                                      
while (i < Escort.Length) {                                                 
if (Escort[i].Active && Escort[i].Pawn == aPawn) {                        
return True;                                                            
}
i++;                                                                      
}
return False;                                                               
}
protected function FailEscort(int Index) {
if (Escort[Index].Pawn != None) {                                           
SetQuestProgress(Escort[Index].Pawn,quest,objective,-1);                  
UnregisterEscort(Index);                                                  
} else {                                                                    
SetDBQuestProgress(Escort[Index].CharacterID,quest,objective,-1);         
}
}
protected function UnregisterEscort(int Index) {
Escort[Index].Active = False;                                               
}
protected function RegisterEscort(Game_Pawn aPawn) {
local EscortStruct newEscort;
newEscort.Pawn = aPawn;                                                     
if (aPawn.IsPlayerPawn()) {                                                 
newEscort.CharacterID = Game_PlayerPawn(aPawn).GetCharacterID();          
} else {                                                                    
Warning("Escort" @ CharName(aPawn) @ "is not a player");                  
}
newEscort.Active = True;                                                    
Escort[Escort.Length] = newEscort;                                          
}
protected function bool IsUnavailableForEscort(Game_Pawn aPawn) {
return aPawn == None || aPawn.IsDead();                                     
}
protected function bool HasQuestActive(Game_Pawn aPawn) {
if (quest == None) {                                                        
Failure("Escort script has no quest set");                                
return False;                                                             
} else {                                                                    
if (!quest.Targets[objective].IsA('QT_Escort')) {                         
Failure("Escort script objective" @ string(objective)
@ "of quest"
@ string(quest)
@ "is not of escort type");
return False;                                                           
} else {                                                                  
return Game_PlayerPawn(aPawn).questLog.GetTargetActivation(quest,objective);
}
}
}
protected event AutoFix() {
local AI_ConditionalDespawn despawnScript;
local float despawnTimer;
Super.AutoFix();                                                            
if (NextScript == None && FinishDespawn) {                                  
despawnScript = AI_ConditionalDespawn(SpawnScript(Class'AI_ConditionalDespawn'));
if (despawnScript != None) {                                              
NextScript = despawnScript;                                             
despawnTimer = FinishSeconds;                                           
if (despawnTimer > 60.00000000) {                                       
despawnTimer = 20.00000000;                                           
} else {                                                                
if (despawnTimer <= 0.00000000) {                                     
despawnTimer = 1.00000000;                                          
}
}
despawnScript.DespawnTimeout = despawnTimer;                            
despawnScript.ResettingStates[0] = Class'AIFightState';                 
despawnScript.ResettingStates[1] = Class'AIConversationState';          
}
}
if (FailureScript == None) {                                                
despawnScript = AI_ConditionalDespawn(SpawnScript(Class'AI_ConditionalDespawn'));
if (despawnScript != None) {                                              
FailureScript = despawnScript;                                          
despawnScript.DespawnTimeout = 1.00000000;                              
despawnScript.ResettingStates[0] = Class'AIFightState';                 
}
}
}
state Failed {
function BeginState() {
local int i;
local array<Game_AIController> reg;
reg = GetRegistered();                                                  
if (reg.Length > 0 && FailedString.Id != 0) {                           
LocalizedChat(reg[0],FailedString,quest,EscortLeader);                
}
i = 0;                                                                  
while (i < Escort.Length) {                                             
if (Escort[i].Active) {                                               
FailEscort(i);                                                      
}
i++;                                                                  
}
i = 0;                                                                  
while (i < reg.Length) {                                                
if (reg[i].Pawn != None
&& !Game_Pawn(reg[i].Pawn).IsDead()) {
Idle(reg[i]);                                                       
}
if (FailureScript != None) {                                          
Debug("Switching" @ CharName(reg[i]) @ "to failure script"
@ string(FailureScript));
SwitchScript(reg[i],self,FailureScript);                            
}
i++;                                                                  
}
if (FailEvent != "") {                                                  
TriggerEvent(name(FailEvent),self,None);                              
}
GotoState('Initialize');                                                
}
}
state Finished {
function BeginState() {
local int i;
local array<RegisteredAI> reg;
local export editinline QT_Escort questObjective;
local Game_Pawn Target;
reg = GetRegister();                                                    
if (quest != None
&& QT_Escort(quest.Targets[objective]) != None) {
if (reg.Length > 0 && ArrivedString.Id != 0) {                        
LocalizedChat(reg[0].Controller,ArrivedString,quest,EscortLeader);  
}
if (reg.Length == 1) {                                                
Target = Game_Pawn(reg[0].Controller.Pawn);                         
}
questObjective = QT_Escort(quest.Targets[objective]);                 
i = 0;                                                                
while (i < Escort.Length) {                                           
if (Escort[i].Active) {                                             
SetQuestProgress(Escort[i].Pawn,quest,objective,1,Target);        
}
i++;                                                                
}
if (NextScript != None) {                                             
Debug("Starting next script" @ string(NextScript));                 
ChangeAllToNextScript();                                            
}
if (SuccessEvent != "") {                                             
TriggerEvent(name(SuccessEvent),self,Target);                       
}
} else {                                                                
Warning("Failed to complete escort quest because objective"
@ string(objective)
@ "of quest"
@ string(quest)
@ "is not an escort objective");
}
TriggerEvent(Event,self,None);                                          
if (TriggeredByPusher && NextScript == None) {                          
i = 0;                                                                
while (i < reg.Length) {                                              
StopScript(reg[i].Controller,self);                                 
i++;                                                                
}
} else {                                                                
GotoState('Initialize');                                              
}
}
}
state Active {
function EndState() {
local array<RegisteredAI> reg;
local int i;
local RegisteredEscort R;
local Game_Pawn pwn;
FrameOff();                                                             
reg = GetRegister();                                                    
i = 0;                                                                  
while (i < reg.Length) {                                                
R = RegisteredEscort(reg[i]);                                         
SetInvulnerable(R.Controller,R.Invulnerable);                         
SetTouching(R.Controller,R.Touching);                                 
SetHomeLocation(R.Controller,R.HomeLocation);                         
if (R.OriginalMachine != None) {                                      
SwapStateMachine(R.Controller,R.OriginalMachine);                   
}
pwn = Game_Pawn(R.Controller.Pawn);                                   
if (pwn != None) {                                                    
SetHealth(R.Controller,GetMaxHealth(R.Controller));                 
RemoveAllDuffs(pwn);                                                
}
i++;                                                                  
}
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
Debug("Untriggered, quest failed!");                                    
GotoState('Failed');                                                    
}
function bool OnCheckAlly(Game_AIController aGame_AIController,Game_Pawn aPotentialAlly) {
if (IsEscort(aPotentialAlly)) {                                         
return True;                                                          
}
return False;                                                           
}
protected function OnRegister(RegisteredAI aRegisteredAI) {
Error("Late registration by"
@ CharName(aRegisteredAI.Controller)
@ "is not handled");
}
event bool OnDeath(Game_AIController aController,Actor aDeceasedActor) {
local bool ret;
ret = OnDeath(aController,aDeceasedActor);                              
GotoState('Failed');                                                    
return ret;                                                             
}
protected event sv_OnScriptFrame(float DeltaTime) {
local int i;
sv_OnScriptFrame(DeltaTime);                                            
i = 0;                                                                  
while (i < Escort.Length) {                                             
if (Escort[i].Active) {                                               
if (IsUnavailableForEscort(Escort[i].Pawn)) {                       
Debug("Failing dead or despawned" @ CharName(Escort[i].Pawn));    
FailEscort(i);                                                    
}
}
i++;                                                                  
}
i = 0;                                                                  
while (i < Escort.Length) {                                             
if (Escort[i].Active) {                                               
if (!HasQuestActive(Escort[i].Pawn)) {                              
Debug("Failing escort with abandoned quest"
@ CharName(Escort[i].Pawn));
UnregisterEscort(i);                                              
}
}
i++;                                                                  
}
if (!IsEscort(EscortLeader)) {                                          
EscortLeader = SelectEscortLeader();                                  
}
if (EscortLeader == None) {                                             
GotoState('Failed');                                                  
}
}
function bool OnSpawn(Game_AIController aSpawn,export editinline NPC_Type aType,Vector aLocation) {
OnSpawn(aSpawn,aType,aLocation);                                        
return True;                                                            
}
function BeginState() {
local array<RegisteredAI> reg;
local int i;
local array<Game_Pawn> EscortTeam;
local RegisteredEscort R;
GetTeam(EscortLeader,EscortTeam);                                       
i = 0;                                                                  
while (i < EscortTeam.Length) {                                         
if (HasQuestActive(EscortTeam[i])) {                                  
RegisterEscort(EscortTeam[i]);                                      
}
i++;                                                                  
}
reg = GetRegister();                                                    
i = 0;                                                                  
while (i < reg.Length) {                                                
R = RegisteredEscort(reg[i]);                                         
RegisterEscortee(R);                                                  
i++;                                                                  
}
FrameOn(1.00000000);                                                    
}
}
state Reserved {
function EndState() {
FrameOff();                                                             
}
function CancelReservation() {
Reservation.Length = 0;                                                 
Debug("Reservations canceled");                                         
GotoState('Initialize');                                                
}
protected function OnRegisterEmptied() {
OnRegisterEmptied();                                                    
CancelReservation();                                                    
}
protected event sv_OnScriptFrame(float DeltaTime) {
local int ri;
sv_OnScriptFrame(DeltaTime);                                            
ri = 0;                                                                 
while (ri < Reservation.Length) {                                       
if (IsUnavailableForEscort(Reservation[ri])) {                        
Debug("Reservation canceled for" @ CharName(Reservation[ri]));      
Reservation.Remove(ri,1);                                           
ri--;                                                               
} else {                                                              
if (HasQuestActive(Reservation[ri])) {                              
Debug("Activated by" @ CharName(Reservation[ri]));                
EscortLeader = Reservation[ri];                                   
GotoState('Active');                                              
goto jl00DF;                                                      
}
}
ri++;                                                                 
}
if (Reservation.Length == 0) {                                          
CancelReservation();                                                  
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
local Game_Pawn res;
Trigger(Other,EventInstigator);                                         
if (Other.IsA('AI_Script_Pusher')) {                                    
TriggeredByPusher = True;                                             
Debug("Retriggered by script pusher" @ string(Other));                
} else {                                                                
TriggeredByPusher = False;                                            
}
res = Game_Pawn(EventInstigator);                                       
if (res != None) {                                                      
Reservation[Reservation.Length] = res;                                
}
}
function BeginState() {
FrameOn();                                                              
}
}
auto state Initialize {
event Trigger(Actor Other,Pawn EventInstigator) {
local Game_Pawn res;
Trigger(Other,EventInstigator);                                         
Debug("Triggered by" @ CharName(EventInstigator)
@ "with"
@ string(GetRegisterSize())
@ "registrations");
if (GetRegisterSize() == 0) {                                           
return;                                                               
}
if (Other.IsA('AI_Script_Pusher')) {                                    
TriggeredByPusher = True;                                             
Debug("Triggered by script pusher" @ string(Other));                  
} else {                                                                
TriggeredByPusher = False;                                            
}
res = Game_Pawn(EventInstigator);                                       
if (res != None) {                                                      
if (!res.IsPlayerPawn()) {                                            
Warning("Triggered by " @ CharName(EventInstigator)
@ "who is not a player");
}
Reservation[0] = res;                                                 
Reservation.Length = 1;                                               
GotoState('Reserved');                                                
}
}
function BeginState() {
if (TriggeredByPusher) {                                                
Warning("Script pushed by a script pusher reinitializing. This may cause weirdness");
}
Reservation.Length = 0;                                                 
Escort.Length = 0;                                                      
EscortLeader = None;                                                    
TriggeredByPusher = False;                                              
}
}
*/