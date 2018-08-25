﻿using System;
using System.Collections.Generic;
using Engine;

namespace SBBase
{
    [Serializable] public class DB_Guild : Base_DBObject
    {
        public int GroupId;

        public int MotdTextId;

        public int LogoId;

        public int Color1;

        public int Color2;

        [FieldConst()]
        public List<DB_Character> mGuildMembers = new List<DB_Character>();

        [FieldConst()]
        public bool mGuildMembersSet;

        public DB_Guild()
        {
        }
    }
}