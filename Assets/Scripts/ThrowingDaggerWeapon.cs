using UnityEngine;

public class ThrowingDaggerWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack;
    float timer;
    [SerializeField] GameObject knifePreFab;

    PlayerMove playerMove;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    private void Update()
    {
        if (timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        SpawnKnife();
    }

    private void SpawnKnife()
    {
        GameObject throwKnife = Instantiate(knifePreFab);
        throwKnife.transform.position = transform.position;
        throwKnife.GetComponent<ThrowingDaggerProjectTile>().SetDirection(playerMove.lastHorizontalVector, 0f);
    }
}
