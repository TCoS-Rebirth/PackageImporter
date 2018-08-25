using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_RemoveItem : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public Content_Inventory Items;

        public EV_RemoveItem()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
RemoveItems(aSubject,Items);                                                
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
if (HasItems(aSubject,Items)) {                                             
return True;                                                              
}
return False;                                                               
}
*/