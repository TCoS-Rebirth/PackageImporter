using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_Scenario : Content_Event
    {
        [FoldoutGroup("Action")]
        public string ScenarioTag = string.Empty;

        public EV_Scenario()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn anObject,Game_Pawn aSubject) {
local export editinline Scenario aScenario;
aScenario = Scenario(static.DynamicLoadObject(ScenarioTag,Class'Scenario'));
aScenario.ForwardEvents(anObject);                                          
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
local export editinline Scenario aScenario;
aScenario = Scenario(static.DynamicLoadObject(ScenarioTag,Class'Scenario'));
if (aScenario != None
&& aScenario.VerifyRequirements(aObject)) {     
return True;                                                              
}
return False;                                                               
}
*/