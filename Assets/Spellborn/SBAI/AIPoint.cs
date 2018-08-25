using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAI
{
    [Serializable] public class AIPoint : AnnotationActor
    {
        [FoldoutGroup("Script")]
        public Annotation_Script AnnotationScript;

        [FoldoutGroup("Script")]
        public bool TriggerScript;

        [FoldoutGroup("Script")]
        public bool WaitForScript;

        public AIPoint()
        {
        }
    }
}
/*
event PointReached(Game_Pawn aPawn) {
if (Event != 'None') {                                                      
TriggerEvent(Event,self,aPawn);                                           
}
}
final native function bool GetWalking();
final native function AIPoint GetControlDestination(Game_Pawn aPawn);
*/