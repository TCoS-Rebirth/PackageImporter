using System;
using Engine;
using SBGame;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class InteractiveChair : InteractiveLevelElement
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool mCancelState;

        public InteractiveChair()
        {
        }
    }
}
/*
event sv_StopOptionActions() {
Super.sv_StopOptionActions();                                               
}
function sv_StartOptionActions() {
Super.sv_StartOptionActions();                                              
}
*/