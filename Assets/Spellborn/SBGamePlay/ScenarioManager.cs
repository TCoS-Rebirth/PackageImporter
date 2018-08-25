using Engine;
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SBGamePlay
{    
    [System.Serializable] public class ScenarioManager : Actor
    {
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private Scenario mScenarioInUse;
        
        [Sirenix.OdinInspector.FoldoutGroup("ScenarioManager")]
        public Scenario CurrentScenario;
        
        [Sirenix.OdinInspector.FoldoutGroup("ScenarioManager")]
        public bool TriggerOnLevelStart;
    }
}
/*
function bool StartScenario(string aScenarioName,Game_Pawn aPawn) {
local export editinline Scenario aScenario;
aScenario = Scenario(static.DynamicLoadObject(aScenarioName,Class'Scenario'));
if (aScenario != None
&& aScenario.VerifyRequirements(aPawn)) {       
aScenario.ForwardEvents(aPawn);                                           
return True;                                                              
}
return False;                                                               
}
*/
