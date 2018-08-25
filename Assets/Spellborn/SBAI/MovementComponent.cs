using System;
using System.Collections.Generic;
using Engine;
using SBBase;
using SBGame;

namespace SBAI
{
    [Serializable] public class MovementComponent : Base_Component
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

        private SBPath mPath;

        public List<MovementConfigStruct> ConfigStack = new List<MovementConfigStruct>();

        public List<SBPath> mPathStack = new List<SBPath>();

        public float mFrequencyTimer;

        public float mArrivedTime;

        private int mData1;

        public MovementComponent()
        {
        }

        [Serializable] public struct MCTimer
        {
            public byte mMode;

            public Type mState;

            public float mTimePlanning;

            public float mTimeMoving;

            public int mPlans;

            public int mMoves;
        }

        [Serializable] public struct MovementConfigStruct
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

        [Serializable] public struct TacticalLocation
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
            AMM_None,

            AMM_Pathfinding,

            AMM_Wander,

            AMM_Tactical,

            AMM_Flee,

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