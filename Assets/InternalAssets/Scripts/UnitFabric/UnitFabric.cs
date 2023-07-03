

using UnityEngine;
public class UnitFabric : MonoBehaviour
{
    private UnitFabricManager _fabricManager;
    private Transform container;
   
    [Header("Settings")] 
    [SerializeField] private UnitType myFabricType;
    [SerializeField] private float firstSpawnDelay = 1f;
    [SerializeField] private float repeatRate = 1f;
    [SerializeField] private ScriptableUnit settings;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool isNeedContainer;
    private void Start()
    {
        CreateContainer();
        InitFactory();
        InvokeRepeating("SpawnUnit", firstSpawnDelay, repeatRate);
    }
    private void SpawnUnit()
    {
        _fabricManager.CreateAndInitializeUnit(settings, spawnPoint, container);
    }
    private void InitFactory()
    {
        _fabricManager = new UnitFabricManager();
switch (myFabricType)
        {
case UnitType.Warrior:
{
IUnitFabric warriorFabric = new WarriorFabric(); 
_fabricManager.SetUnitFabric(warriorFabric); 
    break;
}
case UnitType.Archer:
{
IUnitFabric archerFabric = new ArcherFabric(); 
_fabricManager.SetUnitFabric(archerFabric); 
    break;
}
}
        
    }
    private void CreateContainer()
    {
        if(!isNeedContainer) return;
        var containerObject = new GameObject();
        container = containerObject.transform;
        container.name = myFabricType.ToString() + "Container";
        container.SetParent(this.transform);
    }
}
