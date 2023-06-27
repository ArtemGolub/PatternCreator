using UnityEngine;
//TODO move to BabricCreator
public interface IUnitFabric
{
   IUnit CreateObject(ScriptableUnits settings, Transform spawnPoint, Transform container);
}