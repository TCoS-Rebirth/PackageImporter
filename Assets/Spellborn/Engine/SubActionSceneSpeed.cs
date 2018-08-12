using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class SubActionSceneSpeed : MatSubAction
    {
        [FoldoutGroup("SceneSpeed")]
        public Range SceneSpeed;

        public SubActionSceneSpeed()
        {
        }
    }
}