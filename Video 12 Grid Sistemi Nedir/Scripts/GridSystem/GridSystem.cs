using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{

    private void Start()
    {
        Node startNode = new Node();
        startNode.SetPosition(transform.position);

        print(startNode.GetPositon());
    }
}

public class Node
{
    private Vector3 position;

    public Vector3 GetPositon()
    {
        return position;
    }
    public void SetPosition(Vector3 position)
    {
        this.position = position;
    }
}