﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

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
    
    
    [System.Serializable] public class Interaction_Attach : Interaction_Component
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("Interaction_Attach")]
        public string Bone = string.Empty;
        
        [Sirenix.OdinInspector.FoldoutGroup("Interaction_Attach")]
        public Vector Offset;
        
        [Sirenix.OdinInspector.FoldoutGroup("Interaction_Attach")]
        public Rotator Orientation;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public NameProperty AttachmentName;
        
        public Interaction_Attach()
        {
        }
    }
}
/*
function ClOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local Actor attachmentActor;
Super.ClOnStart(aOwner,aInstigator,aReverse);                               
if (aInstigator != None) {                                                  
if (!aReverse) {                                                          
attachmentActor = aInstigator.Spawn(Class'SBAttachment',aInstigator,'None',Offset,Orientation);
attachmentActor.SetDrawType(8);                                         
attachmentActor.SetStaticMesh(Attachment);                              
aInstigator.AttachToBone(attachmentActor,name(Bone));                   
AttachmentName = attachmentActor.Name;                                  
} else {                                                                  
if (AttachmentName != 'None') {                                         
attachmentActor = aInstigator.FindAttachment(AttachmentName,name(Bone));
if (attachmentActor != None) {                                        
aInstigator.DetachFromBone(attachmentActor);                        
attachmentActor.Destroy();                                          
attachmentActor = None;                                             
}
}
}
}
}
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local InteractiveLevelElement ile;
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
ile = InteractiveLevelElement(aOwner);                                      
if (ile != None) {                                                          
ile.sv_StartClientSubAction();                                            
}
}
*/