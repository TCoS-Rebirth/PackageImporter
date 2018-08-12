using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class AnimNotify_SheatheWeapon : AnimNotify
    {
        [FoldoutGroup("AnimNotify_SheatheWeapon")]
        public NameProperty NotifyName;

        [FoldoutGroup("AnimNotify_SheatheWeapon")]
        public byte WeaponFlag;

        public AnimNotify_SheatheWeapon()
        {
        }
    }
}