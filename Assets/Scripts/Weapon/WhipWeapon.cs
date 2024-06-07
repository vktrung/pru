using UnityEngine;

public class WhipWeapon : WeaponBase
{

    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;

    PlayerMove playerMove;
    [SerializeField] Vector2 attackSize = new Vector2(4f, 2f);

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }


    private void ApplyDamage(Collider2D[] collider)
    {
        for (int i = 0; i < collider.Length; i++)
        {
            IDamageable e = collider[i].GetComponent<IDamageable>();
            if (e != null)
            {
                PostDamage(weaponStats.damage, collider[i].transform.position);
                e.TakeDamage(weaponStats.damage);
            }

        }
    }

    public override void Attack()
    {

        if (playerMove.lastHorizontalVector > 0)
        {
            rightWhipObject.SetActive(true);

            Collider2D[] collider = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, attackSize, 0f);
            ApplyDamage(collider);
        }
        else
        {
            leftWhipObject.SetActive(true);

            Collider2D[] collider = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, attackSize, 0f);
            ApplyDamage(collider);
        }
    }
}
