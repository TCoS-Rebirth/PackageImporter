using System;

namespace Engine
{
    [Serializable] public class ZoneTrigger : Trigger
    {
        public ZoneTrigger()
        {
        }
    }
}
/*
function UnTouch(Actor Other) {
local ZoneInfo Z;
if (IsRelevant(Other)) {                                                    
if (Event != 'None') {                                                    
foreach AllActors(Class'ZoneInfo',Z) {                                  
if (Z.ZoneTag == Event) {                                             
Z.UnTrigger(Other,Other.Instigator);                                
}
}
}
}
}
function Touch(Actor Other) {
local ZoneInfo Z;
if (IsRelevant(Other)) {                                                    
if (Event != 'None') {                                                    
foreach AllActors(Class'ZoneInfo',Z) {                                  
if (Z.ZoneTag == Event) {                                             
Z.Trigger(Other,Other.Instigator);                                  
}
}
}
if (bTriggerOnceOnly) {                                                   
SetCollision(False);                                                    
}
}
}
*/