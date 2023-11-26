using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    public MachineCanvas machineUpgrade;
    [SerializeField] private GameObject UICanvas;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            DeleteMachine();
        else if (Input.GetKeyDown(KeyCode.W))
            UpgradeMachine();
        else if (Input.GetKeyDown(KeyCode.E))
            BuyPower();
        else if (Input.GetKeyDown(KeyCode.R))
            Rotate();
    }
    public void DeleteMachine()
    {
        machineUpgrade.DeleteMachine();
    }

    public void UpgradeMachine()
    {
        machineUpgrade.UpgradeMachine();
    }

    public void BuyPower()
    {
        machineUpgrade.BuyPower();
    }

    public void Rotate()
    {
        machineUpgrade.Rotate();
    }

    public void OpenCanvas(MachineCanvas canvas)
    {
        UICanvas.SetActive(true);
        machineUpgrade = canvas;
    }
    public void CloseCanvas()
    {
        machineUpgrade = null;
        UICanvas.SetActive(false);
    }
}
