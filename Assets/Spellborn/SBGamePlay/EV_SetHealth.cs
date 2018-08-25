using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_SetHealth : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public byte HealthMode;

        [FoldoutGroup("Action")]
        [FieldConst()]
        public float HealthValue;

        public EV_SetHealth()
        {
        }

        public enum EHealthMode
        {
            HM_ABSOLUTE,

            HM_RELATIVE,

            HM_ABSOLUTE_PERCENTAGE,

            HM_RELATIVE_PERCENTAGE,
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
switch (HealthMode) {                                                       
case 0 :                                                                  
aSubject.SetHealth(HealthValue);                                        
break;                                                                  
case 1 :                                                                  
aSubject.IncreaseHealth(HealthValue);                                   
break;                                                                  
case 2 :                                                                  
aSubject.SetHealth(HealthValue * aSubject.CharacterStats.mRecord.MaxHealth);
break;                                                                  
case 3 :                                                                  
aSubject.SetHealth(HealthValue * aSubject.GetHealth());                 
break;                                                                  
default:                                                                  
}
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return aSubject != None;                                                    
}
*/