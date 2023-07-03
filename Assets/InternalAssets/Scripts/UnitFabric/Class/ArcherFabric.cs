
using UnityEngine;
public class ArcherFabric: MonoBehaviour,IUnitFabric
{
    private int _ID;
    public IUnit CreateObject(ScriptableUnit settings, Transform spawnPoint, Transform container)
    {
        var newObject = Instantiate(settings.prefab, spawnPoint.position, spawnPoint.rotation);
        newObject.name += "ID: " + _ID;
                if (container != null)
                {
                    newObject.transform.SetParent(container);
                }
                Archer objectComponent;
                if (!newObject.transform.GetComponent<Archer>())
                {
                    objectComponent = newObject.AddComponent<Archer>();
                }
                else
                {
                    objectComponent = newObject.transform.GetComponent<Archer>();
                }
                objectComponent.objectSettings = settings;
                return objectComponent;
            }
        }


