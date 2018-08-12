using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class TriggeringLevelElement : InteractiveLevelElement
    {
        [FoldoutGroup("TriggeringLevelElement")]
        public List<MenuOptionRelationStruct> Triggers = new List<MenuOptionRelationStruct>();

        public TriggeringLevelElement()
        {
        }

        [Serializable] public struct MenuOptionRelationStruct
        {
            public byte Option;

            public Actor TriggeredActor;

            public NameProperty EventName;
        }
    }
}
/*
function OnTargetDescription(Pawn anInstigator) {
}
function bool sv_OnRadialMenuOption(Game_Pawn anInstigator,int anOption) {
local int i;
if (!Super.sv_OnRadialMenuOption(anInstigator,anOption)) {                  
return False;                                                             
}
if (Triggers.Length == 0) {                                                 
TriggerEvent(Event,self,anInstigator);                                    
} else {                                                                    
i = 0;                                                                    
while (i < Triggers.Length) {                                             
if (Triggers[i].Option == anOption) {                                   
if (Triggers[i].TriggeredActor != None) {                             
Triggers[i].TriggeredActor.Trigger(self,anInstigator);              
} else {                                                              
if (Triggers[i].EventName != 'None') {                              
TriggerEvent(Triggers[i].EventName,self,anInstigator);            
goto jl00DC;                                                      
}
}
goto jl00DF;                                                          
}
++i;                                                                    
}
}
return True;                                                                
}
*/