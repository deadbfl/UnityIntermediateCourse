using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour, ISelectable
{
    [SerializeField] private Item currentCreateItem;

    private void Awake()
    {
        currentCreateItem.SetDictionay();
    }

    public void Select()
    {
        throw new System.NotImplementedException();
    }
    public void DeSelect()
    {
        throw new System.NotImplementedException();
    }
    private void OnTriggerEnter(Collider other)
    {
        IInput otherInput = other.GetComponent<IInput>();
       
        if (otherInput != null)
        {
            currentCreateItem.IncreaseInputCount(otherInput.Type);
        }
    }
}

[Serializable]
public class Item
{
    [SerializeField] private Inputs[] inputs;
    [SerializeField] private Outputs output;

    private Dictionary<Inputs, int> inputsCount = new Dictionary<Inputs, int>();

    public void SetDictionay()
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            inputsCount.Add(inputs[i], 0);
        }
    }

    public void IncreaseInputCount(Inputs inputs)
    {
        if (inputsCount.ContainsKey(inputs))
            inputsCount[inputs]++;

        Debug.Log("Item  : " + inputs + " Sayi :  " + inputsCount[inputs]);
    }
}