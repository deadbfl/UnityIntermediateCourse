using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineDragDrop : MonoBehaviour
{
    private RaycastHit hit;

    private float yValue;

    private Vector3 startPosition;

    private bool firstFrame = true;

    private void Awake()
    {
        yValue = transform.position.y;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(firstFrame)
            {
                startPosition = transform.position;
                firstFrame = false;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPosition = hit.point;

                targetPosition.y = yValue;

                transform.position = targetPosition;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Node tempNode = GridSystem.instance.GetNodeFromPosition(transform.position);

            if (tempNode.IsEmpty())
            {
                transform.position = tempNode.GetPositon();
                tempNode.SetEmpty(false);
            }
            else
            {
                transform.position = startPosition;
            }
            firstFrame = true;
        }
    }
}
