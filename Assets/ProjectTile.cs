using System.Collections.Generic;
using UnityEngine;

public class ProjectTile : MonoBehaviour, IPoolMember
{
    PoolMember poolMember;
    WeaponBase weapon;

    public float attackArea = 0.7f;
    Vector3 direction;
    float speed;
    int damage = 5;
    int numeOfHits = 1;

    List<IDamageable> enemyHit;

    float ttl = 6f;

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y);

        if (dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }

    private void Update()
    {
        Move();

        if (Time.frameCount % 6 == 0)
        {
            HitDetection();
        }

        TimerToLive();

    }

    private void TimerToLive()
    {
        ttl -= Time.deltaTime;
        if (ttl < 0f)
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        if (poolMember == null)
        {
            Destroy(gameObject);
        }
        else
        {
            poolMember.ReturnToPool();
        }
    }

    private void HitDetection()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, attackArea);
        foreach (Collider2D c in hit)
        {
            if (numeOfHits > 0)
            {
                IDamageable enemy = c.GetComponent<IDamageable>();

                if (enemy != null)
                {
                    if (CheckRepeatHit(enemy) == false)
                    {
                        weapon.ApplyDamage(c.transform.position, damage, enemy);
                        enemyHit.Add(enemy);
                        numeOfHits -= 1;
                    }
                }
            }
        }
        if (numeOfHits <= 0)
        {
            DestroyProjectile();
        }
    }

    private bool CheckRepeatHit(IDamageable enemy)
    {
        if (enemyHit == null) { enemyHit = new List<IDamageable>(); }

        return enemyHit.Contains(enemy);
    }

    private void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void PostDame(int damage, Vector3 worldPosition)
    {
        MessageSystem.instance.PostMessage(damage.ToString(), worldPosition);
    }

    public void SetStats(WeaponBase weaponBase)
    {
        weapon = weaponBase;
        damage = weaponBase.GetDamage();
        numeOfHits = weaponBase.weaponStats.numberOfHits;
        speed = weaponBase.weaponStats.projectileSpeed;
    }

    private void OnEnable()
    {
        ttl = 6f;
    }

    public void SetPoolMember(PoolMember poolMember)
    {
        this.poolMember = poolMember;
    }
}
