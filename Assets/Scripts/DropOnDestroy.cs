using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] List<GameObject> dropItemPrefab;
    [SerializeField][Range(0f, 1f)] float chance = 1f;

    bool isQuiting = false;

    private void OnApplicationQuit()
    {
        isQuiting = true;
    }

    public void CheckDrop()
    {
        if (isQuiting) { return; }

        if (dropItemPrefab.Count <= 0)
        {
            Debug.LogWarning("Empty");
            return;
        }

        if (Random.value < chance)
        {
            GameObject toDrop = dropItemPrefab[Random.Range(0, dropItemPrefab.Count)];

            if (toDrop == null)
            {
                Debug.LogWarning("DropOnDestroy, reference to dropped item is null! Check the object which drops items on destroy !");
                return;
            }

            SpawnManager.instance.SpawnObject(transform.position, toDrop);
        }

    }
}
