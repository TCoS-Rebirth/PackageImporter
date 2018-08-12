using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class IC_Appearance : Item_Component
    {
        [FoldoutGroup("IC_Appearance")]
        [FieldConst()]
        public Appearance_Base Appearance;

        [FoldoutGroup("IC_Appearance")]
        [FieldConst()]
        public int DyePrice;

        public IC_Appearance()
        {
        }
    }
}
/*
function ToConsole(Console C) {
C.Message("        Appearance = " $ string(Appearance)
@ string(Appearance.Part)
@ string(Appearance._AS_Index)
@ string(Appearance._AS_Set),0.00000000);
}
function Appearance_Base GetAppearance() {
return Appearance;                                                          
}
*/