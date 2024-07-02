using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    GameObject originalPrefab;
    List<GameObject> pool;

    public void Set(GameObject originalPrefab)
    {
        pool = new List<GameObject>();
        this.originalPrefab = originalPrefab;
    }

    public void InstantiateObject()
    {
        GameObject newObject = Instantiate(originalPrefab, transform);
        pool.Add(newObject);
        PoolMember poolMenber = newObject.AddComponent<PoolMember>();
        poolMenber.Set(this);
    }

    public GameObject GetObject()
    {
        if (pool.Count <= 0)
        {
            InstantiateObject();
        }

        GameObject go = pool[0];
        pool.RemoveAt(0);
        go.SetActive(true);
        return go;
    }

    public void ReturnToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        pool.Add(gameObject);
    }
}
