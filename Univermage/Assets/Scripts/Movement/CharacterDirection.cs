using UnityEngine;

public class CharacterDirection : MonoBehaviour
{
    private Vector2 direction, castDirection;
    public bool FacingRight { get; private set; } = true;

    public Vector2 Direction
    {
        get
        {
            return direction;
        }
    }

    public Vector2 CastDirection
    {
        get
        {
            return castDirection;
        }
    }

    void Awake()
    {
        direction = transform.localScale;

        if (Mathf.Sign(transform.localScale.x) == 1)
        {
            if (!FacingRight)
            {
                FacingRight = !FacingRight;
            }
        }
        else
        {
            if (FacingRight)
            {
                FacingRight = !FacingRight;
            }
        }

        if (FacingRight)
        {
            castDirection = Vector2.right;
        }
        else
        {
            castDirection = Vector2.left;
        }
    }

    public void Flip()
    {
        FacingRight = !FacingRight;

        castDirection.x *= -1;

        direction.x *= -1;
        transform.localScale = Direction;
    }

    public void Flip(float dir)
    {
        if (dir > 0 && !FacingRight || (dir < 0 && FacingRight))
        {
            Flip();
        }
    }
}
