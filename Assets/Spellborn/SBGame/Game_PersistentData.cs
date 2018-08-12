using System;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Game_PersistentData : Base_Component
    {
        [FieldConfig()]
        public bool mTutorialsActive;

        [FieldConfig()]
        public int mCurrentShardID;

        public Game_PersistentData()
        {
        }
    }
}
/*
native function bool IsMapSectionDiscovered(int section);
native function Read();
native function Write();
*/