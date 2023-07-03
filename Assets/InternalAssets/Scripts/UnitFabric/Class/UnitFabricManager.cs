using UnityEngine;
public class UnitFabricManager
{
    private IUnitFabric fabric;

    public void SetUnitFabric(IUnitFabric fabric)
    {
        this.fabric = fabric;
    }

    public void CreateAndInitializeUnit(ScriptableUnit settings, Transform spawnPoint, Transform container)
    {
        IUnit unit= fabric.CreateObject(settings, spawnPoint, container);
        unit.Init();
    }
}