using System;
using System.Collections.Generic;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_BeDefeated : Quest_Target
    {
        [FoldoutGroup("Defeat")]
        [FieldConst()]
        public List<NPC_Type> NamedTargets = new List<NPC_Type>();

        [FoldoutGroup("Defeat")]
        [FieldConst()]
        public List<NPC_Taxonomy> GroupedTargets = new List<NPC_Taxonomy>();

        [FoldoutGroup("Defeat")]
        [FieldConst()]
        public Conversation_Topic VictorySpeech;

        [FoldoutGroup("Defeat")]
        [FieldConst()]
        public float DefeatFraction;

        public QT_BeDefeated()
        {
        }
    }
}