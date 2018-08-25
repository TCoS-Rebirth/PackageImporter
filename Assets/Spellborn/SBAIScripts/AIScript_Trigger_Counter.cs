using System;

namespace SBAIScripts
{
    [Serializable] public class AIScript_Trigger_Counter : AIScript_Counter
    {
        public AIScript_Trigger_Counter()
        {
        }
    }
}
/*
event Trigger(Actor Other,Pawn EventInstigator) {
Super.Trigger(Other,EventInstigator);                                       
DoCount();                                                                  
}
*/