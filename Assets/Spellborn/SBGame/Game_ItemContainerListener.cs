using System;
using Engine;

namespace SBGame
{
    [Serializable] public class Game_ItemContainerListener : UObject
    {
        public byte mLocationType;

        public int mLocationSlot;

        public int mLocationID;

        //public delegate<OnUpdateContainer> @__OnUpdateContainer__Delegate;

        //public delegate<OnSetContainerLock> @__OnSetContainerLock__Delegate;

        //public delegate<OnUsedItem> @__OnUsedItem__Delegate;

        public Game_ItemContainerListener()
        {
        }
    }
}
/*
event SetItemLocation(byte aLocationType,int aLocationSlot,optional int aLocationID) {
mLocationType = aLocationType;                                              
mLocationSlot = aLocationSlot;                                              
mLocationID = aLocationID;                                                  
}
delegate OnUsedItem();
delegate OnSetContainerLock(bool aLock);
delegate OnUpdateContainer(Game_Item aItem);
*/