using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    [SerializeField] private Item currentCreateItem;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private float spawnDelay;

    private void Awake()
    {
        currentCreateItem.SetDictionay();

        StartCoroutine(Spawner());
    }

    private void OnTriggerEnter(Collider other)
    {
        IInput otherInput = other.GetComponent<IInput>();
       
        if (otherInput != null)
        {
            currentCreateItem.IncreaseInputCount(otherInput.Type);
            Destroy(other.gameObject);
        }
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            if(currentCreateItem.CanCreateItem())
            {
                currentCreateItem.DecreaseItemCounts();
                Instantiate(currentCreateItem.prefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}

[Serializable]
public class Item
{
    public GameObject prefab;

    [SerializeField] private Inputs[] inputs;
    public Outputs output;

    private Dictionary<Inputs, int> itemCountDic = new Dictionary<Inputs, int>();

    public void SetDictionay()
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            itemCountDic.Add(inputs[i], 0);
        }
    }

    public void IncreaseInputCount(Inputs inputs)
    {
        if (itemCountDic.ContainsKey(inputs))
            itemCountDic[inputs]++;
    }

    public bool CanCreateItem()
    {
        bool checkCanCreate = true;

        for(int i  = 0; i < inputs.Length; i++)
        {
            int count = itemCountDic[inputs[i]];
            
            checkCanCreate &= count > 0;
        }
        return checkCanCreate;
    }

    public void DecreaseItemCounts()
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            itemCountDic[inputs[i]]--;
        }
    }
}