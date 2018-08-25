using System;
using UnityEngine;

namespace Engine
{
    [Serializable] public class Subsystem : UObject
    {
        [FieldConst()]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int ExecVtbl;

        public Subsystem()
        {
        }
    }
}