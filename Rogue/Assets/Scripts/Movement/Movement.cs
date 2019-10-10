using UnityEngine;

public class Movement : MonoBehaviour
{
    Transform myTransform;
    Animator anim;
    Rigidbody2D rb;
    VerticalMovement verticalMovement;
    CharacterDirection characterDirection;

    Vector2 velocity;

    [SerializeField] float speed = 7;

    public Rigidbody2D RB
    {
        get
        {
            return rb;
        }
    }

    void Awake()
    {
        myTransform = transform;
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        characterDirection = GetComponent<CharacterDirection>();
        verticalMovement = GetComponent<VerticalMovement>();
    }

    void FixedUpdate()
    {
        Move();
    }

    public void SetPos(Vector2 pos)
    {
        myTransform.position = pos;
        rb.velocity = Vector2.zero;
    }

    public void SetMoveVector(Vector2 _direction)
    {
        _direction.x = _direction.x == 0 ? 0 : Mathf.Sign(_direction.x);
        _direction.y = _direction.y == 0 ? 0 : Mathf.Sign(_direction.y);

        //_direction.Normalize();

        velocity = new Vector2
        {
            x = _direction.x * speed,
            y = verticalMovement.GetDirection(_direction.y)
        };
    }

    void Move()
    {
        anim.SetFloat("Speed", Mathf.Abs(velocity.x));

        Vector2 newPos = rb.position + velocity * Time.fixedDeltaTime;

        rb.MovePosition(newPos);

        characterDirection.Flip(velocity.x);
    }
}