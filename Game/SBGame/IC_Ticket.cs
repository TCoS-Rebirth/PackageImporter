﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------



namespace SBGame
{


    public class IC_Ticket : Item_Component
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Ticket")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public byte AccessLevel;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Ticket")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public bool TeleportOnUse;
        
        public IC_Ticket()
        {
        }
        
        public enum EAccessLevel
        {
            
            AL_ArenaPVP ,
            
            AL_ArenaPVE ,
            
            AL_DeadSpellTravel,
        }
    }
}
