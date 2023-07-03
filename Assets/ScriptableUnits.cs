using UnityEngine;
[CreateAssetMenu(fileName = "ArcherUnit", menuName = "Units/Unit")]
public class ScriptableUnits : ScriptableObject
{
    public UnitType unitType;
    public GameObject prefab;
}

