using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_Class : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public byte RequiredClass;

        public Req_Class()
        {
        }
    }
}