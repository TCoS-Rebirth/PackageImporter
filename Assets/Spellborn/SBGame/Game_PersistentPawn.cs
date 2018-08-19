using System;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Game_PersistentPawn : Game_Pawn
    {
        [NonSerialized, HideInInspector]
        public float NextPositionStoreTime;

        [NonSerialized, HideInInspector]
        public Game_PersistentData mPersistentData;

        public override void OnCreateComponents() {
            base.OnCreateComponents();                                                 
            //if (IsClient()) {                                                           
                //mPersistentData = new (self) Class'Game_PersistentData';                  
            //}
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
event cl_OnInit() {
Super.cl_OnInit();                                                          
mPersistentData.Read();                                                     
}

*/