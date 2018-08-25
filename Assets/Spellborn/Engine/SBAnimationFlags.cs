﻿using System;

namespace Engine
{
    [Serializable] public class SBAnimationFlags : UObject
    {
        public SBAnimationFlags()
        {
        }

        public enum SBAnimWeaponFlags
        {
            AnimWeapon_None,

            AnimWeapon_Unarmed,

            AnimWeapon_SingleHanded,

            AnimWeapon_DoubleHanded,

            AnimWeapon_DualWielding,

            AnimWeapon_Bow,

            AnimWeapon_Armed,

            AnimWeapon_SingleShield,
        }

        public enum SBAnimDirectionFlags
        {
            AnimDirection_None,

            AnimDirection_Forwards,

            AnimDirection_Backwards,

            AnimDirection_Left,

            AnimDirection_Right,

            AnimDirection_Up,

            AnimDirection_Down,
        }

        public enum SBAnimActionFlags
        {
            AnimAction_None,

            AnimAction_Aimed,

            AnimAction_Allies,

            AnimAction_Area,

            AnimAction_Carriage,

            AnimAction_Carry,

            AnimAction_Cast,

            AnimAction_Casual,

            AnimAction_Chair,

            AnimAction_Combat,

            AnimAction_Contact,

            AnimAction_Crash,

            AnimAction_Crawl,

            AnimAction_DanceOfBlades,

            AnimAction_Dazed,

            AnimAction_Death,

            AnimAction_DefensiveSkill,

            AnimAction_DoubleScratch,

            AnimAction_DrawWeapon,

            AnimAction_Emote,

            AnimAction_End,

            AnimAction_ExtensiveHack,

            AnimAction_Fall,

            AnimAction_FlickFlack,

            AnimAction_Fly,

            AnimAction_FocusSkill,

            AnimAction_Gallop,

            AnimAction_GetUp,

            AnimAction_Glide,

            AnimAction_Ground,

            AnimAction_Hack,

            AnimAction_HighKick,

            AnimAction_Horse,

            AnimAction_Idle,

            AnimAction_ImpaleSelf,

            AnimAction_Jump,

            AnimAction_Kick,

            AnimAction_KickHooves,

            AnimAction_Knockdown,

            AnimAction_Land,

            AnimAction_LowKick,

            AnimAction_Mid,

            AnimAction_OffensiveSkill,

            AnimAction_Parry,

            AnimAction_Pull,

            AnimAction_Ranged,

            AnimAction_ReverseHack,

            AnimAction_Ride,

            AnimAction_Run,

            AnimAction_Scratch,

            AnimAction_SheatheWeapon,

            AnimAction_Shoot,

            AnimAction_Sit,

            AnimAction_Slash,

            AnimAction_Special,

            AnimAction_Start,

            AnimAction_Step,

            AnimAction_Summon,

            AnimAction_Swing,

            AnimAction_Takeoff,

            AnimAction_Thrust,

            AnimAction_ToIdle,

            AnimAction_Touch,

            AnimAction_Turn,

            AnimAction_Vaylarian,

            AnimAction_Vomit,

            AnimAction_Walk,

            AnimAction_Hit,

            AnimAction_Headbutt,

            AnimAction_Throw,

            AnimAction_Tornado,

            AnimAction_Descend,

            AnimAction_Climb,

            AnimAction_Scared,

            AnimAction_Swim,

            AnimAction_Statue,

            AnimAction_Submerge,

            AnimAction_Emerge,

            AnimAction_Dodge,
        }
    }
}