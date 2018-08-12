using System;
using Engine;

namespace SBGame
{
    [Serializable] public class FSkill_Event_DirectAdvanced : FSkill_Event_Direct
    {
        [FieldConst()]
        public FSkill_Event MissEvent;

        [FieldConst()]
        public FSkill_Event ReactionEvent;

        [FieldConst()]
        public FSkill_Event TriggerEvent;

        public FSkill_Event_DirectAdvanced()
        {
        }
    }
}