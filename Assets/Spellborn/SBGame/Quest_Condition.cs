using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class Quest_Condition : Quest_Target
    {
        [FoldoutGroup("Target")]
        public List<Quest_Target> FinalTargets = new List<Quest_Target>();

        public Quest_Condition()
        {
        }
    }
}