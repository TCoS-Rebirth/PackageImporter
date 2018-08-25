using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fasterflect;
using SBGame;
using SBGamePlay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Database
{
    [CreateAssetMenu]
    public class CharacterCreationItemSets : ScriptableObject 
    {
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_ClothChest> ChestClothesSet = new List<Item_ClothChest>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_ClothLeftGlove> LeftGloveSet = new List<Item_ClothLeftGlove>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_ClothRightGlove> RightGloveSet = new List<Item_ClothRightGlove>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_ClothPants> PantsSet = new List<Item_ClothPants>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_ClothShoes> ShoesSet = new List<Item_ClothShoes>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_ArmorHeadGear> HeadGearSet = new List<Item_ArmorHeadGear>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_ArmorLeftShoulder> LeftShoulderSet = new List<Item_ArmorLeftShoulder>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_ArmorRightShoulder> RightShoulderSet = new List<Item_ArmorRightShoulder>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_ArmorLeftGauntlet> LeftGauntletSet = new List<Item_ArmorLeftGauntlet>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_ArmorRightGauntlet> RightGauntletSet = new List<Item_ArmorRightGauntlet>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_ArmorChest> ChestSet = new List<Item_ArmorChest>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_ArmorBelt> BeltSet = new List<Item_ArmorBelt>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_ArmorLeftThigh> LeftThighSet = new List<Item_ArmorLeftThigh>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_ArmorRightThigh> RightThighSet = new List<Item_ArmorRightThigh>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_ArmorLeftShin> LeftShinSet = new List<Item_ArmorLeftShin>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_ArmorRightShin> RightShinSet = new List<Item_ArmorRightShin>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_Type> MainWeaponSet = new List<Item_Type>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_Type> OffhandWeaponSet = new List<Item_Type>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_Type> MainSheathSet = new List<Item_Type>();
        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<Item_Type> OffhandSheathSet = new List<Item_Type>();

        [InfoBox("(Main scene must be loaded for this to work and packages loaded in GameResources)\nShoulder_Left_001_a may be missing (developer mistake), can be manually fixed by assigning the specific appearance to the corresponding item in its package")]
        [Button()]
        void Load()
        {
            var res = GameResources.Instance;
            var sets = res.FindResource<Appearance_Set>(set => true);
            foreach (var field in GetType().GetFields(BindingFlags.Instance|BindingFlags.Public))
            {
                var list = field.GetValue(this) as IList;
                list.Clear();
                var appList = sets.TryGetFieldValue(field.Name) as List<Appearance_Base>;
                if (appList == null)
                {
                    Debug.LogError("Field not found: " + field.Name);
                    continue;
                }
                for (var i = 0; i < appList.Count; i++)
                {
                    var item = ResolveItem<Item_Type>(appList[i], res);
                    list.Add(item);
                    if (i > 0 && item == null) Debug.LogError(string.Format("Item not found: {0} - {1}", appList[i].name, appList[i].transform.root));
                }
            }
        }

        T ResolveItem<T>(Appearance_Base app, GameResources res) where T: Item_Type
        {
            if (app == null) return null;
            return res.FindResource<T>(type =>
            {
                var ic = type.GetItemComponent<IC_Appearance>();
                return ic != null && ic.Appearance == app;
            });
        }
	
    }
}

