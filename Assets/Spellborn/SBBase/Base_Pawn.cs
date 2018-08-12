using System;
using Engine;
using UnityEngine;

namespace SBBase
{
    [Serializable] public class Base_Pawn : SBAnimatedPawn
    {
        public const float IDEAL_JUMP_SPEED_FOR_ANIM = 350F;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int d_relevance_object_vtbl;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int d_relevance_object_mRelevanceObjectID;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int d_relevance_object_mpRelevance;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int d_relevance_object_mpMatineeObject;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int d_relevance_object_mBlockIndexX;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int d_relevance_object_mBlockIndexY;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int d_relevance_object_mVisibilityLevel;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int d_relevance_object_mbVisible;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int d_relevance_object_mbGM;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int mFramer;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private bool bIsFalling;

        [NonSerialized, HideInInspector]
        private float mTimeToFall;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private float mFallTimer;

        public Base_Pawn()
        {
        }
    }
}
/*
event bool StandUp() {
if (Physics == 19 || Physics == 20) {                                       
Velocity = vect(0.000000, 0.000000, 0.000000);                            
Acceleration = Velocity;                                                  
SetPhysics(1);                                                            
return True;                                                              
}
return False;                                                               
}
event bool SitDown(optional bool aOnChairFlag) {
if (Physics == 1) {                                                         
Velocity = vect(0.000000, 0.000000, 0.000000);                            
Acceleration = Velocity;                                                  
if (aOnChairFlag) {                                                       
SetPhysics(20);                                                         
} else {                                                                  
SetPhysics(19);                                                         
}
return True;                                                              
}
return False;                                                               
}
event Landed(Vector aHitNormal) {
ResetFallTimer();                                                           
}
native function PlayJumpTakeoff();
native function PlayHitAnim(float aHitFactor);
protected native function sv2clrel_QueueAnimation_CallStub();
event sv2clrel_QueueAnimation(byte flag1,byte flag2,byte flag3,byte variation,optional bool isLooping) {
local array<int> flags;
flags.Length = 3;                                                           
flags[0] = flag1;                                                           
flags[1] = flag2;                                                           
flags[2] = flag3;                                                           
QueueAnimation(flags,variation,1.00000000,0.20000000,0.20000000,isLooping); 
PlayQueuedAnimations(True,False);                                           
}
function sv_ForwardAnimation(byte flag1,byte flag2,byte flag3,byte variation,optional bool isLooping) {
sv2clrel_QueueAnimation_CallStub(flag1,flag2,flag3,variation,isLooping);    
}
function sv_HackDamageActions(float aDamageFactor) {
sv2clrel_DamageActions_CallStub(aDamageFactor);                             
}
protected native function sv2clrel_DamageActions_CallStub();
event sv2clrel_DamageActions(float aDamageFactor) {
PlayHitAnim(aDamageFactor);                                                 
}
native function ResetFallTimer();
native function PlayIdle(optional bool aForce);
native function PlaySubmergeAnim();
native function PlayEmergeAnim();
native function PlayStandAnim(bool aOnChairFlag);
native function PlaySitAnim(bool aOnChairFlag);
native function PlayEmote(int emoteNr,float AnimSpeed);
native function PlayDrawWeaponAnim(int WeaponFlag,optional bool combatState);
native function PlaySheatheWeaponAnim(int WeaponFlag,optional bool combatState);
native function PlayDeathAnim(Vector damageDirection);
exec function Emote(int emoteNr,optional float AnimSpeed) {
if (AnimSpeed < 0.20000000) {                                               
AnimSpeed = 0.20000000;                                                   
}
PlayEmote(emoteNr,AnimSpeed);                                               
}
event bool IsInCombat() {
return False;                                                               
}
native function bool sv_CanReplicate();
protected native function sv2cl_GotoState_CallStub();
event sv2cl_GotoState(string aState) {
GotoState(name(aState));                                                    
}
native event int GetWorldID();
native event int GetUniverseID();
event cl_OnBaseline();
final native event sv_OnSpawn(Base_Controller aController);
event cl_OnFrame(float delta);
native event cl_OnTick(float delta);
native event cl_OnShutdown();
native event cl_OnInit();
final native event sv_OnShutdown();
final native event sv_OnInit();
*/