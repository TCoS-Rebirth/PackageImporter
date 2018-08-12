using System;

namespace SBGame
{
    [Serializable] public class ViewMap_GameInfo : Game_GameInfo
    {
        public float GameSpeed;

        public ViewMap_GameInfo()
        {
        }
    }
}
/*
exec function SloMo(float t) {
local float OldSpeed;
OldSpeed = GameSpeed;                                                       
GameSpeed = FMax(t,0.10000000);                                             
Level.TimeDilation = 1.10000002 * GameSpeed;                                
if (GameSpeed != OldSpeed) {                                                
default.GameSpeed = GameSpeed;                                            
Class'GameInfo'.static.StaticSaveConfig();                                
}
SetTimer(Level.TimeDilation,True);                                          
}
*/