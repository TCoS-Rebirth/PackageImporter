using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_Sit : Content_Event
    {
        [FoldoutGroup("Action")]
        public NameProperty Chair;

        [FoldoutGroup("Action")]
        public Vector Offset;

        public EV_Sit()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
local Actor chairActor;
if (string(Chair) != "None") {                                              
chairActor = FindClosestActor(Class'Actor',aObject,Chair);                
aObject.SetLocation(chairActor.Location + Offset);                        
aObject.SetRotation(chairActor.Rotation);                                 
ApiTrace("EV_Sit.sv_Execute Sitting down on chair"
@ string(Chair)
@ "="
@ string(chairActor));
aObject.sv_Sit(True,True);                                                
} else {                                                                    
ApiTrace("EV_Sit.sv_Execute Sitting down on the ground");                 
aObject.sv_Sit(True,False);                                               
}
}
function bool ApiTracing() {
return True;                                                                
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
local Actor chairActor;
if (string(Chair) != "None") {                                              
chairActor = FindClosestActor(Class'Actor',aObject,Chair);                
return chairActor != None;                                                
}
if (!Game_Controller(aObject.Controller).IsIdle()) {                        
return False;                                                             
}
return True;                                                                
}
*/