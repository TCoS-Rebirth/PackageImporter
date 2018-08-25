using System;
using System.Collections.Generic;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QC_Stealth : Quest_Condition
    {
        [FoldoutGroup("Condition")]
        [FieldConst()]
        public List<NPC_Type> NamedTargets = new List<NPC_Type>();

        [FoldoutGroup("Condition")]
        [FieldConst()]
        public List<NPC_Taxonomy> GroupedTargets = new List<NPC_Taxonomy>();

        public QC_Stealth()
        {
        }
    }
}
/*
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QC_StealthText.Text;                 
}
*/