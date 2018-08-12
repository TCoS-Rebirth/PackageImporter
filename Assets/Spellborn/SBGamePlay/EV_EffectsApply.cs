using System;
using System.Collections.Generic;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_EffectsApply : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public List<FSkill_EffectClass_AudioVisual> Effects = new List<FSkill_EffectClass_AudioVisual>();

        [FoldoutGroup("Action")]
        [FieldConst()]
        public bool ApplyToObject;

        [FoldoutGroup("Action")]
        [FieldConst()]
        public bool ApplyToSubject;

        [FoldoutGroup("Action")]
        [FieldConst()]
        public NameProperty Tag;

        [FoldoutGroup("Action")]
        [FieldConst()]
        public bool SubjectEffectIsPermanent;

        public EV_EffectsApply()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
local int i;
i = 0;                                                                      
while (i < Effects.Length) {                                                
if (aObject != None && ApplyToObject) {                                   
aObject.Effects.sv_StartTagged(Effects[i],Tag);                         
}
if (aSubject != None && ApplyToSubject) {                                 
if (SubjectEffectIsPermanent) {                                         
aSubject.Effects.sv_StartTagged(Effects[i],Tag);                      
goto jl00C2;                                                          
}
aSubject.Effects.sv_StartReplicatedOneShot(Effects[i]);                 
}
i++;                                                                      
}
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return Effects.Length > 0
&& (aObject != None || aSubject != None)
&& (ApplyToObject || ApplyToSubject)
&& Tag != 'None';
}
*/