using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class PathConfigurationActor : Actor
    {
        [FoldoutGroup("PathConfigurationActor")]
        public bool mUseAccessmap;

        [FoldoutGroup("PathConfigurationActor")]
        public float mNoiseRatio;

        [FoldoutGroup("PathConfigurationActor")]
        public float mNoiseFactor;

        [FoldoutGroup("PathConfigurationActor")]
        public float mTrackerSpeed;

        [FoldoutGroup("PathConfigurationActor")]
        public int mLookAheadCount;

        [FoldoutGroup("PathConfigurationActor")]
        public int mMaxDepth;

        [FoldoutGroup("PathConfigurationActor")]
        public float mMinMoveDistance;

        [FoldoutGroup("PathConfigurationActor")]
        public float mReplanThreshold;

        [FoldoutGroup("PathConfigurationActor")]
        public float mMaxFailureDistance;

        [FoldoutGroup("PathConfigurationActor")]
        public float mRandomizationFactor;

        [FoldoutGroup("PathConfigurationActor")]
        public float mRandomDistance;

        [FoldoutGroup("PathConfigurationActor")]
        public float mFacingDistance;

        public PathConfigurationActor()
        {
        }
    }
}