using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_Emote : Content_Event
    {
        [FoldoutGroup("Action")]
        public byte Emote;

        public EV_Emote()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
aObject.Emotes.sv_PlayContentEmote(Emote);                                  
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
if (aObject.Emotes != None) {                                               
return True;                                                              
}
return False;                                                               
}
*/