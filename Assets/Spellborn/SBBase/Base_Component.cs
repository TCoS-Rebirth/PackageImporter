using System;
using Engine;
using UnityEngine;

namespace SBBase
{
#pragma warning disable 414   

    [Serializable] public class Base_Component : UObject
    {

        [FieldConst()]
        public bool ComponentInitialized;

        [FieldConst()]
        private string ComponentName = string.Empty;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int ExCleanIndex;

        public virtual void cl_OnInit()
        {
            ComponentInitialized = true;
        }

    }
}
/*
function string GetComponentDescription() {
local string Desc;
if (IsPawnComponent()) {                                                    
Desc = "Pawn";                                                            
} else {                                                                    
if (IsControllerComponent()) {                                            
Desc = "Controller";                                                    
} else {                                                                  
Desc = "Unknown";                                                       
}
}
return Desc;                                                                
}
function bool IsControllerComponent() {
return Base_Controller(Outer) != None;                                      
}
function bool IsPawnComponent() {
return Base_Pawn(Outer) != None;                                            
}
native function bool sv_CanReplicate();
event cl_OnGroupChange(int newGroupFlags);
event cl_OnUpdate();
event cl_OnBaseline();
event cl_OnShutdown() {
ComponentInitialized = False;                                               
}
final native event sv_OnShutdown();
final native event sv_OnLogin();
final native event sv_OnInit();
*/