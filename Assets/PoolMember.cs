using UnityEngine;

public class PoolMember : MonoBehaviour
{
    ObjectPool pool;

    public void Set(ObjectPool pool)
    {
        this.pool = pool;
        GetComponent<ProjectTile>().poolMember = this;
    }

    public void ReturnToPool()
    {
        pool.ReturnToPool(gameObject);
    }
}
