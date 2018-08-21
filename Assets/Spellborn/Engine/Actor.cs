using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Engine
{
    [Serializable]
    public class Actor: UObject
    {
        public const float MINFLOORZ = 0.7F;

        public const float MAXSTEPHEIGHT = 25F;

        [HideInInspector]
        public eSBNetworkRoles SBRole;

        [FoldoutGroup("Advanced")]
        [HideInInspector]
        public bool bHidden;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public EPhysics Physics;

        [HideInInspector]
        public ENetRole Role;

        [FieldConst()]
        public LevelInfo Level;

        [FoldoutGroup("Events")]
        public NameProperty Tag;

        [FoldoutGroup("Events")]
        public NameProperty Event;

        [FoldoutGroup("Object")]
        public NameProperty InitialState;

        [FoldoutGroup("Object")]
        public NameProperty Group;

        [FoldoutGroup("Object")]
        public List<ActorGroup> ActorGroups = new List<ActorGroup>();

        [FieldConst()]
        [NonSerialized, HideInInspector]
        public PhysicsVolume PhysicsVolume;

        public Actor Owner;

        [FoldoutGroup("Movement")]
        [NonSerialized, HideInInspector]
        public Vector Velocity;

        [FoldoutGroup("Movement")]
        public Vector Location;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public Rotator Rotation;

        [FoldoutGroup("Movement")]
        public Rotator RotationRate = new Rotator(4096, 50000, 3072);

        [FoldoutGroup("Events")]
        [ArraySizeForExtraction(Size = 8)]
        public NameProperty[] ExcludeTag = new NameProperty[0];

        [ArraySizeForExtraction(Size = 10)]
        public string[] StatsGroups = new string[0];

        #region Unity Events

        void OnDestroyed()
        {
            Destroyed();
        }
        #endregion

        #region Enums
        public enum EOwningDepartmentType
        {
            ODT_None,

            ODT_Level,

            ODT_Sound,

            EOwningDepartmentType_RESERVED_3,

            ODT_Gameplay,
        }

        public enum eKillZType
        {
            KILLZ_None,

            KILLZ_Lava,

            KILLZ_Suicide,
        }

        public enum ETravelType
        {
            TRAVEL_Absolute,

            TRAVEL_Partial,

            TRAVEL_Relative,
        }

        public enum ENetRole
        {
            ROLE_None,

            ROLE_DumbProxy,

            ROLE_SimulatedProxy,

            ROLE_AutonomousProxy,

            ROLE_Authority,
        }

        public enum EPhysics
        {
            PHYS_None,

            PHYS_Walking,

            PHYS_Falling,

            PHYS_Swimming,

            PHYS_Flying,

            PHYS_Rotating,

            PHYS_Projectile,

            PHYS_Interpolating,

            PHYS_MovingBrush,

            PHYS_Spider,

            PHYS_Trailer,

            PHYS_Ladder,

            PHYS_RootMotion,

            PHYS_Karma,

            PHYS_KarmaRagDoll,

            PHYS_Hovering,

            PHYS_CinMotion,

            PHYS_DragonFlying,

            PHYS_Jumping,

            PHYS_SitGround,

            PHYS_SitChair,

            PHYS_Submerged,

            PHYS_Turret,
        }

        public enum EResidence
        {
            RES_ServerClient,

            RES_ClientOnly,

            RES_ServerOnly,
        }

        public enum EFilterState
        {
            FS_Maybe,

            FS_Yes,

            FS_No,
        }

        public enum ERelevancyRange
        {
            RelevancyNear,

            RelevancyNormal,

            RelevancyFar,

            RelevancyVeryFar,

            RelevancyWorld,
        }

        public enum eSBNetworkRoles
        {
            sbROLE_None,

            sbROLE_Server,

            sbROLE_Proxy,

            sbROLE_DBProxy,

            sbROLE_Client,

            sbROLE_RelevantLod0,

            sbROLE_RelevantLod1,

            sbROLE_RelevantLod2,

            sbROLE_RelevantLod3,

            sbROLE_ServerLocal,

            sbROLE_ClientLocal,
        }
        #endregion

        public void SetOwner(Actor newOwner)
        {
            if (Owner != null) Owner.LostChild(this);
            if (newOwner != null) newOwner.GainedChild(this);
            Owner = newOwner;
        }

        protected virtual void GainedChild(Actor other) { }
        protected virtual void LostChild(Actor Other) { }

        public virtual void SetInitialState()
        {
            //bScriptInitialized = True;
            if (!string.IsNullOrEmpty(InitialState) && InitialState != "None") GotoState(InitialState);
            else GotoState("Auto");
        }

        public virtual void SetPhysics(EPhysics newPhysics)
        {
            Physics = newPhysics;
        }

        public int GetRelevanceID()
        {
            return gameObject.GetInstanceID();
        }

        public virtual void PreBeginPlay() { }

        public virtual void BeginPlay() { }

        public virtual void PostBeginPlay() { }

        public virtual void Tick(float deltaTime) { }

        protected virtual void GotoState(string state)
        {
            Debug.LogWarning("TODO implement GoToState, called for: " + state);
        }

        public virtual void OnCreateComponents() { }

        public virtual void Destroyed() { }

        public void SetCollision(bool NewColActors = false, bool NewBlockActors = false)
        {
            Debug.LogWarning("SetCollision not implemented");
        }
    }
}
/*
final native function GetTaggedRelations(string aTag,Color aColour,string aDescription,out array<ActorRelation> oRelations);
event cl_NotifyUnderCursor(bool aSetting);
event RadialMenuSelect(Pawn aPlayerPawn,byte aMainOption,byte aSubOption) {
}
function Material RadialMenuImage(Pawn aPlayerPawn,byte aMainOption,byte aSubOption) {
return None;                                                                
}
event RadialMenuCollect(Pawn aPlayerPawn,byte aMainOption,out array<byte> aMainOptions) {
}
function bool BlocksShotAt(Actor Other) {
return False;                                                               
}
function PawnBaseDied();
function bool IsStationary() {
return True;                                                                
}
function NotifyLocalPlayerTeamReceived();
function NotifyLocalPlayerDead(PlayerController PC);
function SetDelayedDamageInstigatorController(Controller C);
function bool TeamLink(int TeamNum) {
return False;                                                               
}
function bool SelfTriggered() {
return False;                                                               
}
simulated function bool EffectIsRelevant(Vector SpawnLocation,bool bForceDedicated) {
local PlayerController P;
local bool bResult;
if (Level.NetMode == 1) {                                                   
return bForceDedicated;                                                   
}
if (Level.NetMode != 3) {                                                   
bResult = True;                                                           
} else {                                                                    
if (Instigator != None && Instigator.IsHumanControlled()) {               
return True;                                                            
} else {                                                                  
if (SpawnLocation == Location) {                                        
bResult = Level.TimeSeconds - LastRenderTime < 3;                     
} else {                                                                
if (Instigator != None
&& Level.TimeSeconds - Instigator.LastRenderTime < 3) {
bResult = True;                                                     
}
}
}
}
if (bResult) {                                                              
P = Level.GetLocalPlayerController();                                     
if (P == None || P.ViewTarget == None) {                                  
bResult = False;                                                        
} else {                                                                  
if (P.Pawn == Instigator) {                                             
bResult = CheckMaxEffectDistance(P,SpawnLocation);                    
} else {                                                                
if (vector(P.Rotation) Dot (SpawnLocation - P.ViewTarget.Location) < 0.00000000) {
bResult = VSize(P.ViewTarget.Location - SpawnLocation) < 1600;      
} else {                                                              
bResult = CheckMaxEffectDistance(P,SpawnLocation);                  
}
}
}
}
return bResult;                                                             
}
simulated function bool CheckMaxEffectDistance(PlayerController P,Vector SpawnLocation) {
return !P.BeyondViewDistance(SpawnLocation,0.00000000);                     
}

function Vector GetCollisionExtent() {
local Vector Extent;
Extent = CollisionRadius * vect(1.000000, 1.000000, 0.000000);              
Extent.Z = CollisionHeight;                                                 
return Extent;                                                              
}
simulated function bool CanSplash() {
return False;                                                               
}
function PlayTeleportEffect(bool bOut,bool bSound);
function bool IsInPain() {
local PhysicsVolume V;
foreach TouchingActors(Class'PhysicsVolume',V) {                            
if (V.bPainCausing && V.DamagePerSec > 0) {                               
return True;                                                            
}
}
return False;                                                               
}
function bool IsInVolume(Volume aVolume) {
local Volume V;
foreach TouchingActors(Class'Volume',V) {                                   
if (V == aVolume) {                                                       
return True;                                                            
}
}
return False;                                                               
}
final native function UntriggerEvent(name EventName,Actor Other,Pawn EventInstigator);
final native function TriggerEvent(name EventName,Actor Other,Pawn EventInstigator);
function Reset();
simulated function StartInterpolation() {
GotoState('None');                                                          
SetCollision(True,False);                                                   
bCollideWorld = False;                                                      
bInterpolating = True;                                                      
SetPhysics(0);                                                              
}
final simulated function bool TouchingActor(Actor A) {
local Vector dir;
dir = Location - A.Location;                                                
if (Abs(dir.Z) > CollisionHeight + A.CollisionHeight) {                     
return False;                                                             
}
dir.Z = 0.00000000;                                                         
return VSize(dir) <= CollisionRadius + A.CollisionRadius;                   
}
final simulated function bool NearSpot(Vector Spot) {
local Vector dir;
dir = Location - Spot;                                                      
if (Abs(dir.Z) > CollisionHeight) {                                         
return False;                                                             
}
dir.Z = 0.00000000;                                                         
return VSize(dir) <= CollisionRadius;                                       
}

simulated function string GetHumanReadableName() {
return GetItemName(string(Class));                                          
}
function POVChanged(PlayerController PC,bool bBehindViewChanged);
function BecomeViewTarget();
event TravelPostAccept();
event TravelPreAccept();
function bool CheckForErrors() {
return False;                                                               
}
simulated function HurtRadius(float DamageAmount,float DamageRadius,class<DamageType> DamageType,float Momentum,Vector HitLocation) {
local Actor Victims;
local float damageScale;
local float dist;
local Vector dir;
if (bHurtEntry) {                                                           
return;                                                                   
}
bHurtEntry = True;                                                          
foreach VisibleCollidingActors(Class'Actor',Victims,DamageRadius,HitLocation) {
if (Victims != self && Victims.SBRole == 1
&& !Victims.IsA('FluidSurfaceInfo')) {
dir = Victims.Location - HitLocation;                                   
dist = FMax(1.00000000,VSize(dir));                                     
dir = dir / dist;                                                       
damageScale = 1.00000000 - FMax(0.00000000,(dist - Victims.CollisionRadius) / DamageRadius);
Victims.TakeDamage(damageScale * DamageAmount,Instigator,Victims.Location - 0.50000000 * (Victims.CollisionHeight + Victims.CollisionRadius) * dir,damageScale * Momentum * dir,DamageType);
}
}
bHurtEntry = False;                                                         
}

final native(321) iterator function CollidingActors(class<Actor> BaseClass,out Actor Actor,float Radius,optional Vector loc);
final native(312) iterator function VisibleCollidingActors(class<Actor> BaseClass,out Actor Actor,float Radius,optional Vector loc,optional bool bIgnoreHidden);
final native(311) iterator function VisibleActors(class<Actor> BaseClass,out Actor Actor,optional float Radius,optional Vector loc);
final native(310) iterator function RadiusActors(class<Actor> BaseClass,out Actor Actor,float Radius,optional Vector loc);
final native(309) iterator function TraceActors(class<Actor> BaseClass,out Actor Actor,out Vector HitLoc,out Vector HitNorm,Vector End,optional Vector Start,optional Vector Extent);
final native(307) iterator function TouchingActors(class<Actor> BaseClass,out Actor Actor);
final native(306) iterator function BasedActors(class<Actor> BaseClass,out Actor Actor);
final native(305) iterator function ChildActors(class<Actor> BaseClass,out Actor Actor);
final native(313) iterator function DynamicActors(class<Actor> BaseClass,out Actor Actor,optional name MatchTag);
final native(304) iterator function AllActors(class<Actor> BaseClass,out Actor Actor,optional name MatchTag);
final native function GameInfo GetGameInfo();
final native function ResetStaticFilterState();
event PostTeleport(Teleporter OutTeleporter);
event bool PreTeleport(Teleporter InTeleporter);
final native function Vector SuggestFallVelocity(Vector Destination,Vector Start,float MaxZ,float MaxXYSpeed);
final native(532) function bool PlayerCanSeeMe();
final native(512) function MakeNoise(float Loudness);
final native(569) function ChangeBaseParamsFeedbackEffect(string EffectName,optional float DirectionX,optional float DirectionY,optional float Gain);
final native(568) function ChangeSpringFeedbackEffect(string EffectName,float CenterX,float CenterY);
final native(567) function StopFeedbackEffect(optional string EffectName);
final native(566) function PlayFeedbackEffect(string EffectName);
native function StopSBSoundTypes(byte aSoundType);
native function StopAudio(int aTrackHandle,optional Actor aOwner,optional float aFadeOutTime);
native function int PlaySBSound(Sound Sound,float Volume,float Pitch,float Radius,optional Vector SoundSourceOffset,optional byte AudioType);
event PostLoadSavedGame();
event PreSaveGame();
final native(280) function SetTimer(float NewTimerRate,bool bLoop);
event TornOff();
final native(279) function bool Destroy();
final native(278) function Actor Spawn(class<Actor> SpawnClass,optional Actor SpawnOwner,optional name SpawnTag,optional Vector SpawnLocation,optional Rotator SpawnRotation,optional int InstanceID);
final native function bool TraceThisActor(out Vector HitLocation,out Vector HitNormal,Vector TraceEnd,Vector TraceStart,optional Vector Extent);
final native(548) function bool FastTrace(Vector TraceEnd,optional Vector TraceStart);
final native(277) function Actor Trace(out Vector HitLocation,out Vector HitNormal,Vector TraceEnd,optional Vector TraceStart,optional bool bTraceActors,optional Vector Extent,optional out Material Material);
function bool HealDamage(int Amount,Controller Healer,class<DamageType> DamageType);
event TakeDamage(int Damage,Pawn EventInstigator,Vector HitLocation,Vector Momentum,class<DamageType> DamageType);
event KilledBy(Pawn EventInstigator);
simulated event FellOutOfWorld(byte KillType) {
SetPhysics(0);                                                              
Destroy();                                                                  
}
event UsedBy(Pawn User);
event EndedRotation();
event FinishedInterpolation() {
bInterpolating = False;                                                     
}
event RanInto(Actor Other);
event EncroachedBy(Actor Other);
event bool EncroachingOn(Actor Other);
event Actor SpecialHandling(Pawn Other);
event Detach(Actor Other);
event Attach(Actor Other);
event BaseChange();
event Bump(Actor Other);
event UnTouch(Actor Other);
event PostTouch(Actor Other);
event Touch(Actor Other);
event PhysicsVolumeChange(PhysicsVolume NewVolume);
event ZoneChange(ZoneInfo NewZone);
event Landed(Vector HitNormal);
event Falling();
event HitWall(Vector HitNormal,Actor HitWall);
event Timer();
simulated function TimerPop(VolumeTimer t);
event EndEvent();
event BeginEvent();
event UnTrigger(Actor Other,Pawn EventInstigator);
event Trigger(Actor Other,Pawn EventInstigator);
event PostNetReceive();


final native function UnClock(out float Time);
final native function Clock(out float Time);
final native function OnlyAffectPawns(bool B);
final native function DebugUnclock();
final native function DebugClock();
final native function UpdateURL(string NewOption,string NewValue,bool bSaveDefault);
final native function name GetClosestBone(Vector loc,Vector ray,out float boneDist,optional name BiasBone,optional float BiasDistance);
final native function bool AnimIsInGroup(int Channel,name GroupName);
final native function GetAnimParams(int Channel,out name OutSeqName,out float OutAnimFrame,out float OutAnimRate);
final native function LockRootMotion(int Lock);
final native function Actor FindAttachment(name ActorName,name BoneName);
final native function Rotator GetRootRotationDelta();
final native function Vector GetRootLocationDelta();
final native function Rotator GetRootRotation();
final native function Vector GetRootLocation();
final native function AnimBlendToAlpha(int Stage,float TargetAlpha,float TimeInterval);
final native function AnimBlendParams(int Stage,optional float BlendAlpha,optional float InTime,optional float OutTime,optional name BoneName,optional bool bGlobalPose);
final native function LinkMesh(Mesh NewMesh,optional bool bKeepAnim);
final native function LinkSkelAnim(MeshAnimation Anim,optional Mesh NewMesh);
final native function int GetNotifyChannel();
final native function EnableChannelNotify(int Channel,int Switch);
event AnimEnd(int Channel);
final native function AnimStopLooping(optional int Channel);
final native function bool IsTweening(int Channel);
final native function SetAnimFrame(float Time,optional int Channel,optional int UnitFlag);
final native function FreezeAnimAt(float Time,optional int Channel);
final native function StopAnimating(optional bool ClearAllButBase);
final native(263) function bool HasAnim(name Sequence);
final native(261) latent function FinishAnim(optional int Channel);
final native(282) function bool IsAnimating(optional int Channel);
final native(294) function bool TweenAnim(name Sequence,float Time,optional int Channel);
final native(260) function bool LoopAnim(name Sequence,optional float Rate,optional float TweenTime,optional int Channel);
final native(259) function bool PlayAnim(name Sequence,optional float Rate,optional float TweenTime,optional int Channel);
final native function string GetMeshName();
native function bool IsBehind(Actor Other,optional int MinYaw,optional int MaxYaw);
final native function bool IsJoinedTo(Actor Other);
final native(298) function SetBase(Actor NewBase,optional Vector NewFloor);
native function bool IsGrounded();
native function MoveNoChecks(Vector DeltaLocation);
final native(3969) function bool MoveSmooth(Vector delta);
final native function bool SetRelativeLocation(Vector NewLocation);
final native function bool SetRelativeRotation(Rotator NewRotation);
final native event bool SetRotation(Rotator NewRotation);
final native(267) function bool SetLocation(Vector NewLocation);
final native(266) function bool Move(Vector delta);
final native function SetDrawType(byte NewDrawType);
final native function SetStaticMesh(StaticMesh NewStaticMesh);
final native function SetDrawScale3D(Vector NewScale3D);
final native function SetDrawScale(float NewScale);
final native(283) function bool SetCollisionSize(float NewRadius,float NewHeight);
final native function EndLatentFunction();
final native(256) latent function Sleep(float Seconds);
final static native function bool ShouldBeHidden();
final native(233) function Error(coerce string s);
native function CopyObjectToClipboard(Object Obj);
native function string ConsoleCommand(string Command,optional bool bWriteToLog);
function bool IsValidActor() {
return True;                                                                
}
event bool ShouldTickPhysics() {
return True;                                                                
}
event cl_OnGroupChange(int newGroupFlags);
event cl_OnUpdate();
event cl_OnBaseline();
event cl_OnTick(float delta);
final static native function GameEngine GetGameEngine();
final native(265) function TickStatsGroup();
final native(268) function InitStatsGroup();
*/
