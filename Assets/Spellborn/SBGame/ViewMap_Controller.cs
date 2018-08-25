﻿using System;

namespace SBGame
{
    [Serializable] public class ViewMap_Controller : Game_PlayerController
    {
        public bool SceneManagerActive;

        public ViewMap_Controller()
        {
        }
    }
}
/*
exec function StopScene() {
local SceneManager SM;
local Game_GameClient Engine;
Engine = Game_GameClient(Class'Actor'.static.GetGameEngine());              
foreach AllActors(Class'SceneManager',SM) {                                 
Engine.StopSceneDump();                                                   
SM.CurrentTime = SM.TotalSceneTime;                                       
SceneManagerActive = False;                                               
goto jl0062;                                                              
}
}
exec function DumpScene(optional float StartTime) {
local SceneManager SM;
local Game_GameClient Engine;
Engine = Game_GameClient(Class'Actor'.static.GetGameEngine());              
foreach AllActors(Class'SceneManager',SM) {                                 
SM.bIsRunning = True;                                                     
SM.bIsSceneStarted = False;                                               
SM.OffsetStartFactor = StartTime;                                         
Player.Console.ConsoleClose();                                            
Engine.StartSceneDump();                                                  
SceneManagerActive = True;                                                
goto jl0093;                                                              
}
}
exec function StartScene(optional float StartTime) {
local SceneManager SM;
foreach AllActors(Class'SceneManager',SM) {                                 
SM.bIsRunning = True;                                                     
SM.bIsSceneStarted = False;                                               
SM.OffsetStartFactor = StartTime;                                         
SceneManagerActive = True;                                                
Player.Console.ConsoleClose();                                            
goto jl006A;                                                              
}
}
event cl_OnPlayerTick(float DeltaTime) {
if (!SceneManagerActive) {                                                  
Super.cl_OnPlayerTick(DeltaTime);                                         
if (Game_Pawn(Pawn).Physics == 4) {                                       
Game_Pawn(Pawn).Acceleration *= 0.69999999;                             
}
}
}
event cl_OnInit() {
Super.cl_OnInit();                                                          
if (GUI != None) {                                                          
GUI.HideMinimap();                                                        
GUI.HideChat();                                                           
GUI.HideCombatBar();                                                      
GUI.HidePlayerAvatar();                                                   
GUI.HideTeam();                                                           
GUI.HideFriends();                                                        
}
}
*/