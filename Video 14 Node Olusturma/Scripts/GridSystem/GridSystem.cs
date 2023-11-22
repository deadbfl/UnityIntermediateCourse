using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] private float verticalLength; // X
    [SerializeField] private float horizontalLength; // Y

    [SerializeField] private float nodeEdgeLength;

    [SerializeField] private GameObject testPrefab;

    private Node[,] grid;
    private void Awake()
    {
        CreateGrid();
    }

    public void CreateGrid()
    {
        int x = Mathf.FloorToInt(verticalLength / nodeEdgeLength); // x eksenindeki boyut
        int y = Mathf.FloorToInt(horizontalLength / nodeEdgeLength);// y eksenindeki boyut

        grid = new Node[x, y];

        Vector3 nodePosition = transform.position + new Vector3(-horizontalLength / 2 + nodeEdgeLength / 2, 0, verticalLength / 2 - nodeEdgeLength / 2);

        float xValue = nodePosition.x;

        for (int i = 0; i < x; i++) //x in verisini tutuyor
        {
            for (int j = 0; j < y; j++)//y in verisini tutuyor
            {
                print("X : " + i + " Y : " + j);
                //node olusturmam gereken yer
                Instantiate(testPrefab, nodePosition, Quaternion.identity);

                nodePosition.x += nodeEdgeLength;
                Node tempNode = new Node();

                grid[i, j] = tempNode;
            }
            nodePosition.z -= nodeEdgeLength;
            nodePosition.x = xValue;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(horizontalLength, 1, verticalLength));
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