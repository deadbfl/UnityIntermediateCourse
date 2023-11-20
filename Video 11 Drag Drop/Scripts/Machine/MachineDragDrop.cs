using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineDragDrop : MonoBehaviour
{
    private RaycastHit hit;

    private float yValue;

    private void Awake()
    {
        yValue = transform.position.y;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPosition = hit.point;

                targetPosition.y = yValue;

                transform.position = targetPosition;
            }
        }
    }
}
