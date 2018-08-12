using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBBase
{
    [Serializable] public class Base_GameInfo : GameInfo
    {

        public float mFixedRelativeTimeOfDay;

        [FoldoutGroup("Base_GameInfo")]
        [TypeProxyDefinition(TypeName = "Base_Controller")]
        public Type mPlayerControllerClass;

        [FoldoutGroup("Base_GameInfo")]
        [TypeProxyDefinition(TypeName = "Base_Controller")]
        public Type mTestBotControllerClass;

        [FoldoutGroup("Base_GameInfo")]
        [TypeProxyDefinition(TypeName = "Base_Controller")]
        public Type mGameMasterControllerClass;

        public Base_GameInfo()
        {
        }
    }
}
/*
event cl_OnUpdate();
event cl_OnFrame(float delta);
event cl_OnLogout(Actor controllerActor) {
local Base_Controller Controller;
local Base_Pawn Pawn;
if (controllerActor != None) {                                              
Controller = Base_Controller(controllerActor);                            
if (Controller.Pawn != None) {                                            
Pawn = Base_Pawn(Controller.Pawn);                                      
Pawn.cl_OnShutdown();                                                   
Controller.cl_OnShutdown();                                             
Pawn.Destroy();                                                         
Controller.Destroy();                                                   
} else {                                                                  
Controller.cl_OnShutdown();                                             
Controller.Destroy();                                                   
}
}
}
event cl_OnBaseline();
event sv_OnLogout(int aAccountID,Base_Pawn aPawn) {
local Base_Controller Controller;
if (aPawn != None) {                                                        
Controller = Base_Controller(aPawn.Controller);                           
aPawn.sv_OnShutdown();                                                    
Controller.sv_OnShutdown();                                               
aPawn.Destroy();                                                          
Controller.Destroy();                                                     
}
}
*/