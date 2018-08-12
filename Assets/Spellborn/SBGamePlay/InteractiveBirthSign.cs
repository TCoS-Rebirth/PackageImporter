using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class InteractiveBirthSign : InteractiveLevelElement
    {
        [FoldoutGroup("InteractiveBirthSign")]
        [FieldConst()]
        public NameProperty Spawner_Event;

        [FoldoutGroup("InteractiveBirthSign")]
        public NameProperty DeactivationEvent;

        [FoldoutGroup("InteractiveBirthSign")]
        [FieldConst()]
        public Trigger ProximityTrigger;

        public bool Activated;

        public bool Deactivated;

        public InteractiveBirthSign()
        {
        }
    }
}
/*
protected native function sv2rel_PlaySoundEvent_CallStub();
event sv2rel_PlaySoundEvent() {
TriggerEvent(SoundEvent,self,None);                                         
}
protected native function sv2rel_ShowGlow_CallStub();
event sv2rel_ShowGlow(bool val) {
BirthSignGlow.bHidden = !val;                                               
}
event Trigger(Actor Other,Pawn EventInstigator) {
sv_SetEnabled(True);                                                        
}
function ActivateBirthSign() {
sv2rel_ShowGlow_CallStub(True);                                             
sv2rel_PlaySoundEvent_CallStub();                                           
TriggerEvent(Spawner_Event,self,None);                                      
Activated = True;                                                           
}
*/