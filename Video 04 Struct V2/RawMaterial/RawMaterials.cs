using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawMaterials : MonoBehaviour
{
}

[Serializable]
public struct RawMaterialVariables
{
    public RawMaterialType currentType;
    public GameObject rawMaterialPrefab;// Spawnlatacagim Nesne
    public float cost;

    public void SetValue(RawMaterialVariables values)
    {
        currentType = values.currentType;
        rawMaterialPrefab = values.rawMaterialPrefab;
        cost = values.cost;
    }
}