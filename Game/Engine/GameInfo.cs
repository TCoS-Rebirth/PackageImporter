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


    public class GameInfo : Info
    {
        
        public GameInfo()
        {
        }
    }
}
/*
function bool PlayerRespawned(Controller aContoller);
function bool PlayerDied(Controller aContoller);
function NavigationPoint FindPlayerStart() {
local NavigationPoint N;
N = Level.NavigationPointList;                                              
while (N != None) {                                                         
if (N.IsA('PlayerStart')) {                                               
return N;                                                               
}
N = N.nextNavigationPoint;                                                
}
return None;                                                                
}
event cl_OnUpdate() {
}
event cl_OnBaseline() {
}
event cl_OnShutdown();
event cl_OnInit();
event sv_OnShutdown();
event sv_OnInit();
*/