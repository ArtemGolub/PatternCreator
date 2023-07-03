
using UnityEngine;
[CreateAssetMenu(fileName = "Unit", menuName = "ScriptableObjects/ + Units /newUnit")]
    public class ScriptableUnit: ScriptableObject
    {
        public UnitType unitType;
        public GameObject prefab;
    }

