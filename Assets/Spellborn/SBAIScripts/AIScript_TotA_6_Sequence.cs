﻿using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBAIScripts
{
    [Serializable] public class AIScript_TotA_6_Sequence : AIRegistered
    {
        [FoldoutGroup("AIScript_TotA_6_Sequence")]
        [FieldConst()]
        public int NumSquares;

        [FoldoutGroup("AIScript_TotA_6_Sequence")]
        [FieldConst()]
        public int NumKillMobs;

        [FoldoutGroup("AIScript_TotA_6_Sequence")]
        [FieldConst()]
        public string BaseSquareTag = string.Empty;

        [FoldoutGroup("AIScript_TotA_6_Sequence")]
        [FieldConst()]
        public string FirstSpawnTag = string.Empty;

        [FoldoutGroup("AIScript_TotA_6_Sequence")]
        [FieldConst()]
        public string FinishEvent = string.Empty;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int KilledMobs;

        public AIScript_TotA_6_Sequence()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local int i;
Super.GetActorRelations(oRelations);                                        
i = 0;                                                                      
while (i < NumSquares) {                                                    
GetTaggedRelations(BaseSquareTag $ string(i + 1),static.RGB(255,100,100),"<" $ string(i + 1) $ ">",oRelations);
i++;                                                                      
}
}
function ResetFight() {
local int i;
local array<RegisteredAI> Register;
Register = GetRegister();                                                   
i = 0;                                                                      
while (i < NumSquares) {                                                    
TriggerEvent(name(BaseSquareTag $ string(i + 1)),self,None);              
i++;                                                                      
}
i = 0;                                                                      
while (i < Register.Length) {                                               
Despawn(Register[i].Controller);                                          
i++;                                                                      
}
i = 0;                                                                      
while (i < NumSquares) {                                                    
UntriggerEvent(name(BaseSquareTag $ string(i + 1)),self,None);            
i++;                                                                      
}
KilledMobs = 0;                                                             
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
ResetFight();                                                               
}
event Trigger(Actor Other,Pawn EventInstigator) {
local int i;
local array<RegisteredAI> Register;
if (Other.IsA('AIScript_TotA_6_Neighbours')) {                              
KilledMobs++;                                                             
Debug("Killed mobs:" @ string(KilledMobs));                               
if (KilledMobs >= NumKillMobs) {                                          
TriggerEvent(name(FinishEvent),self,EventInstigator);                   
i = 0;                                                                  
while (i < NumSquares) {                                                
TriggerEvent(name(BaseSquareTag $ string(i + 1)),self,None);          
i++;                                                                  
}
Register = GetRegister();                                               
i = 0;                                                                  
while (i < Register.Length) {                                           
Despawn(Register[i].Controller);                                      
i++;                                                                  
}
} else {                                                                  
i = 0;                                                                  
while (i < NumSquares) {                                                
UntriggerEvent(name(BaseSquareTag $ string(i + 1)),self,None);        
i++;                                                                  
}
}
} else {                                                                    
TriggerEvent(name(FirstSpawnTag),self,EventInstigator);                   
}
}
*/