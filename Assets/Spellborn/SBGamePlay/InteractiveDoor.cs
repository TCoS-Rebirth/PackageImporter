using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class InteractiveDoor : InteractiveLevelElement
    {
        [FoldoutGroup("InteractiveDoor")]
        public int DestinationWorld;

        [FoldoutGroup("InteractiveDoor")]
        public string Parameter = string.Empty;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public string spawnPointTag = string.Empty;

        [FoldoutGroup("InteractiveDoor")]
        public LocalizedString DoorSign;

        [FoldoutGroup("InteractiveDoor")]
        public bool IsInstance;

        public InteractiveDoor()
        {
        }
    }
}
/*
event string cl_GetToolTip() {
return DoorSign.Text;                                                       
}
*/