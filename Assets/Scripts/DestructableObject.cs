using UnityEngine;

public class DestructableObject : MonoBehaviour, IDamageable
{
    public void Stun(float stun)
    {

    }

    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
        GetComponent<DropOnDestroy>().CheckDrop();

    }


}
