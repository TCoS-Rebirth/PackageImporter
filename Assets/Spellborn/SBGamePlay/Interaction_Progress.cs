using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class Interaction_Progress : Interaction_Component
    {
        [FoldoutGroup("Interaction_Progress")]
        public string AnimationName = string.Empty;

        [FoldoutGroup("Interaction_Progress")]
        [FieldConst()]
        public float speed;

        [FoldoutGroup("Interaction_Progress")]
        public float ProgressSeconds;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float mTimer;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool mAborted;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_PlayerPawn mInstigatorPawn;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Vector mLocation;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float mHealth;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool mIsShifted;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mActiveSkillsNum;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public NameProperty mAttachmentName;

        public Interaction_Progress()
        {
        }
    }
}
/*
function ClOnCancel(Game_Actor aOwner,Game_Pawn aInstigator) {
Super.ClOnCancel(aOwner,aInstigator);                                       
aInstigator.mIsInteracting = False;                                         
if (aInstigator != None) {                                                  
aInstigator.ClearAnimsByType(9,0.00000000);                               
if (aInstigator.IsLocalPlayer()) {                                        
Game_PlayerController(aInstigator.Controller).Player.GUIDesktop.UpdateStdWindow(87,2,None,"",0);
Game_PlayerController(aInstigator.Controller).Player.GUIDesktop.ShowStdWindow(87,2);
}
}
}
function ClOnEnd(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local Actor attachmentActor;
if (!aReverse) {                                                            
if (aInstigator != None) {                                                
aInstigator.ClearAnimsByType(9,0.00000000);                             
if (Tool != None) {                                                     
attachmentActor = aInstigator.FindAttachment(mAttachmentName,name("Weapon1"));
if (attachmentActor != None) {                                        
aInstigator.DetachFromBone(attachmentActor);                        
attachmentActor.Destroy();                                          
attachmentActor = None;                                             
}
}
if (aInstigator.IsLocalPlayer()) {                                      
Game_PlayerController(aInstigator.Controller).Player.GUIDesktop.ShowStdWindow(87,2);
}
}
}
aInstigator.mIsInteracting = False;                                         
Super.ClOnEnd(aOwner,aInstigator,aReverse);                                 
}
function ClOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local Actor attachmentActor;
Super.ClOnStart(aOwner,aInstigator,aReverse);                               
aInstigator.mIsInteracting = True;                                          
if (!aReverse) {                                                            
if (aInstigator != None) {                                                
aInstigator.PlayTopLevelAnim(name(AnimationName),speed,0.20000000,True,False);
if (Tool != None) {                                                     
attachmentActor = aInstigator.Spawn(Class'SBAttachment',aInstigator,'None');
attachmentActor.SetDrawType(8);                                       
attachmentActor.SetStaticMesh(Tool);                                  
aInstigator.AttachToBone(attachmentActor,name("Weapon1"));            
mAttachmentName = attachmentActor.Name;                               
}
if (aInstigator.IsLocalPlayer()) {                                      
Game_PlayerController(aInstigator.Controller).Player.GUIDesktop.UpdateStdWindow(87,1,None,"",ProgressSeconds);
Game_PlayerController(aInstigator.Controller).Player.GUIDesktop.ShowStdWindow(87,1);
}
}
}
}
function SvOnCancel(Game_Actor aOwner,Game_Pawn aInstigator) {
local InteractiveLevelElement ile;
Super.SvOnCancel(aOwner,aInstigator);                                       
aInstigator.mIsInteracting = False;                                         
ile = InteractiveLevelElement(aOwner);                                      
if (ile != None) {                                                          
ile.sv_CancelClientSubAction();                                           
}
}
function SvOnEnd(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local InteractiveLevelElement ile;
ile = InteractiveLevelElement(aOwner);                                      
if (ile != None) {                                                          
if (!aReverse) {                                                          
mTimer = 0.00000000;                                                    
mInstigatorPawn = None;                                                 
if (mAborted) {                                                         
ile.sv_CancelOptionActions();                                         
} else {                                                                
ile.sv_EndClientSubAction();                                          
}
}
}
aInstigator.mIsInteracting = False;                                         
Super.SvOnEnd(aOwner,aInstigator,aReverse);                                 
}
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local InteractiveLevelElement ile;
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
aInstigator.mIsInteracting = True;                                          
ile = InteractiveLevelElement(aOwner);                                      
if (ile != None) {                                                          
if (!aReverse) {                                                          
mInstigatorPawn = Game_PlayerPawn(aInstigator);                         
mLocation = mInstigatorPawn.Location;                                   
mHealth = mInstigatorPawn.GetHealth();                                  
mIsShifted = mInstigatorPawn.IsShifted();                               
mActiveSkillsNum = mInstigatorPawn.Skills.GetActiveSkillCount();        
mTimer = ProgressSeconds;                                               
mAborted = False;                                                       
ile.sv_StartClientSubAction();                                          
}
}
}
*/