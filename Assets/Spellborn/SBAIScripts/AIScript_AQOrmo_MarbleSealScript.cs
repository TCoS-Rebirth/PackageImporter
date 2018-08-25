﻿using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_AQOrmo_MarbleSealScript : AI_Script
    {
        [FoldoutGroup("AIScript_AQOrmo_MarbleSealScript")]
        public List<tier> Tiers = new List<tier>();

        [FoldoutGroup("AIScript_AQOrmo_MarbleSealScript")]
        [FieldConst()]
        public float ChargeTime;

        [FoldoutGroup("AIScript_AQOrmo_MarbleSealScript")]
        [FieldConst()]
        public float DisChargeTime;

        [FoldoutGroup("AIScript_AQOrmo_MarbleSealScript")]
        [FieldConst()]
        public string FinalChargeEvent = string.Empty;

        [FoldoutGroup("AIScript_AQOrmo_MarbleSealScript")]
        [FieldConst()]
        public string FinalChargeUnEvent = string.Empty;

        public byte SealState;

        public float DischargeFactor;

        public float CurrentCharge;

        public int CurrentTier;

        public AIScript_AQOrmo_MarbleSealScript()
        {
        }

        [Serializable] public struct tier
        {
            public string ChargingEvent;

            public string ChargedEvent;
        }

        public enum ESealState
        {
            STATE_IDLE,

            STATE_DISCHARGING,

            STATE_CHARGING,
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local int i;
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(FinalChargeEvent,static.RGB(100,100,255),"FinalChargeEvent:" @ FinalChargeEvent,oRelations);
GetTaggedRelations(FinalChargeUnEvent,static.RGB(255,100,100),"FinalChargeUnEvent:" @ FinalChargeUnEvent,oRelations);
i = 0;                                                                      
while (i < Tiers.Length) {                                                  
GetTaggedRelations(Tiers[i].ChargingEvent,static.RGB(100,100,255),"Tier" @ string(i) @ " ChargingEvent:"
@ Tiers[i].ChargingEvent,oRelations);
i++;                                                                      
}
}
protected event sv_OnScriptFrame(float DeltaTime) {
switch (SealState) {                                                        
case 2 :                                                                  
CurrentCharge += DeltaTime;                                             
if (CurrentCharge >= ChargeTime) {                                      
UntriggerEvent(name(Tiers[CurrentTier].ChargingEvent),None,None);     
TriggerEvent(name(Tiers[CurrentTier].ChargedEvent),None,None);        
CurrentTier++;                                                        
if (CurrentTier >= Tiers.Length) {                                    
if (FinalChargeEvent != "" && FinalChargeEvent != "none") {         
TriggerEvent(name(FinalChargeEvent),None,None);                   
UntriggerEvent(name(FinalChargeUnEvent),None,None);               
}
TriggerEvent(Event,self,None);                                      
FrameOff();                                                         
} else {                                                              
StartCharging();                                                    
}
}
break;                                                                  
case 1 :                                                                  
CurrentCharge -= DeltaTime * DischargeFactor;                           
if (CurrentCharge <= 0) {                                               
SealState = 0;                                                        
CurrentCharge = 0.00000000;                                           
UntriggerEvent(name(Tiers[CurrentTier].ChargingEvent),None,None);     
}
break;                                                                  
default:                                                                  
}
}
function StartCharging() {
SealState = 2;                                                              
TriggerEvent(name(Tiers[CurrentTier].ChargingEvent),None,None);             
CurrentCharge = 0.00000000;                                                 
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
SealState = 1;                                                              
Super.UnTrigger(Other,EventInstigator);                                     
}
event Trigger(Actor Other,Pawn EventInstigator) {
Super.Trigger(Other,EventInstigator);                                       
StartCharging();                                                            
}
event PostBeginPlay() {
Super.PostBeginPlay();                                                      
CurrentCharge = 0.00000000;                                                 
CurrentTier = 0;                                                            
DischargeFactor = ChargeTime / DisChargeTime;                               
}
*/