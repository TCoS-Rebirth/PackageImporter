using System;
using System.Collections.Generic;
using Engine;

namespace SBGame
{
    [Serializable] public class Game_ActiveTextItem : UObject
    {
        public int Type;

        public string Tag = string.Empty;

        public int Ordinality;

        public List<string> FreeOptions = new List<string>();

        public Game_ActiveTextItem SubItem;

        public Game_ActiveTextItem()
        {
        }

        public enum EActiveTextString
        {
            ATS_None,

            ATS_GenderNoun,

            ATS_GenderGender,

            ATS_GenderObjective,

            ATS_GenderSubjective,

            ATS_GenderPossessive,

            ATS_House,

            ATS_DayPart,

            ATS_Greeting,
        }

        public enum EActiveTextType
        {
            ATT_None,

            ATT_Speaker,

            ATT_Subject,

            ATT_Target,

            ATT_Reference,

            ATT_World,
        }
    }
}