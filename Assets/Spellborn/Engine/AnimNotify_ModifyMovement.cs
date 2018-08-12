using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class AnimNotify_ModifyMovement : AnimNotify
    {
        [FoldoutGroup("AnimNotify_ModifyMovement")]
        public bool FreezeMovement;

        [FoldoutGroup("AnimNotify_ModifyMovement")]
        public bool FreezeRotation;

        public AnimNotify_ModifyMovement()
        {
        }
    }
}