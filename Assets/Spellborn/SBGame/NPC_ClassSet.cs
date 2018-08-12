using System;
using System.Collections.Generic;
using Engine;

namespace SBGame
{
    [Serializable] public class NPC_ClassSet : UObject
    {
        public List<NPC_Type> mClasses = new List<NPC_Type>();

        public NPC_ClassSet()
        {
        }
    }
}
/*
static native function NPC_ClassSet InitClassSet(export editinline NPC_Taxonomy aFaction);
*/