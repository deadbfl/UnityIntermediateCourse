using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObjectManager : MonoBehaviour
{
    public ISelectable currentSelectObject;

    [SerializeField] private Camera cam;

    private Ray ray;
    private RaycastHit hit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(currentSelectObject != null)
                {
                    currentSelectObject.DeSelect();
                }

                currentSelectObject = hit.collider.gameObject.GetComponent<ISelectable>();

                if (currentSelectObject != null)
                {
                    currentSelectObject.Select();
                }
            }
        }
    }
}
