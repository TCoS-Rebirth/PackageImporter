using System;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Game_DebugUtils : Base_Component
    {
        [NonSerialized] public bool mTestTrace;
        [NonSerialized] public int mLoadingScreenHandle;
        private bool mStartPoll;
        private float mLastPollTime;
        private byte mEquippedWeaponType;
        private bool mUseWeaponOVerride;
        private Game_NPCPawn mNPCViewTarget;
        [NonSerialized, HideInInspector]
        public bool mLogARTimer;

    }
}
/*
protected native function sv2cl_FarMovePawn_CallStub();
event sv2cl_FarMovePawn(Vector L) {
Outer.Pawn.SetLocation(L);                                                  
}
protected native function cl2sv_Die_CallStub();
private event cl2sv_Die() {
Outer.Pawn.SetHealth(0.00000000);                                           
}
native function bool sv_Invulnerable(optional bool aInvulnerable);
protected native function cl2sv_SetTime_CallStub();
protected event cl2sv_SetTime(float aRelTimeOfDay) {
local export editinline SBClock Clock;
local float NewVal;
Clock = Game_Pawn(Outer.Pawn).GetClock();                                   
if (Clock != None) {                                                        
NewVal = Clock.SetFixedRelativeTimeOfDay(aRelTimeOfDay);                  
goto jl004B;                                                              
}
}
function cl_OnFrame(float DeltaTime) {
local Game_PlayerPawn gpp;
if (mLogARTimer && Outer.Pawn.IsLocalPlayer()) {                            
gpp = Game_PlayerPawn(Outer.Pawn);                                        
if (gpp != None && gpp.mPersistentData != None) {                         
}
}
}
function cl_OnTick(float DeltaTime) {
}
protected native function cl2sv_OnStart_CallStub();
private event cl2sv_OnStart() {
local Game_Pawn gp;
local Actor PlayerStart;
gp = Game_Pawn(Outer.Pawn);                                                 
PlayerStart = Outer.GetGameInfo().FindPlayerStart();                        
if (PlayerStart == None) {                                                  
return;                                                                   
}
if (gp != None) {                                                           
gp.sv_TeleportTo(PlayerStart.Location,PlayerStart.Rotation);              
if (gp.CharacterStats != None) {                                          
gp.CharacterStats.sv_Resurrect();                                       
}
gp.TriggerEvent(PlayerStart.Event,PlayerStart,gp);                        
} else {                                                                    
Outer.Pawn.SetLocation(PlayerStart.Location);                             
}
}
exec function TrackPreviousNPC() {
local Game_NPCPawn current;
local Game_NPCPawn previous;
foreach Outer.Pawn.AllActors(Class'Game_NPCPawn',current) {                 
if (current == mNPCViewTarget) {                                          
if (previous == None) {                                                 
Outer.SetViewTarget(Outer.Pawn);                                      
} else {                                                                
mNPCViewTarget = previous;                                            
Outer.SetViewTarget(mNPCViewTarget);                                  
}
return;                                                                 
}
previous = current;                                                       
}
mNPCViewTarget = previous;                                                  
Outer.SetViewTarget(mNPCViewTarget);                                        
}
*/