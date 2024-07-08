using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    [HideInInspector]
    public Vector3 movementVector;

    [HideInInspector]
    public float lastHorizontalDeCoupleVector;
    [HideInInspector]
    public float lastVerticalDeCoupleVector;

    [HideInInspector]
    public float lastHorizontalCoupleVector;
    [HideInInspector]
    public float lastVerticalCoupleVector;

    [SerializeField] float speed = 2f;

    Animate animate;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
        animate = GetComponent<Animate>();
    }


    private void Start()
    {
        lastHorizontalDeCoupleVector = -1f;
        lastVerticalDeCoupleVector = 1f;

        lastHorizontalCoupleVector = -1f;
        lastVerticalCoupleVector = 1f;
    }


    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if (movementVector.x != 0 || movementVector.y != 0)
        {
            lastHorizontalCoupleVector = movementVector.x;
            lastVerticalCoupleVector = movementVector.y;
        }

        if (movementVector.x != 0)
        {
            lastHorizontalDeCoupleVector = movementVector.x;
        }
        else
        {
            lastVerticalDeCoupleVector = movementVector.y;
        }

        animate.horizontal = movementVector.x;


        movementVector *= speed;
        rgbd2d.velocity = movementVector;

    }
}
