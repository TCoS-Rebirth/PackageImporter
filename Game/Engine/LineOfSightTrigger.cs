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


    public class LineOfSightTrigger : Triggers
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="LineOfSightTrigger")]
        public float MaxViewDist;
        
        public float OldTickTime;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="LineOfSightTrigger")]
        public bool bEnabled;
        
        public bool bTriggered;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="LineOfSightTrigger")]
        public string SeenActorTag = string.Empty;
        
        public Actor SeenActor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="LineOfSightTrigger")]
        public int MaxViewAngle;
        
        public float RequiredViewDir;
        
        public LineOfSightTrigger()
        {
        }
    }
}
/*
function Trigger(Actor Other,Pawn EventInstigator) {
bEnabled = True;                                                            
}
event PlayerSeesMe(PlayerController P) {
TriggerEvent(Event,self,P.Pawn);                                            
bTriggered = True;                                                          
}
function PostBeginPlay() {
Super.PostBeginPlay();                                                      
RequiredViewDir = Cos(MaxViewAngle * 3.14159274 / 180);                     
if (SeenActorTag != 'None') {                                               
foreach AllActors(Class'Actor',SeenActor,SeenActorTag) {                  
goto jl004A;                                                            
}
}
}
*/