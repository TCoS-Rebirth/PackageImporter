using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_GameActorEnabled : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public NameProperty Tag;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public bool AllMustSucceed;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public bool CheckForEnabled;

        public Req_GameActorEnabled()
        {
        }
    }
}