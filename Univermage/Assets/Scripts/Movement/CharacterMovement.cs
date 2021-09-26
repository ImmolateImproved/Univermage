using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Transform myTransform;
    private Animator anim;
    private CharacterDirection characterDirection;

    private Vector2 velocity;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float gravityScale;

    private int moveAnimationHash;

    public bool VerticalMovement { get; set; }

    public Vector2 GetPosition { get => myTransform.position; }

    public Rigidbody2D RB { get; private set; }

    private void Awake()
    {
        myTransform = transform;
        anim = GetComponentInChildren<Animator>();
        RB = GetComponent<Rigidbody2D>();
        characterDirection = GetComponent<CharacterDirection>();

        moveAnimationHash = Animator.StringToHash("Speed");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        anim.SetFloat(moveAnimationHash, Math.Abs(velocity.x));

        Vector2 newPos = RB.position + velocity * Time.fixedDeltaTime;

        RB.MovePosition(newPos);

        characterDirection.Flip((int)velocity.x);
    }

    public void SetMoveDirection(Vector2 inputDirection)
    {
        velocity = VerticalMovement
            ? inputDirection.normalized * moveSpeed
            : new Vector2(inputDirection.x * moveSpeed, -gravityScale);
    }

    public void SetPosition(Vector2 position)
    {
        myTransform.position = position;
        RB.velocity = Vector2.zero;
    }
}