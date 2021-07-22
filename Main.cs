using System.Reflection;
using HarmonyLib;
using QModManager.API.ModLoading;
using Logger = QModManager.Utility.Logger;
using System;

namespace LaserCutterMk2
{
    [QModCore]
        public static class Main
        {
                   
        
        [QModPatch]
            public static void Load()
            {

            var lasercuttermk2 = new LaserCutterMk2Prefab("LaserCutterMk2", "Laser Cutter Mk 2", "Removes built-in safety features, allowing the Laser Cutter to be used on organic targets");
            lasercuttermk2.Patch();


                Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "com.falselight.subnautica.lasercutterimprovements.mod");
                Logger.Log(Logger.Level.Info, "Patched successfully.");
            }
        }
    }



