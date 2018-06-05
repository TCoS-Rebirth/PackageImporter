﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Engine;
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SBAI
{
    
    
    [System.Serializable] public class MovementComponent : Base_Component
    {
        
        public byte MoveMode;
        
        public Vector Destination;
        
        public float Range;
        
        public Game_Pawn Target;
        
        public FSkill_Type Skill;
        
        public AIPoint ControlPoint;
        
        public AIPoint DestinationPoint;
        
        public float speed;
        
        public bool Walking;
        
        public bool Strafing;
        
        public bool MovingTurn;
        
        public bool AnnotationAttached;
        
        public List<TacticalLocation> TacticalLocations = new List<TacticalLocation>();
        
        public SBAccessMap mAccessmap;
        
        private SBPath mPath;
        
        public List<MovementConfigStruct> ConfigStack = new List<MovementConfigStruct>();
        
        public List<SBPath> mPathStack = new List<SBPath>();
        
        public float mFrequencyTimer;
        
        public float mArrivedTime;
        
        private int mData1;
        
        public MovementComponent()
        {
        }
        
        [System.Serializable] public struct MCTimer
        {
            
            public byte mMode;
            
            public System.Type mState;
            
            public float mTimePlanning;
            
            public float mTimeMoving;
            
            public int mPlans;
            
            public int mMoves;
        }
        
        [System.Serializable] public struct MovementConfigStruct
        {
            
            public UObject mOwner;
            
            public Vector pawnLocation;
            
            public byte Mode;
            
            public Vector Destination;
            
            public float Range;
            
            public Game_Pawn Target;
            
            public FSkill_Type Skill;
            
            public AIPoint ControlPoint;
            
            public float speed;
            
            public bool Walking;
            
            public bool Strafing;
            
            public bool MovingTurn;
        }
        
        [System.Serializable] public struct TacticalLocation
        {
            
            public Vector Location;
            
            public float Distance;
            
            public float LowerLimit;
            
            public float UpperLimit;
            
            public float Weight;
            
            public bool LimitPath;
            
            public bool Penalty;
        }
        
        public enum EAIMoveMode
        {
            
            AMM_None ,
            
            AMM_Pathfinding ,
            
            AMM_Wander ,
            
            AMM_Tactical ,
            
            AMM_Flee ,
            
            AMM_Follow,
        }
    }
}
/*
native function PatrolPoint GetNextPatrolPoint();
function SetWalking(bool aWalking) {
Walking = aWalking;                                                         
}
function SetSpeed(float aSpeed) {
speed = aSpeed;                                                             
}
native function Approach(Vector aDestination,float aRange);
native function Wander();
native function MoveControlled(AIPoint aControl);
native function MoveTo(Vector aDestination);
native function NoMovement();
*/