using Engine;

namespace Gameplay
{
    [System.Serializable] public class ACTION_WaitForEvent : LatentScriptedAction
    {

        //TriggeredCondition T;?

        public NameProperty ExternalEvent = "";

        public override string ActionString
        {
            get { return "Wait for external event"; }
        }
    }
}