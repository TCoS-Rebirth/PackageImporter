using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class AIScript : Keypoint
    {
        [FoldoutGroup("AIScript")]
        [TypeProxyDefinition(TypeName = "AIController")]
        public Type ControllerClass;

        public bool bNavigate;

        [FoldoutGroup("AIScript")]
        public bool bLoggingEnabled;

        public AIMarker myMarker;

        public AIScript()
        {
        }
    }
}
/*
function TakeOver(Pawn P);
function Actor GetMoveTarget() {
if (myMarker != None) {                                                     
return myMarker;                                                          
}
return self;                                                                
}
function SpawnControllerFor(Pawn P) {
local AIController C;
if (ControllerClass == None) {                                              
if (P.ControllerClass == None) {                                          
return;                                                                 
}
C = Spawn(P.ControllerClass,,,P.Location,P.Rotation);                     
} else {                                                                    
C = Spawn(ControllerClass,,,P.Location,P.Rotation);                       
}
C.MyScript = self;                                                          
}
*/