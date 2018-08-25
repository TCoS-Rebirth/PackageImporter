using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QC_CarryItem : Quest_Condition
    {
        [FoldoutGroup("CarryItem")]
        [FieldConst()]
        public Content_Inventory Cargo;

        public QC_CarryItem()
        {
        }
    }
}