using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    [SerializeField] private float raycastDistance;

    private RaycastHit hit;
    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            print("Hit GameObject : " + hit.collider.gameObject.name);
        }
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.red);

    }
}
