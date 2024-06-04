using System.Collections.Generic;
using UnityEngine;

public class TerrainTile : MonoBehaviour
{

    [SerializeField]
    Vector2Int tilePosition;
    [SerializeField] List<SpawnObject> spawnObject;

    void Start()
    {
        GetComponentInParent<WordScolling>().Add(gameObject, tilePosition);

        transform.position = new Vector3(-100, -100, 0);
    }

    public void Spawn()
    {
        for (int i = 0; i < spawnObject.Count; i++)
        {
            spawnObject[i].Spawn();
        }
    }


}