using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Transform myTransform;
    private Animator anim;
    private CharacterDirection characterDirection;

    private Vector2 velocity;

    private bool verticalMovement;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float gravityScale;

    private int moveAnimationHash;

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

        characterDirection.Flip(velocity.x);
    }

    public void SetInputDirection(Vector2 inputDirection)
    {
        velocity = verticalMovement
                 ? inputDirection.normalized * moveSpeed
                 : new Vector2(inputDirection.x * moveSpeed, -gravityScale);
    }

    public void SetVerticalMovement(bool verticalMovement)
    {
        this.verticalMovement = verticalMovement;
    }

    public void SetPosition(Vector2 position)
    {
        myTransform.position = position;
        RB.velocity = Vector2.zero;
    }
}