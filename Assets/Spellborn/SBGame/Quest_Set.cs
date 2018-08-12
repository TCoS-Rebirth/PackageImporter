using System;
using System.Collections.Generic;
using Engine;

namespace SBGame
{
    [Serializable] public class Quest_Set : UObject
    {
        public List<Quest_Type> mQuests = new List<Quest_Type>();

        public List<Quest_Type> mMailQuests = new List<Quest_Type>();

        public Quest_Set()
        {
        }
    }
}
/*
static native function Quest_Set GetQuestSet();
static native function Quest_Set InitQuestSet();
*/