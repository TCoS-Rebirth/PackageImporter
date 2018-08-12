using System;
using System.Collections.Generic;
using Engine;
using SBBase;

namespace SBGame
{
    [Serializable] public class Game_Route : SBRoute
    {
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        public SBWorld DeathWorld;

        public SBPortal DeathPortal;

        public NameProperty EffectsTag;

        public Game_Route()
        {
        }
    }
}