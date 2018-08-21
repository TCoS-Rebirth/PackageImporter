using System;
using SBBase;

namespace SBGame
{
    [Serializable] public class Game_MiniGameProxy : Base_Component
    {
        public void sv_PlayerDied() { }
    }
}
/*
event bool IsPlaying() {
return False;                                                               
}
event bool IsInviting() {
return False;                                                               
}
event cl_OnFrame(float DeltaTime) {
}
event cl_StartMiniGame(Game_PlayerPawn Opponent) {
}
*/