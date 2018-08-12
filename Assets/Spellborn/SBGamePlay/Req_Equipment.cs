using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_Equipment : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public Item_Type Equipment;

        public Req_Equipment()
        {
        }
    }
}