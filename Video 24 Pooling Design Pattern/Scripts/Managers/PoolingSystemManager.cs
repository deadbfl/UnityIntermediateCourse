using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingSystemManager : MonoBehaviour
{
    public static PoolingSystemManager instance;

    [SerializeField] private PoolItem[] poolItems;

    private Dictionary<string, Queue<GameObject>> poolingObjects = new Dictionary<string, Queue<GameObject>>();
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        FirstCreate();
    }

    private void FirstCreate()
    {
        for (int i = 0; i < poolItems.Length; i++)
        {
            string key = poolItems[i].prefab.name;
            Queue<GameObject> value = new Queue<GameObject>();

            poolingObjects.Add(key, value);

            GameObject prefab = poolItems[i].prefab;
            int size = poolItems[i].size;

            for(int j = 0; j < size; j++)
            {
                GameObject instantiatePrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity, this.transform);

                poolingObjects[key].Enqueue(instantiatePrefab);

                instantiatePrefab.SetActive(false);
            }
        }
    }
}

[Serializable]
public struct PoolItem
{
    public GameObject prefab;
    public int size;
}
