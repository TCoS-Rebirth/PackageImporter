﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using SBGame;


namespace SBGamePlay
{


    public class Req_Inventory : Content_Requirement
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Requirement")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public Item_Type Item;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Requirement")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public int Amount;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Requirement")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public byte Operator;
        
        public Req_Inventory()
        {
        }
    }
}
