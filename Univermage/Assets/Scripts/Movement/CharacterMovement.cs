using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private CharacterDirection characterDirection;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float gravityScale;

    private VerticalMovement verticalMovement = new VerticalMovement();

    public Vector2 Velocity { get; private set; }

    public Vector2 GetPosition { get => rb.position; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        characterDirection = GetComponent<CharacterDirection>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var newPos = rb.position + Velocity * Time.fixedDeltaTime;

        rb.MovePosition(newPos);

        characterDirection.Flip((int)Velocity.x);
    }

    public void SetMoveDirection(Vector2 inputDirection)
    {
        Velocity = verticalMovement
            ? inputDirection.normalized * moveSpeed
            : new Vector2(inputDirection.x * moveSpeed, -gravityScale);
    }

    public void SetPosition(Vector2 position)
    {
        rb.position = position;
        rb.velocity = Vector2.zero;
    }

    public void SetVerticalMovement(object trigger, bool onOf)
    {
        verticalMovement.SetVerticalMovement(trigger, onOf);
    }
}