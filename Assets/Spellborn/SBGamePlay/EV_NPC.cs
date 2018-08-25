using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_NPC : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public NPC_Type NPC;

        [FoldoutGroup("Action")]
        [FieldConst()]
        public Content_Event NPCAction;

        [FoldoutGroup("Action")]
        [FieldConst()]
        public float Radius;

        public EV_NPC()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
local Game_Pawn npcPawn;
if (aObject != None) {                                                      
npcPawn = FindNPC(aObject,NPC,Radius);                                    
}
if (npcPawn == None) {                                                      
npcPawn = FindNPC(aSubject,NPC,Radius);                                   
}
NPCAction.sv_Execute(npcPawn,aSubject);                                     
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
local Game_Pawn npcPawn;
if (NPCAction != None) {                                                    
if (aObject != None) {                                                    
npcPawn = FindNPC(aObject,NPC,Radius);                                  
}
if (npcPawn == None) {                                                    
npcPawn = FindNPC(aSubject,NPC,Radius);                                 
}
if (npcPawn != None) {                                                    
return NPCAction.sv_CanExecute(npcPawn,aSubject);                       
}
}
return False;                                                               
}
*/