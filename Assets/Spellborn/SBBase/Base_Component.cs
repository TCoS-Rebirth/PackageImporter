using System;
using Engine;
using UnityEngine;

namespace SBBase
{
#pragma warning disable 414   

    [Serializable] public class Base_Component : UObject
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int mhastransactionmanager_data;

        [FieldConst()]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int d_Component;

        [FieldConst()]
        public bool ComponentInitialized;

        [FieldConst()]
        private string ComponentName = string.Empty;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int ExCleanIndex;

        public Base_Component()
        {
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
event cl_OnInit() {
ComponentInitialized = True;                                                
}
final native event sv_OnShutdown();
final native event sv_OnLogin();
final native event sv_OnInit();
*/