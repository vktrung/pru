using System;
using UnityEngine;

[Serializable]
public class EnemyStats
{
    public int hp = 999;
    public int damage = 1;
    public int exp_reward = 400;
    public float moveSpeed = 1f;

    public EnemyStats(EnemyStats stats)
    {
        this.hp = stats.hp;
        this.damage = stats.damage;
        this.exp_reward = stats.exp_reward;
        this.moveSpeed = stats.moveSpeed;
    }

    internal void ApplyProgress(float progress)
    {
        this.hp = (int)(hp * progress);
        this.damage = (int)(damage * progress);
    }
}


public class Enemy : MonoBehaviour, IDamageable
{
    Transform targetDestination;
    GameObject targetGameObject;
    Character targetCharacter;


    Rigidbody2D rgb2d;

    public EnemyStats stats;
    [SerializeField] EnemyData enemyData;

    float stunned;


    private void Awake()
    {
        rgb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (enemyData != null)
        {
            InitSprite(enemyData.animatedPrefab);
            SetStats(enemyData.stats);
            SetTarget(GameManager.instance.playerTransform.gameObject);
        }
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        if (stunned >= 0)
        {
            rgb2d.velocity = Vector2.zero;
            stunned -= Time.deltaTime;
            return;
        }

        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgb2d.velocity = direction * stats.moveSpeed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Character>())
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }

        targetCharacter.TakeDamage(stats.damage);
    }


    public void TakeDamage(int damage)
    {
        stats.hp -= damage;

        if (stats.hp < 1)
        {
            targetGameObject.GetComponent<Level>().AddExperience(stats.exp_reward);
            GetComponent<DropOnDestroy>().CheckDrop();
            Destroy(gameObject);
        }
    }

    internal void SetStats(EnemyStats stats)
    {
        this.stats = new EnemyStats(stats);
    }

    internal void UpdateStatsForProgress(float progress)
    {
        stats.ApplyProgress(progress);
    }

    internal void InitSprite(GameObject animatedPrefab)
    {
        GameObject spriteObject = Instantiate(animatedPrefab);
        spriteObject.transform.parent = transform;
        spriteObject.transform.localPosition = Vector3.zero;
    }

    public void Stun(float stun)
    {
        stunned = stun;
    }
}
