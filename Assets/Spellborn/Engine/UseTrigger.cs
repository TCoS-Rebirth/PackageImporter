using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class UseTrigger : Triggers
    {
        [FoldoutGroup("UseTrigger")]
        public string Message = string.Empty;

        public UseTrigger()
        {
        }
    }
}
/*
function Touch(Actor Other) {
if (Pawn(Other) != None) {                                                  
if (AIController(Pawn(Other).Controller) != None) {                       
UsedBy(Pawn(Other));                                                    
}
}
}
function UsedBy(Pawn User) {
TriggerEvent(Event,self,User);                                              
}
function bool SelfTriggered() {
return True;                                                                
}
*/