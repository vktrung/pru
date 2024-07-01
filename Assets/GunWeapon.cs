using UnityEngine;

public class GunWeapon : WeaponBase
{
    [SerializeField] GameObject bulletPrefab;
    public override void Attack()
    {
        UpdateVectorOfAttack();

        for (int i = 0; i < weaponStats.numberOfAttack; i++)
        {

            Vector3 newBulletPosition = transform.position;
            SpawnProjectTile(bulletPrefab, newBulletPosition);
        }

    }

}
