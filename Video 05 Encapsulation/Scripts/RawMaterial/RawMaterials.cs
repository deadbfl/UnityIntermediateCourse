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
    private RawMaterialType currentType;
    private GameObject rawMaterialPrefab;// Spawnlatacagim Nesne
    private float cost;

    public void SetValue(RawMaterialVariables values)
    {
        SetRawMaterialType(values.currentType);
        SetRawMaterialPrefab(values.rawMaterialPrefab);
        SetCost(values.cost);
    }

    #region CostEncapsulation
    public float GetCost()
    {
        return cost;
    }

    public void SetCost(float value)
    {
        cost = MathF.Abs(value);
    }
    #endregion

    #region CurrentTypeEncapsuliton
    public RawMaterialType GetRawMaterialType()
    {
        return currentType;
    }

    public void SetRawMaterialType(RawMaterialType value)
    {
        currentType =value;
    }
    #endregion

    #region PrefabEncapulation
    public GameObject GetRawMaterialPrefab()
    {
        return rawMaterialPrefab;
    }
    public void SetRawMaterialPrefab(GameObject value)
    {
        rawMaterialPrefab = value;
    }
    #endregion
}