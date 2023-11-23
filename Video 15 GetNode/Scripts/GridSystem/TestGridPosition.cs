using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGridPosition : MonoBehaviour
{
    [SerializeField] private GridSystem gridSystem;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Node tempNode = gridSystem.GetNodeFromPosition(transform.position);
            print("Transform Position : " + transform.position + " Temp Position : " + tempNode.GetPositon());
        }
    }
}
