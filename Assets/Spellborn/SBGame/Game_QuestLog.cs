using System;
using System.Collections.Generic;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
    [Serializable]
    public class Game_QuestLog: Base_Component
    {
        [NonSerialized] public List<int> targetProgress = new List<int>();
        [NonSerialized, HideInInspector] public List<Quest_Type> Quests = new List<Quest_Type>();
        [NonSerialized] public List<int> TargetActivation = new List<int>();
        [NonSerialized] public List<QuestTimerProgress> QuestTimers = new List<QuestTimerProgress>();
        [NonSerialized, HideInInspector] public List<CompleteQuest> CompletedQuests = new List<CompleteQuest>();

        public void RadialMenuCollect(object aObject, Game_RadialMenuOptions.ERadialMenuOptions aMainOption, out List<Game_RadialMenuOptions.ERadialMenuOptions> aSubOptions)
        {
            aSubOptions = new List<Game_RadialMenuOptions.ERadialMenuOptions>();
            int TargetIndex = 0;
            if (aMainOption == Game_RadialMenuOptions.ERadialMenuOptions.RMO_MAIN)
            {
                for (var qi = 0; qi < Quests.Count; qi++)
                {
                    for (var ti = 0; ti < Quests[qi].Targets.Count; ti++, TargetIndex++)
                    {
                        if (GetTargetActivation(Quests[qi], ti) && Quests[qi].Targets[ti].Active(targetProgress[TargetIndex]))
                        {
                            Quests[qi].Targets[ti].RadialMenuCollect(Outer as Game_Pawn, aObject, aMainOption, out aSubOptions);
                        }
                    }
                }
            }
        }

        bool GetTargetActivation(Quest_Type aQuest, int TargetNr)
        {
            throw new NotImplementedException();
        }

        [Serializable]
        public struct CompleteQuest
        {
            public Quest_Type quest;
            public int TimesFinished;
        }

        [Serializable]
        public struct QuestTimerProgress
        {
            public Quest_Type quest;
            public int TargetIndex;
            public float Time;
            public int LastTime;
            public int GoalTime;
        }
    }
}
/*
final native function sv_SetTargetProgress(export editinline Quest_Target aTarget,int aValue,Game_Pawn aTargetPawn);
final native function sv_IncrementTargetProgress(export editinline Quest_Target aTarget,int aValue,Game_Pawn aTargetPawn);
final native function bool sv_SetTargetAsCompleted(export editinline Quest_Target aTarget,Game_Pawn aTargetPawn);
protected final native function SetTargetProgress(export editinline Quest_Type aQuest,int TargetNr,int aProgress);
final native function sv_RemoveTargetTimer(export editinline Quest_Target aTarget);
final native function bool RemoveQuest(export editinline Quest_Type aQuest);
protected event cl_ActivateTarget(export editinline Quest_Target aTarget,bool aActivate) {
}
protected final native function sv_ActivateTarget(export editinline Quest_Target aTarget,bool aActivate);
protected final native function ComputeTargetActivation(export editinline Quest_Type aQuest);
protected final native function AddQuest(export editinline Quest_Type aQuest,array<int> aProgress);
protected final native function AddCompletedQuest(export editinline Quest_Type aQuest);
protected final native function AddFinishedQuest(export editinline Quest_Type aQuest,int aTimes);
private native function UpdateQuestInventory(export editinline Quest_Type aQuest);
final native function GetQuestInventory(export editinline Quest_Type quest,out array<QuestInventory> oInventory);

final native function bool FinalTargetsCompleted(export editinline Quest_Condition aCondition);
final native function int GetTimesQuestFinished(export editinline Quest_Type aQuest);
final native function bool HasQuest(export editinline Quest_Type aQuest);
final native function bool IsTargetVisible(export editinline Quest_Type aQuest,int TargetNr);
final native function bool GetActivation(export editinline Quest_Target aTarget);
final native function int GetProgress(export editinline Quest_Target aTarget);
final native function int GetTargetProgress(export editinline Quest_Type aQuest,int TargetNr);
final native function bool FailedQuest(export editinline Quest_Type aQuest);
final native function bool CompletedQuest(export editinline Quest_Type aQuest,optional bool aNearly);
final native function bool sv_AbandonQuest(export editinline Quest_Type aQuest);
final native function bool sv_FinishQuest(export editinline Quest_Type aQuest);
final native function bool sv_AcceptQuest(export editinline Quest_Type aQuest);
delegate OnFinishQuest(int aQuestID);
delegate OnAcceptQuest(int aQuestID);
delegate OnQuestItemsAdded(export editinline Item_Type aItemType,int aAmount);
delegate OnQuestInventoryChange(export editinline Quest_Type aQuest);
delegate OnTargetActivation(export editinline Quest_Type aQuest,int aTargetNr,bool aOn);
delegate OnQuestProgress(export editinline Quest_Type aQuest,int aTargetNr,int aProgress);
delegate OnRemoveQuest(export editinline Quest_Type aQuest);
delegate OnAddCompletedQuest(export editinline Quest_Type aQuest);
delegate OnAddQuest(export editinline Quest_Type aQuest);
*/
