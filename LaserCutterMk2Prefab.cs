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
using SMLHelper.V2.Handlers;
using HarmonyLib;

namespace LaserCutterMk2
{
     
    internal class LaserCutterMk2Prefab : Equipable
    {

       public LaserCutterMk2Prefab(string classId, string friendlyName, string description) : base("LaserCutterMk2", "Laser Cutter Mk 2", "Removes built-in safety features, allowing the Laser Cutter to be used on organic targets")


            
        {
            
        }

        public override string AssetsFolder => base.AssetsFolder;

        public override string IconFileName => base.IconFileName;

        public override Vector2int SizeInInventory => base.SizeInInventory;

        public override List<SpawnLocation> CoordinatedSpawns => base.CoordinatedSpawns;

        public override List<LootDistributionData.BiomeData> BiomesToSpawnIn => base.BiomesToSpawnIn;

        public override WorldEntityInfo EntityInfo => base.EntityInfo;

        public override bool HasSprite => base.HasSprite;

        public override TechType RequiredForUnlock => TechType.LaserCutter;

        public override bool AddScannerEntry => base.AddScannerEntry;

        public override int FragmentsToScan => 0;

        public override float TimeToScanFragment => base.TimeToScanFragment;

        public override bool DestroyFragmentOnScan => base.DestroyFragmentOnScan;

        public override PDAEncyclopedia.EntryData EncyclopediaEntryData => base.EncyclopediaEntryData;

        public override TechGroup GroupForPDA => TechGroup.Personal;

        public override TechCategory CategoryForPDA => TechCategory.Tools;

        public override bool UnlockedAtStart => false;

        public override string DiscoverMessage => base.DiscoverMessage;

        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;

        public override float CraftingTime => 5f;

        public override EquipmentType EquipmentType => EquipmentType.Hand;

        

       

        protected override TechData GetBlueprintRecipe()
            {
                return new TechData()
                {
                        craftAmount = 1,
                        Ingredients =
                        {
                        new Ingredient(TechType.LaserCutter, 1),
                        new Ingredient(TechType.WiringKit, 1),
                        }
                };
            }

       



        public override GameObject GetGameObject()
                {
                    GameObject LaserCutterMk2 = CraftData.GetPrefabForTechType(TechType.LaserCutter);
                    var obj = GameObject.Instantiate(LaserCutterMk2);
                    var lcMk2 = obj.AddComponent<LaserCutterMk2>();
                    lcMk2.ikAimRightArm = true;
                    lcMk2.mainCollider = obj.GetComponent<Collider>();
                    GameObject.DestroyImmediate(obj.GetComponent<LaserCutter>());
                    
                    
                    obj.EnsureComponent<EnergyMixin>();
                    
                    return obj;
                }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        protected override void ProcessPrefab(GameObject go)
        {
            base.ProcessPrefab(go);
        }

        
        protected override Atlas.Sprite GetItemSprite()
        {
            return SpriteManager.Get(TechType.LaserCutter);
        }
        public static Atlas.Sprite CustomSprite => SpriteManager.Get(TechType.LaserCutter);

        

        

            
            
    }

    
    
        
    
    
}






  


