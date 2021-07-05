using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Utility;
using UnityEngine;
using HarmonyLib;





namespace MyFirstSubnauticaMod
{
    public static class Main


    {
        public static TechType LaserCutterMk2;


        public static void Patch()
        {
            LaserCutterMk2 = TechTypeHandler.AddTechType("LaserCutterMk2", "Laser Cutter Mk2", "Allows on-the-fly frequency and amplitude alterations that enable the laser to cut through different materials.");

            PrefabHandler.RegisterPrefab(new LaserCutterMk2Prefab("LaserCutterMk2", "WorldEntities/Tools/LaserCutter", LaserCutterMk2));

            CraftDataHandler.SetEquipmentType(LaserCutterMk2, EquipmentType.Hand);
            CraftDataHandler.SetCraftingTime(LaserCutterMk2, 5f);
            CraftDataHandler.SetTechData(LaserCutterMk2, data);
            CraftDataHandler.SetItemSize(LaserCutterMk2, 1, 1);
            var data = new TechData();
            data.Ingredients = new List<Ingredient>()
            {
                new Ingredient(TechType.LaserCutter, 1),
                new Ingredient(TechType.ComputerChip, 1),
                new Ingredient(TechType.Diamond, 1),

             };
            data.craftAmount = 1;

          
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "LaserCutterMods", "Laser Cutter Upgrades", ImageUtils.LoadSpriteFromFile("QMods/LaserCutterImprovements/Assets/lasercutterupgrades.png");
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.Workbench, LaserCutterMk2, "LaserCutterMods", "Laser Cutter Mk2");

        }

    }
}



