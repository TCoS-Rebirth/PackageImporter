using System;
using SBBase;

namespace SBGame
{
    [Serializable] public class Game_TextParser : Base_Component
    {
        public Game_TextParser()
        {
        }

        public enum ETextParseFlags
        {
            ETP_PawnProperties,

            ETP_ContentProperties,

            ETP_Style,

            ETP_Reserved,
        }
    }
}
/*
static native function string GetActiveText(Game_ActiveTextItem aItem);
native function string Parse(string aActiveText,Object aSpeaker,Object aSubject,Object aTarget,int aFlags);
*/