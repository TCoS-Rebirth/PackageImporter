using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QR_Fame : Quest_Reward
    {
        [FoldoutGroup("reward")]
        [FieldConst()]
        public int Fame;

        public QR_Fame()
        {
        }
    }
}
/*
function string GetText() {
return string(Fame)
@ Class'SBGamePlayStrings'.default.Fame.Text;     
}
*/