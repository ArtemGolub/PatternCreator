using UnityEngine;

public class FabricImplementation : MonoBehaviour
{
    private enum FabricType
    {
        Warrior,
        Archer
    }
    
    private UnitFabricManager _fabricManager;
    [Header("Settings")]
    [SerializeField]private FabricType myFabricType;
    [SerializeField]private float firstSpawnDelay = 1f;
    [SerializeField]private float repeatRate = 1f;
    

    
    private void Start()
    {
        InitFactory();
        InvokeRepeating("SpawnUnit", firstSpawnDelay, repeatRate);
    }

    private void SpawnUnit()
    {
        _fabricManager.CreateAndInitializeUnit();
    }

    private void InitFactory()
    {
        _fabricManager = new UnitFabricManager();
        
        switch (myFabricType)
        {
            case FabricType.Warrior:
            {
                IUnitFabric warriorFabric = new WarriorFabric();
                _fabricManager.SetIUnitFabric(warriorFabric);
                break;
            }
            case FabricType.Archer:
            {
                IUnitFabric archerFabric = new ArcherFabric();
                _fabricManager.SetIUnitFabric(archerFabric);
                break;
            }
        }
    }
}
