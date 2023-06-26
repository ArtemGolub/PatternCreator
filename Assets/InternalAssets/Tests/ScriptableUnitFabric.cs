using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFabricData", menuName = "FabricData")]
public class ScriptableUnitFabric : ScriptableObject
{
    public IUnitFabric fabric;
    public bool isEnabled;
}
