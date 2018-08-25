using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class FSkill_EventGroup : Content_Type
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mhasskillpower_vtbl;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mhasskillpower_data;

        [FoldoutGroup("FSkill_EventGroup")]
        [FieldConst()]
        public List<FSkill_Event> Events = new List<FSkill_Event>();

        public FSkill_EventGroup()
        {
        }
    }
}