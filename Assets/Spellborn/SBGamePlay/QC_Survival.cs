using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QC_Survival : Quest_Condition
    {
        [FoldoutGroup("Survival")]
        [FieldConst()]
        public float DefeatFraction;

        public QC_Survival()
        {
        }
    }
}
/*
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QC_SurvivalText.Text;                
}
*/