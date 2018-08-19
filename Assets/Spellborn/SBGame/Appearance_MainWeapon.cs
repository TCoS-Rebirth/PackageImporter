using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class Appearance_MainWeapon : Appearance_Base
    {
        [FoldoutGroup("MainWeapon")]
        public EAppMainWeaponType WeaponType;

        [FoldoutGroup("MainWeapon")]
        public EWeaponClassification WeaponClassification;

        [FoldoutGroup("MainWeapon")]
        public EWeaponTracerType WeaponTracerType;

        public enum EWeaponTracerType
        {
            EWTT_Custom = 0,

            EWTT_NoTracer = 1,

            EWTT_Sword_sh = 2,

            EWTT_Sword_dh = 3,

            EWTT_Axe_sh = 4,

            EWTT_Axe_dh = 5,

            EWTT_Mace_sh = 6,

            EWTT_Mace_dh = 7,

            EWTT_Dag_sh = 8,

            EWTT_Pole_sh = 9,
        }

        public enum EWeaponClassification
        {
            EWC_Undetermined = 0,

            EWC_Axe = 1,

            EWC_DoubleHandedAxe = 2,

            EWC_Sword = 3,

            EWC_DoubleHandedSword = 4,

            EWC_Mace = 5,

            EWC_DoubleHandedMace = 6,

            EWC_Hammer = 7,

            EWC_DoubleHandedHammer = 8,

            EWC_Dagger = 9,

            EWC_Bow = 10,

            EWC_Shields = 11,
        }

        public enum EAppMainWeaponType
        {
            EMW_Undetermined = 0,

            EMW_SingleHanded = 1,

            EMW_DoubleHanded = 2,

            EMW_DualWielding = 3,

            EMW_Ranged = 4,
        }
    }
}
/*
native function GetWeaponTracerBoneOffsets(out Vector StartBoneOffset,out Vector EndBoneOffset);
static native function string GetWeaponClassName(byte aClassification);
*/