using System;

namespace Engine
{
    [Serializable] public class GameInfo : Info
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