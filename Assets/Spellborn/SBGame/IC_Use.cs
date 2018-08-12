using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class IC_Use : Item_Component
    {
        [FoldoutGroup("ContentEvent")]
        [FieldConst()]
        public List<Content_Event> Events = new List<Content_Event>();

        public IC_Use()
        {
        }
    }
}
/*
event OnUse(Game_Pawn aPawn,Game_Item aItem) {
local int ei;
local export editinline Content_Event E;
ei = 0;                                                                     
while (ei < Events.Length) {                                                
E = Events[ei];                                                           
if (E != None) {                                                          
E.sv_Execute(aPawn,aPawn);                                              
}
ei++;                                                                     
}
}
event bool CanUse(Game_Pawn aPawn,Game_Item aItem) {
local int ei;
local export editinline Content_Event E;
ei = 0;                                                                     
while (ei < Events.Length) {                                                
E = Events[ei];                                                           
if (E != None && !E.sv_CanExecute(aPawn,aPawn)) {                         
return False;                                                           
}
ei++;                                                                     
}
return Super.CanUse(aPawn,aItem);                                           
}
*/