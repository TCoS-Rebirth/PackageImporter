namespace Gameplay
{
    public class ACTION_WaitForEvent : LatentScriptedAction
    {

        //TriggeredCondition T;?

        public string ExternalEvent = "";

        public override string ActionString
        {
            get { return "Wait for external event"; }
        }
    }
}