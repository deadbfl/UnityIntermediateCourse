using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawMaterials : MonoBehaviour
{
    public RawMaterialVariables variables;
}

[Serializable]
public struct RawMaterialVariables
{
    public RawMaterialType currentType;
    public GameObject rawMaterialPrefab;// Spawnlatacagim Nesne
    public float cost;
}