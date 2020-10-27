using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Transform myTransform;
    private Animator anim;
    private CharacterDirection characterDirection;

    private VerticalMovement verticalMovement;

    private Vector2 velocity;

    [SerializeField]
    private float moveSpeed;

    private int moveAnimationHash;

    public Vector2 GetPosition { get => myTransform.position; }

    public Rigidbody2D RB { get; private set; }

    private void Awake()
    {
        myTransform = transform;
        anim = GetComponentInChildren<Animator>();
        RB = GetComponent<Rigidbody2D>();
        characterDirection = GetComponent<CharacterDirection>();
        verticalMovement = new VerticalMovement();

        moveAnimationHash = Animator.StringToHash("Speed");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            verticalMovement.OnLadder(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            verticalMovement.OnLadder(false);
        }
    }

    private void Move()
    {
        anim.SetFloat(moveAnimationHash, Math.Abs(velocity.x));

        Vector2 newPos = RB.position + velocity * Time.fixedDeltaTime;

        RB.MovePosition(newPos);

        characterDirection.Flip(velocity.x);
    }

    public void SetInputDirection(Vector2 inputDirection)
    {
        var verticalSpeed = verticalMovement.GetVelocity(inputDirection.y) * moveSpeed;

        var groundedDirection = new Vector2(inputDirection.x, 0);

        inputDirection = verticalSpeed > 0 ? inputDirection.normalized : groundedDirection;

        velocity = new Vector2
        {
            x = inputDirection.x * moveSpeed,
            y = verticalSpeed
        };
    }

    public void SetVerticalMovement(bool verticalMovement)
    {
        this.verticalMovement.OnJetPack(verticalMovement);
    }

    public void SetPosition(Vector2 position)
    {
        myTransform.position = position;
        RB.velocity = Vector2.zero;
    }
}