using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_Faction : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public NPC_Taxonomy RequiredTaxonomy;

        public Req_Faction()
        {
        }
    }
}