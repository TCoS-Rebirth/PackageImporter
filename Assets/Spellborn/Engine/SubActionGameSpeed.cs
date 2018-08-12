using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class SubActionGameSpeed : MatSubAction
    {
        [FoldoutGroup("GameSpeed")]
        public Range GameSpeed;

        public SubActionGameSpeed()
        {
        }
    }
}