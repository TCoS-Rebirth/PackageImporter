using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class FSkill_Event : Content_Type
    {
        public const int CF_VS_RECURSIVE = 268435456;

        public const int CF_VS_REQUIRED_BITS = 299;

        public const int CF_PERTARGET_BITS = 8128;

        public const int CF_BASE_BITS = 63;

        public const int CF_UNUSED_BITS = 57344;

        public const int CF_12a_FINAL_CAP = 4096;

        public const int CF_12_RESISTANCE_AFFINITY = 2048;

        public const int CF_11_ALTER_EFFECT_INPUT = 1024;

        public const int CF_10_SHARE = 512;

        public const int CF_09_TARGET_TYPE_INCREASE = 256;

        public const int CF_08_REFLECT = 128;

        public const int CF_07_IMMUNITY = 64;

        public const int CF_06_DIVIDE = 32;

        public const int CF_05_ALTER_EFFECT_OUTPUT = 16;

        public const int CF_04_MISC_BONUS = 8;

        public const int CF_03_SKILLTOKEN_BONUS = 4;

        public const int CF_02_ABSOLUTE_CAP = 2;

        public const int CF_01_CONSTANT_VALUE = 1;

        public const int VCV_CONTEXT_ALL = 67043328;

        public const int VCV_CONTEXT_GAIN = 67108864;

        public const int VCV_CONTEXT_CHAIN_REST = 33554432;

        public const int VCV_CONTEXT_CHAIN_1ST = 16777216;

        public const int VCV_CONTEXT_TRIGGERED = 8388608;

        public const int VCV_CONTEXT_REFLECT = 4194304;

        public const int VCV_CONTEXT_RETURN = 2097152;

        public const int VCV_CONTEXT_SHARERETURN = 1048576;

        public const int VCV_CONTEXT_SHAREDIVIDE = 524288;

        public const int VCV_CONTEXT_DUFFREPEAT = 262144;

        public const int VCV_CONTEXT_DUFF = 131072;

        public const int VCV_CONTEXT_DIRECT = 65536;

        public const int VCV_NO_TARGET_COUNTING = 16;

        public const int VCV_COMBO_EVENT = 8;

        public const int VCV_NOSKILL_EVENT = 4;

        public const int VCV_LOCATION = 2;

        public const int VCV_SKILLPAWN = 1;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mhasskillpower_vtbl;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mhasskillpower_data;

        [FoldoutGroup("Timing")]
        [FieldConst()]
        public float Delay;

        [FoldoutGroup("Target")]
        [FieldConst()]
        public bool TargetCountValueSpecifier;

        [FieldConst()]
        [ArraySizeForExtraction(Size = 32)]
        public float[] PerEffectFameLevelBonus = new float[0];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 32)]
        public float[] PerEffectPepLevelBonus = new float[0];

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public FSkill_Type Skill;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int flags;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_Pawn SkillPawn;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_CharacterStats.CharacterStatsRecord SkillPawnState;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_Pawn TriggerPawn;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Vector Location;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float StartTime;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float ElapsedTime;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte EventState;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Rotator TriggerRotation;

        [FieldConst()]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public FSkill_Event OriginalEvent;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int SessionID;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public AimingInfo SkillPawnAimingInfo;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte OriginDuffCondition;

        public FSkill_Event()
        {
        }

        [Serializable] public struct AimingInfo
        {
            public Rotator CameraRotation;

            public Vector CameraLocation;

            public Game_Pawn PreferredTarget;

            public float TriggerTime;
        }

        public enum ESkillEventState
        {
            SES_INITIALIZING,

            SES_WAITING_FOR_DELAY,

            SES_RUNNING,

            SES_FINISHED,

            SES_ABORTED,

            SES_ABORTING,
        }
    }
}
/*
native function bool IsOriginalEvent();
native function Object Clone(optional bool aCloneSubObjects);
final native event bool NeedsCloningAlways();
final native event bool NeedsServerSideExecution();
final native event bool NeedsClientReplication();
final native function bool Execute(float DeltaTime);
final native function AbortEvent();
final native function Initialize(int aFlags,export editinline FSkill_Type aSkill,Game_Pawn aSkillPawn,Game_Pawn aTriggerPawn,Game_Pawn aTargetPawn,Vector aLocation,const out AimingInfo aAimingInfo,const out CharacterStatsRecord aSkillPawnState,int aSessionID,float aTime,byte aOriginCondition);
*/