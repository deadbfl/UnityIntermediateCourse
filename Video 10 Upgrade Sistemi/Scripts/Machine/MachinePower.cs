using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePower : MonoBehaviour
{
    [SerializeField] private float maxValue;
    private float currentPower;

    private void Awake()
    {
        BuyPower();
    }

    public bool DecreasePower(float cost)
    {
        if (currentPower >= cost)
        {
            SetPower(currentPower - cost);
            return true;
        }
        return false;
    }

    public void SetPower(float value)
    {
        currentPower = value;
    }

    public void BuyPower()
    {
        currentPower = maxValue;
    }
}
