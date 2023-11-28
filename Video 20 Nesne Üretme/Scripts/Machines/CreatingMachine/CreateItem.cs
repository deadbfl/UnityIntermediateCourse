using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour, ISelectable
{
    [SerializeField] private Item currentCreateItem;
    public void Select()
    {
        throw new System.NotImplementedException();
    }
    public void DeSelect()
    {
        throw new System.NotImplementedException();
    }

}

[Serializable]
public struct Item
{
    [SerializeField] private Inputs[] inputs;
    [SerializeField] private Outputs output;
}