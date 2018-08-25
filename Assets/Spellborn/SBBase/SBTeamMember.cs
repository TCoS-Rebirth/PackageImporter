using System;
using System.Collections.Generic;
using Engine;

namespace SBBase
{
    [Serializable] public class SBTeamMember : UObject
    {
        public int MemberHandle;

        //public string Name = string.Empty;

        public float Health;

        public float MaxHealth;

        public int Pep;

        public int Fame;

        public float Physique;

        public float Morale;

        public float Concentration;

        public int StateRankShift;

        public List<int> Buffs = new List<int>();

        public int LastDuffUpdateTime;

        public Pawn AppearancePawn;

        public bool IsLeader;

        public int worldID;

        public SBTeamMember()
        {
        }
    }
}