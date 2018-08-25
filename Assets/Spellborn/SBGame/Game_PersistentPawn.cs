using System;
using UnityEngine;

namespace SBGame
{
    [Serializable]
    public class Game_PersistentPawn: Game_Pawn
    {
        [NonSerialized, HideInInspector]
        public Game_PersistentData mPersistentData;

        public override void Initialize()
        {
            base.Initialize();
            Debug.LogWarning("TODO find out how relevant Game_PersistentData is (probably only clientside)");
            //mPersistentData.Read();                                                     
        }
    }
}
/*
event cl_OnShutdown() {
if (mPersistentData != None && IsLocalPlayer()) {                           
mPersistentData.Write();                                                  
}
Super.cl_OnShutdown();                                                      
}

*/
