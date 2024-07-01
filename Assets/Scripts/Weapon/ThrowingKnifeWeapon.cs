using UnityEngine;

public class ThrowingKnifeWeapon : WeaponBase
{
    [SerializeField] GameObject knifePreFab;
    [SerializeField] float spread = 0.5f;



    public override void Attack()
    {
        UpdateVectorOfAttack();

        for (int i = 0; i < weaponStats.numberOfAttack; i++)
        {

            Vector3 newKnifePosition = transform.position;

            if (weaponStats.numberOfAttack > 1)
            {
                newKnifePosition.y -= (spread * (weaponStats.numberOfAttack - 1)) / 2; //calculating offset
                newKnifePosition.y += i * spread; // spreading the knives along the line
            }

            SpawnProjectTile(knifePreFab, newKnifePosition);
        }
    }
}
