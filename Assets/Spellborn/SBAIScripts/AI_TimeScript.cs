using System;
using Engine;
using SBAI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBAIScripts
{
    [Serializable] public class AI_TimeScript : AI_Script
    {
        [FoldoutGroup("AI_TimeScript")]
        public float BeginTime;

        [FoldoutGroup("AI_TimeScript")]
        public float EndTime;

        [FoldoutGroup("AI_TimeScript")]
        public bool StartupStart;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool EpochStarted;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float LastTime;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool StartedUp;

        public AI_TimeScript()
        {
        }
    }
}
/*
function Startup() {
StartedUp = True;                                                           
if (BeginTime < 0.00000000) {                                               
BeginTime = 0.00000000;                                                   
}
if (EndTime > 1.00000000) {                                                 
EndTime = 1.00000000;                                                     
}
LastTime = GetDayNightTime();                                               
if (StartupStart) {                                                         
if (BeginTime < EndTime) {                                                
if (LastTime >= BeginTime && LastTime <= EndTime) {                     
Debug("started at time" @ string(LastTime)
@ "because it's between [Sirenix.OdinInspector.FoldoutGroup("
@ string(BeginTime)
@ "..."
@ string(EndTime)
@ "]");
OnEpochBegin();                                                       
EpochStarted = True;                                                  
} else {                                                                
Debug("doesn't start at time" @ string(LastTime)
@ "because it's not between [Sirenix.OdinInspector.FoldoutGroup("
@ string(BeginTime)
@ "..."
@ string(EndTime)
@ "]");
}
} else {                                                                  
if (LastTime >= BeginTime || LastTime <= EndTime) {                     
Debug("started at time" @ string(LastTime)
@ "because it's between [Sirenix.OdinInspector.FoldoutGroup("
@ string(BeginTime)
@ "..."
@ string(EndTime)
@ "]");
OnEpochBegin();                                                       
EpochStarted = True;                                                  
} else {                                                                
Debug("doesn't start at time" @ string(LastTime)
@ "because it's not between [Sirenix.OdinInspector.FoldoutGroup("
@ string(BeginTime)
@ "..."
@ string(EndTime)
@ "]");
}
}
}
}
function OnEpochEnd() {
if (Event != 'None') {                                                      
UntriggerEvent(Event,self,None);                                          
}
}
function OnEpochBegin() {
if (Event != 'None') {                                                      
TriggerEvent(Event,self,None);                                            
}
}
protected event sv_OnScriptFrame(float aDeltaTime) {
local float t;
if (!StartedUp) {                                                           
Startup();                                                                
} else {                                                                    
t = GetDayNightTime();                                                    
if (!EpochStarted) {                                                      
if (BeginTime >= LastTime && BeginTime < t) {                           
Debug("epoch begins at time" @ string(BeginTime)
@ "because it's between [Sirenix.OdinInspector.FoldoutGroup("
@ string(LastTime)
@ "..."
@ string(t)
@ "]");
OnEpochBegin();                                                       
EpochStarted = True;                                                  
}
}
if (EpochStarted) {                                                       
if (EndTime >= LastTime && EndTime < t) {                               
Debug("epoch ends at time" @ string(EndTime)
@ "because it's between [Sirenix.OdinInspector.FoldoutGroup("
@ string(LastTime)
@ "..."
@ string(t)
@ "]");
OnEpochEnd();                                                         
EpochStarted = False;                                                 
}
}
LastTime = t;                                                             
}
}
*/