using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class InteractiveHatch : InteractiveLevelElement
    {
        [FoldoutGroup("InteractiveHatch")]
        [FieldConst()]
        public Vector DoorMovement;

        [FoldoutGroup("InteractiveHatch")]
        [FieldConst()]
        public Rotator DoorRotation;

        [FoldoutGroup("InteractiveHatch")]
        [FieldConst()]
        public bool Hide;

        [FoldoutGroup("InteractiveHatch")]
        [FieldConst()]
        public float OpenSpeed;

        [FoldoutGroup("InteractiveHatch")]
        [FieldConst()]
        public float PassableTime;

        [FoldoutGroup("InteractiveHatch")]
        [FieldConst()]
        public string AnnotationTag = string.Empty;

        [FoldoutGroup("InteractiveHatch")]
        public LocalizedString DoorSign;

        public InteractiveHatch()
        {
        }
    }
}
/*
event string cl_GetToolTip() {
return DoorSign.Text;                                                       
}
*/