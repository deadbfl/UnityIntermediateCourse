using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineCanvas : MonoBehaviour
{
    private RawMaterialMachine machine;
    private MachinePower power;

    private void Awake()
    {
        machine = GetComponent<RawMaterialMachine>();
        power = GetComponent<MachinePower>();
    }
    public void DeleteMachine()
    {
        Destroy(gameObject);
    }

    public void UpgradeMachine()
    {
        machine.UpgradeMachine();
    }

    public void BuyPower()
    {
        power.BuyPower();
    }

    public void Rotate()
    {
        transform.Rotate(0, 90, 0);
    }
}
