using System.Collections;
using UnityEngine;

public class WhipWeapon : WeaponBase
{

    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;

    [SerializeField] Vector2 attackSize = new Vector2(4f, 2f);

    public override void Attack()
    {
        StartCoroutine(AttackProcess());
    }

    IEnumerator AttackProcess()
    {
        for (int i = 0; i < weaponStats.numberOfAttack; i++)
        {
            if (playerMove.lastHorizontalDeCoupleVector > 0)
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

        yield return new WaitForSeconds(0.3f);

    }
}
