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


    public class QT_Defeat : Quest_Target
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Defeat")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public NPC_Type Target;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Defeat")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float DefeatFraction;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Defeat")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public Conversation_Topic LastWords;
        
        public QT_Defeat()
        {
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
if (aItem.Tag == "T") {                                                     
return Target.GetActiveText(aItem.SubItem);                               
} else {                                                                    
return Super.GetActiveText(aItem);                                        
}
}
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QT_DefeatText.Text;                  
}
*/