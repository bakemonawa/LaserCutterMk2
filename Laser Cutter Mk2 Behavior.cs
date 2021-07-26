using UnityEngine;
using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

using System.Text;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Utility;
using SMLHelper.V2.Crafting;
using UWE;
using System.Collections;
using SMLHelper.V2.Handlers;
using HarmonyLib;


namespace LaserCutterMk2
{
    using System.Linq;
    using UWE;
    using UnityEngine;
    using Logger = QModManager.Utility.Logger;

    [RequireComponent(typeof(EnergyMixin))]
         

    public class LaserCutterMk2 : LaserCutter
    {

        public override string animToolName => TechType.LaserCutter.AsString(true);

        private LiveMixin activeLiveMixinTarget;

        // raycast to find a live mixin
        private void UpdateLiveTarget()
        {
            activeLiveMixinTarget = null;
            if (usingPlayer != null)
            {
                Vector3 vector = default(Vector3);
                GameObject gameObject = null;

                UWE.Utils.TraceFPSTargetPosition(Player.main.gameObject, 5f, ref gameObject, ref vector, true);
                if (gameObject == null)
                {
                    InteractionVolumeUser interactionVolume = Player.main.gameObject.GetComponent<InteractionVolumeUser>();
                    if (interactionVolume != null && interactionVolume.GetMostRecent() != null)
                    {
                        gameObject = interactionVolume.GetMostRecent().gameObject;
                    }
                }
                if (gameObject)
                {
                    var liveMixin = gameObject.GetComponentInParent<LiveMixin>();
                    if (liveMixin)
                    {
                        activeLiveMixinTarget = liveMixin;
                    }
                }
            }
        }

        private void Update()
        {
            if (!isDrawn)
                return;

            UpdateLiveTarget();
            base.Update();
        }

        public override void OnToolUseAnim(GUIHand hand)

        {
            energyMixin.ConsumeEnergy(1f);

            float LaserDamage = 35f * Time.deltaTime;
            


            if (activeLiveMixinTarget != null)
            {
                activeLiveMixinTarget.TakeDamage(LaserDamage);
                StartLaserCuttingFX();
            }
            else
            {
                LaserCut();
            }




            Logger.Log(Logger.Level.Debug, $"Knife damage was: null," +
             $" is now: 35/s");

        }
    }
            



}








    
    
