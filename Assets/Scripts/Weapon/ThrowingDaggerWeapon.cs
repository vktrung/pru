using UnityEngine;

public class ThrowingDaggerWeapon : WeaponBase
{
    [SerializeField] GameObject knifePreFab;

    PlayerMove playerMove;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }


    public override void Attack()
    {
        GameObject throwKnife = Instantiate(knifePreFab);
        throwKnife.transform.position = transform.position;
        ThrowingDaggerProjectTile throwingDaggerProjectTile = throwKnife.GetComponent<ThrowingDaggerProjectTile>();

        throwingDaggerProjectTile.SetDirection(playerMove.lastHorizontalVector, 0f);

        throwingDaggerProjectTile.damage = weaponStats.damage;
    }
}
