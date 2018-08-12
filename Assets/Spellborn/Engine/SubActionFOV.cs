using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class SubActionFOV : MatSubAction
    {
        [FoldoutGroup("FOV")]
        public Range FOV;

        public SubActionFOV()
        {
        }
    }
}