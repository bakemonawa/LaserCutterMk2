using UnityEngine;
using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Utility;
using SMLHelper.V2.Crafting;
using UWE;
using System.Collections;

namespace LaserCutterMk2
{
    internal class LaserCutterMk2Prefab : Equipable
    {
        public LaserCutterMk2Prefab(string classId, string friendlyName, string description) : base("LaserCutterMk2", "Laser Cutter Mk 2", "Removes built-in safety features, allowing the Laser Cutter to be used on organic targets")
        {
        }

        public static Atlas.Sprite CustomSprite => SpriteManager.Get(TechType.LaserCutter);

        public override string AssetsFolder => base.AssetsFolder;

        public override string IconFileName => base.IconFileName;

        public override WorldEntityInfo EntityInfo => base.EntityInfo;

        public override bool HasSprite => true;

        public override TechType RequiredForUnlock => TechType.LaserCutter;

        public override bool AddScannerEntry => false;

        public override PDAEncyclopedia.EntryData EncyclopediaEntryData => base.EncyclopediaEntryData;

        public override TechGroup GroupForPDA => TechGroup.Workbench;

        public override TechCategory CategoryForPDA => TechCategory.Workbench;

        public override bool UnlockedAtStart => false;

        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;

        public override string[] StepsToFabricatorTab => base.StepsToFabricatorTab;

        public override EquipmentType EquipmentType => EquipmentType.Hand;

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 1,
                Ingredients =
                {
                    new Ingredient(TechType.LaserCutter, 1),
                    new Ingredient(TechType.ComputerChip, 1),
                    new Ingredient(TechType.Diamond, 1),
                }
            };
        }

        public override GameObject GetGameObject()
        {
            GameObject LaserCutterMk2 = CraftData.GetPrefabForTechType(TechType.LaserCutter);
            var obj = GameObject.Instantiate(LaserCutterMk2);
            GameObject.DestroyImmediate(obj.GetComponent<LaserCutter>());
            LaserCutterMk2.AddComponent<EnergyMixin>();
            
            return obj;
        }
         
        
        
    }
}
