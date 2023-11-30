using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawMaterialMovement : MonoBehaviour, IInput
{
    [SerializeField] private float speed;
    [SerializeField] private Inputs currentType;
    public Inputs Type { get => currentType; set { currentType = value; } }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
