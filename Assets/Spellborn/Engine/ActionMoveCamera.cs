using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class ActionMoveCamera : MatAction
    {
        [FoldoutGroup("Path")]
        [FieldConfig()]
        public byte PathStyle;

        public ActionMoveCamera()
        {
        }

        public enum EPathStyle
        {
            PATHSTYLE_Linear,

            PATHSTYLE_Bezier,
        }
    }
}