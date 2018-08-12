using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class Appearance_MainWeapon : Appearance_Base
    {
        [FoldoutGroup("MainWeapon")]
        public byte WeaponType;

        [FoldoutGroup("MainWeapon")]
        public byte WeaponClassification;

        [FoldoutGroup("MainWeapon")]
        public byte WeaponTracerType;

        [FoldoutGroup("MainWeapon")]
        public Vector WeaponTracerBeginOffset;

        [FoldoutGroup("MainWeapon")]
        public Vector WeaponTracerEndOffset;

        public Appearance_MainWeapon()
        {
        }

        public enum EWeaponTracerType
        {
            EWTT_Custom,

            EWTT_NoTracer,

            EWTT_Sword_sh,

            EWTT_Sword_dh,

            EWTT_Axe_sh,

            EWTT_Axe_dh,

            EWTT_Mace_sh,

            EWTT_Mace_dh,

            EWTT_Dag_sh,

            EWTT_Pole_sh,
        }

        public enum EWeaponClassification
        {
            EWC_Undetermined,

            EWC_Axe,

            EWC_DoubleHandedAxe,

            EWC_Sword,

            EWC_DoubleHandedSword,

            EWC_Mace,

            EWC_DoubleHandedMace,

            EWC_Hammer,

            EWC_DoubleHandedHammer,

            EWC_Dagger,

            EWC_Bow,

            EWC_Shields,
        }

        public enum EAppMainWeaponType
        {
            EMW_Undetermined,

            EMW_SingleHanded,

            EMW_DoubleHanded,

            EMW_DualWielding,

            EMW_Ranged,
        }
    }
}
/*
native function GetWeaponTracerBoneOffsets(out Vector StartBoneOffset,out Vector EndBoneOffset);
static native function string GetWeaponClassName(byte aClassification);
*/