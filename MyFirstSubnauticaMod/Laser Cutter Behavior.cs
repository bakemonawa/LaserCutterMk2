using UnityEngine;
using HarmonyLib;
using Logger = QModManager.Utility.Logger;

namespace MyFirstSubnauticaMod
{
    [RequireComponent(typeof(EnergyMixin))]
    [HarmonyPatch(typeof(LaserCutter))]
    [HarmonyPatch("Start")]

    

    public class LaserCutterMK2 : LaserCutter
    {
        void Update()

        {
            base.Update();
            // do ur own object tracking here


            if (GameInput.GetButtonHeld(GameInput.Button.RightHand);

            {
                energyMixin.ConsumeEnergy(1f);
                
            }

            {

                var entityRoot = Utils.GetEntityRoot(go) ?? go;

                float LaserDamage = 40;

                entityRoot?.GetComponentInChildren<LiveMixin>()?.TakeDamage(LaserDamage, DamageType.Heat);
                Logger.Log(Logger.Level.Debug, $"Laser damage was: null," +
                $" is now: {LaserDamage}");

            }

                          

        }






    }

}



    
    
