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
using SBGame;
using TCosReborn.Framework.Common;


namespace SBGamePlay
{


    public class InteractiveHatch : InteractiveLevelElement
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="InteractiveHatch")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public Vector DoorMovement;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="InteractiveHatch")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public Rotator DoorRotation;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="InteractiveHatch")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public bool Hide;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="InteractiveHatch")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float OpenSpeed;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="InteractiveHatch")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float PassableTime;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="InteractiveHatch")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public string AnnotationTag = string.Empty;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="InteractiveHatch")]
        public LocalizedString DoorSign;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="InteractiveHatch")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        public Sound DoorSound;
        
        public InteractiveHatch()
        {
        }
    }
}
/*
event string cl_GetToolTip() {
return DoorSign.Text;                                                       
}
*/
