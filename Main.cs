using System.Reflection;
using HarmonyLib;
using QModManager.API.ModLoading;
using Logger = QModManager.Utility.Logger;

namespace LaserCutterMk2
{
    [QModCore]
        public static class Main
        {

        
       
        
        [QModPatch]
            public static void Load()
            {

            LaserCutterMk2.Patch();

                Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "com.falselight.subnautica.lasercutterimprovements.mod");
                Logger.Log(Logger.Level.Info, "Patched successfully.");
            }
        }
    }



