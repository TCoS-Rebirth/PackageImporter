using System;
using System.Collections.Generic;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
    [Serializable]
    public class Game_ShiftableAppearance: Base_Component
    {
        [NonSerialized, HideInInspector]
        private PhysicState mSavedPhysics;
        [NonSerialized] public int mShiftedNPCTypeID;
        [NonSerialized] public NPC_Type mShiftedNPCType;
        [NonSerialized] public Game_Appearance mShiftedAppearance;
        [NonSerialized] public List<Game_AppearanceListener> mAppearanceListeners = new List<Game_AppearanceListener>();
        [NonSerialized] public bool mInvalidatedDressup;

        public void DressUp() { Debug.LogWarning("DressUp not implemented"); }

        [Serializable]
        public struct PhysicState
        {
            public byte Physics;
            public float GroundSpeed;
            public float BaseMovementSpeed;
            public float[] MovementSpeedMultiplier;
            public float AirSpeed;
            public float MinFlySpeed;
            public float AirControl;
            public bool CanStrafe;
            public bool CanRest;
            public bool CanWalkBackwards;
            public float WalkingPct;
            public float WaterSpeed;
            public float JumpSpeed;
            public float LadderSpeed;
            public float AccelRate;
            public float TurnSpeed;
            public bool bAlignToFloor;
            public bool bAlignToFloorRoll;
            public bool bAlignToFloorPitch;
            public bool bForceAttachmentUpdates;
            public float CollisionHeight;
            public float CollisionRadius;
            public float TerminalVelocity;
        }

        public override void Initialize(Actor outer)
        {
            base.Initialize(outer);
            int aShiftedNPCTypeID;
            var gp = outer as Game_Pawn;
            gp.BaseAppearance.Initialize(outer);
            if (mShiftedNPCTypeID != 0)
            {
                aShiftedNPCTypeID = mShiftedNPCTypeID;
                mShiftedNPCTypeID = 0;
                ShiftToNPCTypeID(aShiftedNPCTypeID);
            }
            TestInvariant();
        }

        void ShiftToNPCTypeID(int aNPCTypeID)
        {
            NPC_Type NPCType;
            TestInvariant();
            if (aNPCTypeID != 0)
            {
                NPCType = SBDBSync.GetResourceObject<NPC_Type>(aNPCTypeID);
                ShiftAppearance(NPCType);
            }
            else
            {
                UnshiftAppearance();
            }
            TestInvariant();
        }

        bool ShiftAppearance(NPC_Type aOtherNPCType)
        {
            TestInvariant();
            if (mShiftedNPCType == aOtherNPCType)
            {
                return false;
            }
            if (mShiftedNPCType != null)
            {
                mShiftedAppearance = null;
                mShiftedNPCType = null;
                mShiftedNPCTypeID = 0;
            }
            TestInvariant();
            if (aOtherNPCType != null)
            {
                mShiftedNPCType = aOtherNPCType;
                mShiftedNPCTypeID = mShiftedNPCType.GetResourceId();
                mShiftedAppearance = aOtherNPCType.Appearance.CreateAppearance((Outer as Game_Pawn), mShiftedAppearance, true);
            }
            if (mShiftedAppearance != null
            && mShiftedNPCType.Equipment != null)
            {
                mShiftedNPCType.Equipment.ApplyToAppearance(GetCurrent() as Game_EquippedAppearance);
            }
            GetCurrent().Apply();
            TestInvariant();
            return true;
        }

        bool UnshiftAppearance()
        {
            return ShiftAppearance(null);
        }

        Game_Appearance GetCurrent()
        {
            return mShiftedAppearance != null ? mShiftedAppearance : (Outer as Game_Pawn).BaseAppearance;
        }

        void TestInvariant()
        {
            var outer = Outer as Game_Pawn;
            UnityEngine.Assertions.Assert.IsTrue(outer.BaseAppearance != null);
            UnityEngine.Assertions.Assert.IsTrue(mShiftedNPCType == null || mShiftedAppearance != null);
            UnityEngine.Assertions.Assert.IsTrue(mShiftedNPCType != null || mShiftedAppearance == null);
            UnityEngine.Assertions.Assert.IsTrue(mShiftedNPCType == null || mShiftedNPCTypeID == mShiftedNPCType.ResourceID);
        }
    }
}
/*
protected native function sv2clrel_ShiftAppearance_CallStub();
protected event sv2clrel_ShiftAppearance(int aNPCTypeID) {
local export editinline NPC_Type NPCType;
if (aNPCTypeID != 0) {                                                      
NPCType = NPC_Type(Class'SBDBSync'.GetResourceObject(aNPCTypeID));        
SaveMovementPhysics();                                                    
} else {                                                                    
NPCType = mShiftedNPCType;                                                
}
if (NPCType == None) {                                                      
return;                                                                   
}
ShiftToNPCTypeID(aNPCTypeID);                                               
if (aNPCTypeID != 0) {                                                      
NPCType.InitMovement(Outer);                                              
Outer.PrePivot.Z += NPCType.Appearance.GetCollisionHeight() - mSavedPhysics.CollisionHeight;
Outer.SetCollisionSize(mSavedPhysics.CollisionRadius,mSavedPhysics.CollisionHeight);
} else {                                                                    
Outer.PrePivot.Z -= NPCType.Appearance.GetCollisionHeight() - mSavedPhysics.CollisionHeight;
RestoreMovementPhysics();                                                 
}
}
protected event NotifyAppearanceListeners(Game_Pawn aPawn,export editinline Game_Appearance aAppearance) {
local int i;
i = 0;                                                                      
while (i < mAppearanceListeners.Length) {                                   
if (mAppearanceListeners[i] == None) {                                    
mAppearanceListeners.Remove(i,1);                                       
i--;                                                                    
} else {                                                                  
mAppearanceListeners[i].OnAppearanceChanged(aPawn,aAppearance);         
}
i++;                                                                      
}
}
function UnregisterAppearanceListener(Game_AppearanceListener aListener) {
local int i;
i = 0;                                                                      
while (i < mAppearanceListeners.Length) {                                   
if (mAppearanceListeners[i] == aListener) {                               
mAppearanceListeners.Remove(i,1);                                       
return;                                                                 
}
i++;                                                                      
}
assert(False);                                                              
}
function RegisterAppearanceListener(Game_AppearanceListener aListener) {
local int i;
i = 0;                                                                      
while (i < mAppearanceListeners.Length) {                                   
if (mAppearanceListeners[i] == aListener) {                               
assert(False);                                                          
return;                                                                 
}
i++;                                                                      
}
mAppearanceListeners[mAppearanceListeners.Length] = aListener;              
}
function InstallBaseAppearance(export editinline NPC_Type aNPCType) {
Outer.BaseAppearance = aNPCType.Appearance.CreateAppearance(Outer,Outer.BaseAppearance,False);
Outer.BaseAppearance.Apply();                                               
}
function cl_OnShutdown() {
if (mShiftedAppearance != None) {                                           
mShiftedAppearance.cl_OnShutdown();                                       
}
Outer.BaseAppearance.cl_OnShutdown();                                       
Super.cl_OnShutdown();                                                      
}
function cl_OnFrame(float aDeltaTime) {
if (mShiftedAppearance != None) {                                           
mShiftedAppearance.cl_OnFrame(aDeltaTime);                                
}
Outer.BaseAppearance.cl_OnFrame(aDeltaTime);                                
if (mInvalidatedDressup) {                                                  
DressUp();                                                                
}
}
function app(int A) {
GetCurrent().app(A);                                                        
}
event InvalidateDressup() {
mInvalidatedDressup = True;                                                 
}
event bool sv_UnshiftAppearance() {
return sv_ShiftAppearance(None);                                            
}
event NPC_Type GetShiftedNPCType() {
return mShiftedNPCType;                                                     
}
event bool sv_ShiftAppearance(export editinline NPC_Type aOtherNPCType) {
ShiftAppearance(aOtherNPCType);                                             
sv2clrel_ShiftAppearance_CallStub(mShiftedNPCTypeID);                       
return True;                                                                
}
native function bool IsFeminine();
native function bool IsShifted();
event Game_Appearance GetBase() {
return Outer.BaseAppearance;                                                
}
native function RestoreMovementPhysics();
native function SaveMovementPhysics();
*/
