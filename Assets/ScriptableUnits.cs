using UnityEngine;
//TODO move to BabricCreator
[CreateAssetMenu(fileName = "ArcherUnit", menuName = "Units/ArcherUnit")]
public class ScriptableUnits : ScriptableObject
{
    public GameObject prefab;
}

//TODO scriptableForAll units
[CreateAssetMenu(fileName = "ArcherUnit", menuName = "Units/AllUnits")]
public class ScriptableAllUnits : ScriptableObject
{
    public ScriptableUnits archer;
    public ScriptableUnits warrior;
}