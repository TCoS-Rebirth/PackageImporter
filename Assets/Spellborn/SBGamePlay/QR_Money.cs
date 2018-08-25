using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QR_Money : Quest_Reward
    {
        [FoldoutGroup("reward")]
        public int Money;

        public QR_Money()
        {
        }
    }
}
/*
function string GetText() {
return GetMoneyText(Money);                                                 
}
*/