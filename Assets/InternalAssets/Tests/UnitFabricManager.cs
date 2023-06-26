public class UnitFabricManager
{
    private IUnitFabric fabric;

    public void SetIUnitFabric(IUnitFabric fabric)
    {
        this.fabric = fabric;
    }

    public void CreateAndInitializeUnit()
    {
        IUnit unit= fabric.CreateObject();
        unit.Action();
    }
}