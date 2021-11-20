using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField]
    private Transform groundChecker;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private float rayLength;

    [SerializeField]
    private float landedTimeCheck;

    private float timer;

    public bool IsGrounded { get; private set; }

    public bool IsLandedLastFrame { get; private set; }

    private bool isGroundLastTime;

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        IsGrounded = Physics2D.Raycast(groundChecker.position, Vector2.down, rayLength, groundLayer);

        IsLandedLastFrame = false;

        var groundedDif = IsGrounded != isGroundLastTime;

        if (groundedDif)
        {
            if (!IsGrounded)
            {
                timer = landedTimeCheck;
            }
            else if (timer <= 0)
            {
                IsLandedLastFrame = true;
            }

            isGroundLastTime = IsGrounded;
        }

        timer -= Time.deltaTime;
    }
}