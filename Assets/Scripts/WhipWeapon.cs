using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    [SerializeField]
    float timeToAttack = 4f;
    float timer;

    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;

    PlayerMove playerMove;

    [SerializeField]
    private Vector2 whipAttackSize = new Vector2(4f, 2f);

    [SerializeField]
    int whipDamage = 1;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }

    }

    private void Attack()
    {
        timer = timeToAttack;

        if (playerMove.lastHorizontalVector > 0)
        {
            rightWhipObject.SetActive(true);

            Collider2D[] collider = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(collider);
        }
        else
        {
            leftWhipObject.SetActive(true);

            Collider2D[] collider = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(collider);
        }
    }

    private void ApplyDamage(Collider2D[] collider)
    {
        for (int i = 0; i < collider.Length; i++)
        {
            Enemy e = collider[i].GetComponent<Enemy>();
            if (e != null)
            {
                collider[i].GetComponent<Enemy>().TakeDamage(whipDamage);
            }

        }
    }
}
