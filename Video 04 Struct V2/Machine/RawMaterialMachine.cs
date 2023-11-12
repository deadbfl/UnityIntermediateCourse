using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawMaterialMachine : MonoBehaviour
{
    [SerializeField] private RawMaterialScriptableObject rawMaterialValue;

    private RawMaterialVariables rawMaterial;

    private void Awake()
    {
        rawMaterial.SetValue(rawMaterialValue.variables);
    }

}
