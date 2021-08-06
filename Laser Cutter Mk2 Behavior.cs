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

        private LiveMixin activeLiveMixinTarget;        

        public VFXEventTypes vfxEventType;

        public GameObject laserCutStreak;

        public VFXController fxcontrol;

        public Light fxlight;

        public GameObject laserCutFX;

        public bool colliderhit;

        public float LaserRange = 3.3f;


        private void Update()
        {

            base.Update();                         
            
        }

       

        


        public override void OnToolUseAnim(GUIHand hand)

        {
            
            float LaserEnergyCost = 1f * Time.deltaTime / 2;
            float LaserDamage = 35f * Time.deltaTime;            
                                             
            energyMixin.ConsumeEnergy(LaserEnergyCost);

            fxControl.Play(2);                       
                                                               
            Vector3 vector = default(Vector3);
            GameObject gameObject = null;
            UWE.Utils.TraceFPSTargetPosition(Player.main.gameObject, LaserRange, ref gameObject, ref vector, true);

            float dist = Vector3.Distance(vector, Player.main.transform.position);

            if (dist <= LaserRange)

            {
                StartLaserCuttingFX();
            }

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
                LiveMixin liveMixin = gameObject.FindAncestor<LiveMixin>();
                if (Knife.IsValidTarget(liveMixin))
                {
                    if (liveMixin)
                    {
                        bool wasAlive = liveMixin.IsAlive();
                        liveMixin.TakeDamage(LaserDamage, vector, type: DamageType.Heat, null);
                        GiveResourceOnDamage(gameObject, liveMixin.IsAlive(), wasAlive);
                    }

                    VFXSurface component2 = gameObject.GetComponent<VFXSurface>();
                    Vector3 euler = MainCameraControl.main.transform.eulerAngles + new Vector3(300f, 90f, 0f);
                    VFXSurfaceTypeManager.main.Play(component2, this.vfxEventType, vector, Quaternion.Euler(euler), Player.main.transform);
                }

            }
            else
            {
                LaserCut();
            }               
                       

            ParticleSystem component = this.laserCutFX.transform.GetComponent<ParticleSystem>();
                if (component)
                {
                    var emission = component.emission;
                    emission.enabled = true;

                    if (!component.isPlaying)
                    {
                        component.Play();
                    }
                }

            laserCutStreak.transform.position = vector;
            laserCutFX.transform.position = vector;

            Logger.Log(Logger.Level.Debug, $"Knife damage was: null," +
             $" is now: 35/s");

        }

        void GiveResourceOnDamage(GameObject target, bool isAlive, bool wasAlive)
        {
            TechType techType = CraftData.GetTechType(target);
            HarvestType harvestTypeFromTech = CraftData.GetHarvestTypeFromTech(techType);
            if (techType == TechType.Creepvine)
            {
                GoalManager.main.OnCustomGoalEvent("Cut_Creepvine");
            }
            if ((harvestTypeFromTech == HarvestType.DamageAlive && wasAlive) || (harvestTypeFromTech == HarvestType.DamageDead && !isAlive))
            {
                int num = 1;
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


    












    
    
