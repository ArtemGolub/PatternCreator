public class WarriorFabric:IUnitFabric
{
    public IUnit CreateObject()
    {
        return new Warrior();
    }
}
