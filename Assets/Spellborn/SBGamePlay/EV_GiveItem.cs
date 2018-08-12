using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_GiveItem : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public Content_Inventory Items;

        public EV_GiveItem()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
GiveItems(aSubject,Items);                                                  
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
if (CanReceiveItems(aSubject,Items)) {                                      
return True;                                                              
}
return False;                                                               
}
*/