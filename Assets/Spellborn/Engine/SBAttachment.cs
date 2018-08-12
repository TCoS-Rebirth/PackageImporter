using System;

namespace Engine
{
    [Serializable] public class SBAttachment : Actor
    {
        public byte AnimationType;

        public NameProperty AttachmentTag;

        public SBAttachment()
        {
        }

        public enum SBAttachment_AnimType
        {
            SBAttachAnim_None,

            SBAttachAnim_UseOwnerBones,

            SBAttachAnim_HasOwnAnim,

            SBAttachAnim_ClothSim,
        }
    }
}
/*
function PostBeginPlay() {
Super.PostBeginPlay();                                                      
SetupParameters();                                                          
}
function SetupParameters() {
UpdateOffsetTransform();                                                    
}
function SetAnimType(byte newType) {
AnimationType = newType;                                                    
}
native function SetSkin(string skinName);
native function SetMesh(string meshName);
native function Initialize();
native function UpdateOffsetTransform();
native function AttachTo(Actor Actor);
*/