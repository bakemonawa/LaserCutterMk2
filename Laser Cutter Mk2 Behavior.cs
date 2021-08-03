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

        public override string animToolName => TechType.Welder.AsString(true);

        public object AddressablesUtility { get; private set; }

        

      

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

            float LaserEnergyCost = 1f * Time.deltaTime*2;
            float LaserDamage = 45f * Time.deltaTime;

            energyMixin.ConsumeEnergy(LaserEnergyCost);



            if (activeLiveMixinTarget != null)
            {
                bool wasAlive = activeLiveMixinTarget.IsAlive();
                activeLiveMixinTarget.TakeDamage(LaserDamage, type: DamageType.Heat);
                GiveResourceOnDamage(gameObject, activeLiveMixinTarget.IsAlive(), wasAlive);
                
                                               
            }
            

            else
            {
                LaserCut();
            }




            Logger.Log(Logger.Level.Debug, $"Knife damage was: null," +
             $" is now: 35/s");

        }

        private void GiveResourceOnDamage(GameObject target, bool isAlive, bool wasAlive)
        {
            TechType techType = CraftData.GetTechType(target);
            HarvestType harvestTypeFromTech = CraftData.GetHarvestTypeFromTech(techType);

            if ((harvestTypeFromTech == HarvestType.DamageAlive && wasAlive) || (harvestTypeFromTech == HarvestType.DamageDead && !isAlive))
            {
                int num = 2;
                if (harvestTypeFromTech == HarvestType.DamageAlive && !isAlive)
                {
                    num += CraftData.GetHarvestFinalCutBonus(techType);
                }
                TechType harvestOutputData = CraftData.GetHarvestOutputData(techType);
                if (harvestOutputData != TechType.None)
                {
                    CraftData.AddToInventory(harvestOutputData, num, false, false);
                }
            }
        }


    }


}


    












    
    
