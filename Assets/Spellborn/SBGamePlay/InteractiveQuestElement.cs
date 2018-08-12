using System;
using SBGame;

namespace SBGamePlay
{
    [Serializable] public class InteractiveQuestElement : InteractiveLevelElement
    {
        public InteractiveQuestElement()
        {
        }
    }
}
/*
event string cl_GetToolTip() {
local export editinline Quest_Target objective;
foreach AllObjects(Class'Quest_Target',objective) {                         
if (objective.IsA('QT_Interactor')) {                                     
if (QT_Interactor(objective).TargetTag == Tag) {                        
return QT_Interactor(objective).TargetDescription.Text;               
}
} else {                                                                  
if (objective.IsA('QT_Place')) {                                        
if (QT_Place(objective).TargetTag == Tag) {                           
return QT_Place(objective).TargetDescription.Text;                  
}
} else {                                                                
if (objective.IsA('QT_Take')) {                                       
if (QT_Take(objective).SourceTag == Tag) {                          
return QT_Take(objective).SourceDescription.Text;                 
}
}
}
}
}
return Super.cl_GetToolTip();                                               
}
*/