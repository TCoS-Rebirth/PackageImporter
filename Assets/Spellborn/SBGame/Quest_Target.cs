﻿using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable]
    public class Quest_Target: Content_Type
    {
        [FoldoutGroup("Target")]
        public List<Quest_Target> Pretargets = new List<Quest_Target>();

        [FoldoutGroup("Target")]
        public bool AlwaysVisible;

        [FoldoutGroup("Target")]
        public List<Content_Event> CompleteEvents = new List<Content_Event>();

        [FoldoutGroup("Target")]
        public LocalizedString Description;

        public bool Active(int aValue)
        {
            throw new NotImplementedException();
        }

        public void RadialMenuCollect(Game_Pawn aPlayerPawn, object aObject, Game_RadialMenuOptions.ERadialMenuOptions aMainOption, out List<Game_RadialMenuOptions.ERadialMenuOptions> aSubOptions)
        {
            throw new NotImplementedException();
        }

        [Serializable]
        public struct QuestInventory
        {
            public Item_Type Item;

            public int Amount;
        }
    }
}
/*
final native function int GetCompletedProgressValue();
protected function AppendProgressText(out string aDescription,int aProgress) {
}
event string GetActiveText(Game_ActiveTextItem aItem) {
local export editinline Quest_Type quest;
if (aItem == None) {                                                        
return GetDescription(0);                                                 
} else {                                                                    
if (aItem.Tag == "D") {                                                   
return GetDescription(aItem.Ordinality);                                
} else {                                                                  
if (aItem.Tag == "Q") {                                                 
quest = GetQuest();                                                   
if (quest != None) {                                                  
return quest.GetActiveText(aItem.SubItem);                          
}
}
}
}
return Super.GetActiveText(aItem);                                          
}
protected function string GetDefaultDescription() {
return "objective default descriptions must be overriden";                  
}
final function string GetDescription(int aProgress) {
local string ret;
if (Len(Description.Text) > 0) {                                            
ret = Description.Text;                                                   
} else {                                                                    
ret = GetDefaultDescription();                                            
}
AppendProgressText(ret,aProgress);                                          
return ret;                                                                 
}
event bool sv_OnComplete(Game_Pawn aPawn,optional Game_Pawn aTargetPawn) {
local int ei;
if (aTargetPawn == None
|| !aTargetPawn.IsA('Game_NPCPawn')) {        
aTargetPawn = aPawn;                                                      
}
ei = 0;                                                                     
while (ei < CompleteEvents.Length) {                                        
if (CompleteEvents[ei] != None
&& !CompleteEvents[ei].sv_CanExecute(aTargetPawn,aPawn)) {
return False;                                                           
}
ei++;                                                                     
}
ei = 0;                                                                     
while (ei < CompleteEvents.Length) {                                        
CompleteEvents[ei].sv_Execute(aTargetPawn,aPawn);                         
ei++;                                                                     
}
return True;                                                                
}
final native function Quest_Type GetQuest();
final native function int GetIndex();
final native function bool NearlyDone(int aValue);
final native function bool Failed(int aValue);
final native function bool Check(int aValue);
final native function int ComputeValue(Game_Pawn aPawn);
final native function bool sv_CanAccept(Game_Pawn aPawn);
*/
