using System;
using System.Collections.Generic;
using Engine;
using UnityEngine;

namespace SBGame
{
    [Serializable]
    public class Appearance_Set : UObject
    {

        public List<Appearance_Base> ChestClothesSet = new List<Appearance_Base>();

        public List<Appearance_Base> LeftGloveSet = new List<Appearance_Base>();

        public List<Appearance_Base> RightGloveSet = new List<Appearance_Base>();

        public List<Appearance_Base> PantsSet = new List<Appearance_Base>();

        public List<Appearance_Base> ShoesSet = new List<Appearance_Base>();

        public List<Appearance_Base> HeadGearSet = new List<Appearance_Base>();

        public List<Appearance_Base> LeftShoulderSet = new List<Appearance_Base>();

        public List<Appearance_Base> RightShoulderSet = new List<Appearance_Base>();

        public List<Appearance_Base> LeftGauntletSet = new List<Appearance_Base>();

        public List<Appearance_Base> RightGauntletSet = new List<Appearance_Base>();

        public List<Appearance_Base> ChestSet = new List<Appearance_Base>();

        public List<Appearance_Base> BeltSet = new List<Appearance_Base>();

        public List<Appearance_Base> LeftThighSet = new List<Appearance_Base>();

        public List<Appearance_Base> RightThighSet = new List<Appearance_Base>();

        public List<Appearance_Base> LeftShinSet = new List<Appearance_Base>();

        public List<Appearance_Base> RightShinSet = new List<Appearance_Base>();

        public List<Appearance_Base> MainWeaponSet = new List<Appearance_Base>();

        public List<Appearance_Base> OffhandWeaponSet = new List<Appearance_Base>();

        public List<Appearance_Base> MainSheathSet = new List<Appearance_Base>();

        public List<Appearance_Base> OffhandSheathSet = new List<Appearance_Base>();

        public List<Appearance_Base> HairSet = new List<Appearance_Base>();

        public List<Appearance_Tattoo> PCTattooSet = new List<Appearance_Tattoo>();

        public List<Appearance_Tattoo> ClassTattooSet = new List<Appearance_Tattoo>();

        private bool mInitialized;

        static void SheathArray(List<Appearance_Base> orgArray, out List<Appearance_Base> outArray)
        {
            outArray = new List<Appearance_Base>(orgArray.Count);
            var i = 0;
            while (i < orgArray.Count)
            {
                if (orgArray[i] != null)
                {
                    outArray[i] = Instantiate(orgArray[i]);
                    switch (orgArray[i].Part)
                    {
                        case Appearance_Base.AppearancePart.AP_MainWeapon:
                            outArray[i].Part = Appearance_Base.AppearancePart.AP_MainSheath;
                            break;
                        case Appearance_Base.AppearancePart.AP_OffhandWeapon:
                            outArray[i].Part = Appearance_Base.AppearancePart.AP_OffhandSheath;
                            break;
                    }
                    var aI = 0;
                    while (aI < orgArray[i].Attachments.Count)
                    {
                        var attachment = outArray[i].Attachments[aI];
                        switch (orgArray[i].Attachments[aI].SocketId)
                        {
                            case Appearance_Base.AppearanceSocket.AS_RightHandHolster:
                                attachment.SocketId = Appearance_Base.AppearanceSocket.AS_MainShoulderSheath;
                                attachment.Covers = Appearance_Base.CoverageFlag.Covers_Nothing;
                                break;
                            case Appearance_Base.AppearanceSocket.AS_LeftHandHolster:
                                attachment.SocketId = Appearance_Base.AppearanceSocket.AS_OffhandShoulderSheath;
                                attachment.Covers = Appearance_Base.CoverageFlag.Covers_Nothing;
                                break;
                            case Appearance_Base.AppearanceSocket.AS_Shield:
                                attachment.SocketId = Appearance_Base.AppearanceSocket.AS_ShieldSheath;
                                attachment.Covers = Appearance_Base.CoverageFlag.Covers_Nothing;
                                break;
                        }
                        outArray[i].Attachments[aI] = attachment;
                        aI++;
                    }
                    break;
                }
                outArray[i] = null;
                i++;
            }
        }

        static void InitArray(List<Appearance_Base> OutArray)
        {
            var i = 0;
            while (i < OutArray.Count)
            {
                if (OutArray[i] != null)
                {
                    OutArray[i]._AS_Index = i;
                    OutArray[i]._AS_Set = true;
                }
                i++;
            }
        }

        void OnInit()
        {
            if (mInitialized) return;
            mInitialized = true;
            InitArray(ChestClothesSet);
            InitArray(LeftGloveSet);                                                    
            InitArray(RightGloveSet);                                                   
            InitArray(PantsSet);                                                        
            InitArray(ShoesSet);                                                        
            InitArray(HeadGearSet);                                                     
            InitArray(LeftShoulderSet);                                                 
            InitArray(RightShoulderSet);                                                
            InitArray(LeftGauntletSet);                                                 
            InitArray(RightGauntletSet);                                                
            InitArray(ChestSet);                                                        
            InitArray(BeltSet);                                                         
            InitArray(LeftThighSet);                                                    
            InitArray(RightThighSet);                                                   
            InitArray(LeftShinSet);                                                     
            InitArray(RightShinSet);                                                    
            InitArray(MainWeaponSet);                                                   
            InitArray(OffhandWeaponSet);
            if (!Application.isEditor)
            {
                SheathArray(MainWeaponSet, out MainSheathSet);
                SheathArray(OffhandWeaponSet, out OffhandSheathSet);
            }
            InitArray(HairSet);
        }
    }
}
/*
native function UnloadResources();
*/
