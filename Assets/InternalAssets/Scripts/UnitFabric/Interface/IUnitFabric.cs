using UnityEngine;
public interface IUnitFabric
{
   IUnit CreateObject(ScriptableUnit settings, Transform spawnPoint, Transform container);
}