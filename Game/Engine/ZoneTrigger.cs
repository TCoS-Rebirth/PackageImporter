﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------



namespace Engine
{


    public class ZoneTrigger : Trigger
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
