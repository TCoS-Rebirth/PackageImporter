using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QR_QuestPoints : Quest_Reward
    {
        [FoldoutGroup("reward")]
        [FieldConst()]
        public int QP;

        [FoldoutGroup("reward")]
        [FieldConst()]
        public int QPFrac;

        public QR_QuestPoints()
        {
        }
    }
}
/*
function string GetText() {
return string(QP)
@ Class'SBGamePlayStrings'.default.Quest_Points.Text;
}
*/