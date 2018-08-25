using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QR_Item : Quest_Reward
    {
        [FoldoutGroup("reward")]
        public Content_Inventory RewardItems;

        public QR_Item()
        {
        }
    }
}
/*
function string GetText() {
return RewardItems.Description();                                           
}
*/