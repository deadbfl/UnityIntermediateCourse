using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingSystemManager : MonoBehaviour
{
    public static PoolingSystemManager instance;

    [SerializeField] private PoolItem[] poolItems;

    private Dictionary<string, Queue<GameObject>> poolingObjects = new Dictionary<string, Queue<GameObject>>();

    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
    private void Awake()
    {
        instance = this;

        SetPrefabs();
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

            for (int j = 0; j < size; j++)
            {
                Instantiate(key);
            }
        }
    }

    private void SetPrefabs()
    {
        for(int i = 0; i < poolItems.Length;i++)
        {
            string key = poolItems[i].prefab.name;
            GameObject prefab = poolItems[i].prefab;

            prefabs.Add(key, prefab);
        }
    }

    private void Instantiate(string key)
    {
        GameObject prefab = prefabs[key];

        GameObject instantiatePrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity, this.transform);

        poolingObjects[key].Enqueue(instantiatePrefab);

        instantiatePrefab.SetActive(false);
    }

    public GameObject GetGameObject(string key, Vector3 position)
    {
        if (poolingObjects[key].Count <= 5)
        {
            for(int i = 0; i < 10;  i++)
            {
                Instantiate(key);
                print("Sonradan uretildi");
            }
        }

        GameObject poolObject = poolingObjects[key].Dequeue();

        poolObject.SetActive(true);

        poolObject.transform.position = position;

        return poolObject;
    }

    public GameObject GetGameObject(string key, Vector3 position, Quaternion rotation)
    {
        GameObject poolObject = GetGameObject(key, position);

        poolObject.transform.rotation = rotation;

        return poolObject;
    }

    public void SetGameObject(string key, GameObject gameObject)
    {
        poolingObjects[key].Enqueue(gameObject);

        gameObject.SetActive(false);
    }
}

[Serializable]
public struct PoolItem
{
    public GameObject prefab;
    public int size;
}
