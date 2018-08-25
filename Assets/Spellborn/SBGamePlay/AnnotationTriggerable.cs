using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class AnnotationTriggerable : AnnotationActor
    {
        [FoldoutGroup("Annotation")]
        public bool Passable;

        public AnnotationTriggerable()
        {
        }
    }
}
/*
event UnTrigger(Actor Other,Pawn EventInstigator) {
Super.UnTrigger(Other,EventInstigator);                                     
Passable = False;                                                           
}
event Trigger(Actor Other,Pawn EventInstigator) {
Super.Trigger(Other,EventInstigator);                                       
Passable = True;                                                            
}
*/