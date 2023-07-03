using UnityEngine;
public class WarriorFabric: MonoBehaviour, IUnitFabric
{
    private int _ID;
    public IUnit CreateObject(ScriptableUnits settings, Transform spawnPoint, Transform container)
    {
        var newObject = Instantiate(settings.prefab, spawnPoint.position, spawnPoint.rotation);
        newObject.name += "ID: " + _ID;
        if (container != null)
        {
            newObject.transform.SetParent(container);
        }
        Warrior objectComponent;
        if (!newObject.transform.GetComponent<Warrior>())
        {
            objectComponent = newObject.AddComponent<Warrior>();
        }
        else
        {
            objectComponent = newObject.transform.GetComponent<Warrior>();
        }
        objectComponent.objectSettings = settings;
        return objectComponent;
    }
}
