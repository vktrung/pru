using UnityEngine;

public class GunWeapon : WeaponBase
{
    [SerializeField] GameObject bulletPrefab;
    public override void Attack()
    {
        UpdateVectorOfAttack();

        for (int i = 0; i < weaponStats.numberOfAttack; i++)
        {
            GameObject throwKnife = Instantiate(bulletPrefab);

            Vector3 newKnifePosition = transform.position;



            throwKnife.transform.position = newKnifePosition;

            ThrowingKnifeProjectTile throwingDaggerProjectTile = throwKnife.GetComponent<ThrowingKnifeProjectTile>();

            throwingDaggerProjectTile.SetDirection(vectorOfAttack.x, vectorOfAttack.y);

            throwingDaggerProjectTile.damage = GetDamage();

        }
    }

}
