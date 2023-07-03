using UnityEngine;
public interface IUnitFabric
{
   IUnit CreateObject(ScriptableUnits settings, Transform spawnPoint, Transform container);
}