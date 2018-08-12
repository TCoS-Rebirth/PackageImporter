using System;
using Engine;

namespace SBBase
{
    [Serializable] public class Base_Notification : UObject
    {
        public int mNotificationData;

        public Base_Notification()
        {
        }
    }
}
/*
final native function RemoveListener(Object Object);
final native function AddListener(Object Object,name funcName);
native function Delete();
*/