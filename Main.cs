using System.Reflection;
using HarmonyLib;
using QModManager.API.ModLoading;
using Logger = QModManager.Utility.Logger;
using System;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Utility;
using SMLHelper.V2.Crafting;
using UWE;
using System.Collections;
using SMLHelper.V2.Handlers;


namespace LaserCutterMk2
{
    [QModCore]
        public static class Main
        {
        
        
        [QModPatch]

        
        public static void Patch()
            {
            
            var lasercuttermk2 = new LaserCutterMk2Prefab("LaserCutterMk2", "Laser Cutter Mk 2", "Removes built-in safety features, allowing the Laser Cutter to be used on organic targets");
            lasercuttermk2.Patch();
            var lasercuttermk2tech = lasercuttermk2.TechType;

            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "LaserCutterMods", "Laser Cutter Upgrades", SpriteManager.Get(TechType.LaserCutter));
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.Workbench, lasercuttermk2tech, "LaserCutterMods", "Laser Cutter Mk2");

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "com.falselight.subnautica.lasercutterimprovements.mod");
                Logger.Log(Logger.Level.Info, "Patched successfully.");
            }
        }
    }



