public class ArcherFabric:IUnitFabric
{
    public IUnit CreateObject()
    {
        return new Archer();
    }
}
