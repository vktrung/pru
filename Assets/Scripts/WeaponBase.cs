using UnityEngine;

public enum DirectionOfAttack
{
    None,
    Forward,
    LeftRight,
    UpDown
}

public abstract class WeaponBase : MonoBehaviour
{
    PlayerMove playerMove;

    public WeaponData weaponData;

    public WeaponStats weaponStats;

    float timer;

    Character wielder;
    public Vector2 vectorOfAttack;
    [SerializeField] DirectionOfAttack attackDirection;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    public void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Attack();
            timer = weaponStats.timeToAttack;
        }
    }
    public void ApplyDamage(Collider2D[] collider)
    {
        int damage = GetDamage();
        for (int i = 0; i < collider.Length; i++)
        {
            IDamageable e = collider[i].GetComponent<IDamageable>();
            if (e != null)
            {
                ApplyDamage(collider[i].transform.position, damage, e);
            }

        }
    }

    public void ApplyDamage(Vector3 position, int damage, IDamageable e)
    {
        PostDamage(damage, position);
        e.TakeDamage(damage);
        ApplyAditionalEffects(e);
    }

    private void ApplyAditionalEffects(IDamageable e)
    {
        e.Stun(weaponStats.stun);
    }

    public virtual void SetData(WeaponData wd)
    {
        weaponData = wd;

        weaponStats = new WeaponStats(wd.stats);
    }

    public abstract void Attack();

    public int GetDamage()
    {
        int damage = (int)(weaponData.stats.damage * wielder.damageBonus);

        return damage;
    }


    public virtual void PostDamage(int damage, Vector3 targetPosition)
    {
        MessageSystem.instance.PostMessage(damage.ToString(), targetPosition);
    }

    public void Upgrade(UpGradeData upgradeData)
    {
        weaponStats.Sum(upgradeData.weaponUpgradeStats);
    }

    public void AddOwnerCharacter(Character character)
    {
        wielder = character;
    }


    public void UpdateVectorOfAttack()
    {
        if (attackDirection == DirectionOfAttack.None)
        {
            vectorOfAttack = Vector2.zero;
            return;
        }

        switch (attackDirection)
        {
            case DirectionOfAttack.Forward:
                vectorOfAttack.x = playerMove.lastHorizontalCoupleVector;
                vectorOfAttack.y = playerMove.lastVerticalCoupleVector;
                break;
            case DirectionOfAttack.LeftRight:
                vectorOfAttack.x = playerMove.lastHorizontalDeCoupleVector;
                vectorOfAttack.y = 0f;
                break;
            case DirectionOfAttack.UpDown:
                vectorOfAttack.x = 0f;
                vectorOfAttack.y = playerMove.lastVerticalDeCoupleVector;
                break;
        }
        vectorOfAttack = vectorOfAttack.normalized;
    }

    public GameObject SpawnProjectTile(GameObject projectilePrefab, Vector3 position)
    {
        GameObject projecttileGo = Instantiate(projectilePrefab);
        projecttileGo.transform.position = position;

        ProjectTile projecttile = projecttileGo.GetComponent<ProjectTile>();

        projecttile.SetDirection(vectorOfAttack.x, vectorOfAttack.y);

        projecttile.SetStats(this);

        return projecttileGo;
    }
}
