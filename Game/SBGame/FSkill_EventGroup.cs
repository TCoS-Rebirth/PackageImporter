﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;


namespace SBGame
{


    public class FSkill_EventGroup : Content_Type
    {
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int mhasskillpower_vtbl;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int mhasskillpower_data;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="FSkill_EventGroup")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public List<FSkill_Event> Events = new List<FSkill_Event>();
        
        public FSkill_EventGroup()
        {
        }
    }
}