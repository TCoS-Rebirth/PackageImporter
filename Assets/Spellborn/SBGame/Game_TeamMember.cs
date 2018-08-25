using System;
using System.Collections.Generic;
using Engine;

namespace SBGame
{
    [Serializable] public class Game_TeamMember : UObject
    {
        public int MemberHandle;

        public string Name = string.Empty;

        public bool IsFeminine;

        public int Archetype;

        public int Discipline;

        public float Health;

        public float MaxHealth;

        public int Pep;

        public int Fame;

        public float Physique;

        public float Morale;

        public float Concentration;

        public int StateRankShift;

        public List<FSkill_Event_Duff> Buffs = new List<FSkill_Event_Duff>();

        public float LastDuffUpdateTime;

        public Game_Pawn AppearancePawn;

        public List<byte> LastAppearanceUpdateLod = new List<byte>();

        public bool IsLeader;

        public int worldID;

        public float LocationX;

        public float LocationY;

        public Game_TeamMember()
        {
        }
    }
}