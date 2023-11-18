using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawMaterialMachine : MonoBehaviour, ISelectable
{
    [SerializeField] private GameObject selectPanel;

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private RawMaterialScriptableObject rawMaterialValue;

    private RawMaterialVariables rawMaterial;
    private MachinePower power;

    private void Awake()
    {
        power = GetComponent<MachinePower>();

        rawMaterial.SetValue(rawMaterialValue.variables);

        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            if (power.DecreasePower(rawMaterial.GetCost()))
            {
                Instantiate(rawMaterial.GetRawMaterialPrefab(), spawnPoint.position, spawnPoint.rotation);
            }
            yield return new WaitForSeconds(rawMaterial.SpawnTimer);
        }
    }

    public void Select()
    {
        selectPanel.SetActive(true);
    }

    public void DeSelect()
    {
        selectPanel.SetActive(false);
    }
}

[Serializable]
public struct RawMaterialVariables
{
    [SerializeField] private RawMaterialType currentType;
    [SerializeField] private GameObject rawMaterialPrefab;// Spawnlatacagim Nesne
    [SerializeField] private float cost;
    [SerializeField] private float spawnTimer;
    public float SpawnTimer { get { return spawnTimer; } set { spawnTimer = value; } }

    public void SetValue(RawMaterialVariables values)
    {
        SetRawMaterialType(values.currentType);
        SetRawMaterialPrefab(values.rawMaterialPrefab);
        SetCost(values.cost);
        SpawnTimer = values.spawnTimer;
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
        currentType = value;
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