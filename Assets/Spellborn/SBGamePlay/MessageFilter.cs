using System;
using Engine;

namespace SBGamePlay
{
    [Serializable] public class MessageFilter : UObject
    {
        public int flags;

        public MessageFilter()
        {
        }
    }
}
/*
function bool HasFlag(int Flag) {
return (flags & Flag) > 0;                                                  
}
function RemoveFlag(int oldFlag) {
flags = flags & ~oldFlag;                                                   
}
function AddFlag(int newFlag) {
flags = flags | newFlag;                                                    
}
function int GetTotalFlags() {
return flags;                                                               
}
function InitFlag(int NewValue) {
flags = NewValue;                                                           
}
*/