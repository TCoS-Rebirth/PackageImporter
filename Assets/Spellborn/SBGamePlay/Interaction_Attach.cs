using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class Interaction_Attach : Interaction_Component
    {
        [FoldoutGroup("Interaction_Attach")]
        public string Bone = string.Empty;

        [FoldoutGroup("Interaction_Attach")]
        public Vector Offset;

        [FoldoutGroup("Interaction_Attach")]
        public Rotator Orientation;

        [NonSerialized, HideInInspector]
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