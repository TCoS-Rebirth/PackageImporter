namespace Gameplay
{
    public class ACTION_WaitForTimer : LatentScriptedAction
    {
        public float PauseTime = 0;

        public override string ActionString
        {
            get { return "Wait for timer"; }
        }
    }
}