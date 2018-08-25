using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_EffectsRemove : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public bool RemoveFromObject;

        [FoldoutGroup("Action")]
        [FieldConst()]
        public bool RemoveFromSubject;

        [FoldoutGroup("Action")]
        [FieldConst()]
        public NameProperty Tag;

        public EV_EffectsRemove()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
if (RemoveFromObject) {                                                     
aObject.Effects.sv_StopTagged(Tag);                                       
}
if (RemoveFromSubject) {                                                    
aSubject.Effects.sv_StopTagged(Tag);                                      
}
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return (aObject != None || aSubject != None)
&& (RemoveFromObject || RemoveFromSubject)
&& Tag != 'None';
}
*/