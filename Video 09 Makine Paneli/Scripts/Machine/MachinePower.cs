using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePower : MonoBehaviour
{
    [SerializeField] private float power;

    public bool DecreasePower(float cost)
    {
        if (power >= cost)
        {
            SetPower(power - cost);
            return true;
        }
        return false;
    }

    public void SetPower(float value)
    {
        power = value;
    }
}
