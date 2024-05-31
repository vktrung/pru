using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    GameObject targetGameObject;
    [SerializeField] float speed;

    Rigidbody2D rgb2d;

    private void Awake()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        targetGameObject = targetDestination.gameObject;

    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgb2d.velocity = direction * speed;
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
        Debug.Log("hit");
    }
}
