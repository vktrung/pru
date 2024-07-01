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
            GameObject throwKnife = Instantiate(knifePreFab);

            Vector3 newKnifePosition = transform.position;

            if (weaponStats.numberOfAttack > 1)
            {
                newKnifePosition.y -= (spread * (weaponStats.numberOfAttack - 1)) / 2; //calculating offset
                newKnifePosition.y += i * spread; // spreading the knives along the line
            }


            throwKnife.transform.position = newKnifePosition;

            ThrowingKnifeProjectTile throwingDaggerProjectTile = throwKnife.GetComponent<ThrowingKnifeProjectTile>();

            throwingDaggerProjectTile.SetDirection(vectorOfAttack.x, vectorOfAttack.y);

            throwingDaggerProjectTile.damage = GetDamage();

        }
    }
}
