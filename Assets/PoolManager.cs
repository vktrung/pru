using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    [SerializeField] GameObject poolPrefab;
    Dictionary<int, ObjectPool> poolList;

    private void Awake()
    {
        poolList = new Dictionary<int, ObjectPool>();
    }

    public void CreatePool(PoolObjectData newPoolData)
    {
        GameObject newObjectPoolGO = Instantiate(poolPrefab, transform).gameObject;
        ObjectPool newObjectPool = newObjectPoolGO.GetComponent<ObjectPool>();
        newObjectPool.Set(newPoolData.originalPrefab);
        newObjectPoolGO.name = "Pool " + newPoolData.name;
        poolList.Add(newPoolData.poolID, newObjectPool);
    }

    public GameObject GetObject(PoolObjectData poolObjectData)
    {
        if (poolList.ContainsKey(poolObjectData.poolID) == false)
        {
            CreatePool(poolObjectData);
        }

        return poolList[poolObjectData.poolID].GetObject();
    }
}
