using UnityEngine;




namespace MyFirstSubnauticaMod
{
    public class LaserCutterMk2Prefab
    {
        public LaserCutterMk2Prefab(string classId, string prefabFileName, TechType techType = TechType.LaserCutter) : base(classId, prefabFileName, techType)
        {
        }

        GameObject LaserCutterMk2Prefab.GetGameObject()
        {
            GameObject LaserCutterMk2 = Resources.Load<GameObject>("WorldEntities/Tools/LaserCutter");
            
            LaserCutterMk2.AddComponent<EnergyMixin>();
            
        }
    }
}
