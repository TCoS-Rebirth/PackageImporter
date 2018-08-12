using System;
using Engine;
using SBGame;

namespace SBGamePlay
{
    [Serializable] public class InteractiveMailbox : InteractiveLevelElement
    {
        public LocalizedString MailTooltip;

        public InteractiveMailbox()
        {
        }
    }
}
/*
event string cl_GetToolTip() {
return MailTooltip.Text;                                                    
}
*/