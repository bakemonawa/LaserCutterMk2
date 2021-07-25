using UnityEngine;
using HarmonyLib;
using System.Linq;
using UWE;

using Logger = QModManager.Utility.Logger;

namespace LaserCutterMk2
{
         [RequireComponent(typeof(EnergyMixin))]
         

    public class LaserCutterMk2 : LaserCutter
    {

        public override string animToolName => TechType.LaserCutter.AsString(true);

        public override void OnToolUseAnim(GUIHand hand)

        {
            float LaserDamage = 35f * Time.deltaTime;

            energyMixin.ConsumeEnergy(1f);

            LiveMixin mixin = GetComponentInChildren<LiveMixin>();

            if (mixin)


            {
                mixin.IsAlive();
                mixin.TakeDamage(LaserDamage, type: DamageType.Heat);
                base.StartLaserCuttingFX();
            }

            else

            {
                base.LaserCut();
            }


            Logger.Log(Logger.Level.Debug, $"Knife damage was: null," +
             $" is now: 35/s");

        }
    }
            



}








    
    
