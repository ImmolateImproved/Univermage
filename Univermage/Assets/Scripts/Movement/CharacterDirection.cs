using UnityEngine;

public class CharacterDirection : MonoBehaviour
{
    public int DirectionX { get; private set; }

    public Vector2 Direction
    {
        get => new Vector2(DirectionX, 0);
    }

    private void Awake()
    {
        DirectionX = (int)transform.localScale.x;
    }

    public void Flip(int dir)
    {
        var direction = dir == 0 ? 0 : Mathf.Sign(dir);

        if (direction == 0)
            return;

        if (direction != DirectionX)
        {
            Flip();
        }
    }

    private void Flip()
    {
        DirectionX *= -1;

        var scale = transform.localScale;
        scale.x = DirectionX;
        transform.localScale = scale;
    }
}
