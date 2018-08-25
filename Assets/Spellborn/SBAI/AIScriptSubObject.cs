using System;
using Engine;
using UnityEngine;

namespace SBAI
{
    [Serializable] public class AIScriptSubObject : UObject
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int ExCleanIndex;

        public AIScriptSubObject()
        {
        }
    }
}