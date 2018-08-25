using System;
using Engine;

namespace SBGame
{
    [Serializable] public class StateListener : UObject
    {
        //public delegate<OnStateBegin> @__OnStateBegin__Delegate;

        //public delegate<OnStateEnd> @__OnStateEnd__Delegate;

        //public delegate<OnStateCancel> @__OnStateCancel__Delegate;

        public StateListener()
        {
        }
    }
}
/*
delegate OnStateCancel(name aStateName);
delegate OnStateEnd(name aStateName);
delegate OnStateBegin(name aStateName);
*/