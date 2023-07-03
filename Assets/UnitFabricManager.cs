using UnityEngine;
public class UnitFabricManager
{
    private IUnitFabric fabric;

    public void SetIUnitFabric(IUnitFabric fabric)
    {
        this.fabric = fabric;
    }

    public void CreateAndInitializeUnit(ScriptableUnits settings, Transform spawnPoint, Transform container)
    {
        IUnit unit = fabric.CreateObject(settings, spawnPoint, container);
        unit.Init();
    }
}