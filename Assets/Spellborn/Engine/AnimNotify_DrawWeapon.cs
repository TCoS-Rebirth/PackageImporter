using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class AnimNotify_DrawWeapon : AnimNotify
    {
        [FoldoutGroup("AnimNotify_DrawWeapon")]
        public NameProperty NotifyName;

        [FoldoutGroup("AnimNotify_DrawWeapon")]
        public byte WeaponFlag;

        public AnimNotify_DrawWeapon()
        {
        }
    }
}