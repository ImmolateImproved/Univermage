using UnityEngine;

[RequireComponent(typeof(Saveable))]
public class ClosingObstacle : MonoBehaviour, ISaveable
{
    [SerializeField]
    private Collider2D obstacle;

    private SpriteRenderer sr;

    private float opacity;

    private Vector2 positionOnEnter;

    private int myLayer;

    private int playerLayer;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        opacity = sr.color.a;
        myLayer = 1 << gameObject.layer;
        playerLayer = LayerMask.NameToLayer("Player");
    }

    void ISaveable.Load(bool state)
    {
        obstacle.isTrigger = state;

        var color = sr.color;
        color.a = state ? opacity : 1;
        sr.color = color;
    }

    bool ISaveable.Save()
    {
        return obstacle.isTrigger;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            positionOnEnter = collision.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            var hit = Physics2D.Linecast(collision.transform.position, positionOnEnter, myLayer);

            if (hit)
            {
                obstacle.isTrigger = false;

                var color = sr.color;
                color.a = 1;
                sr.color = color;
            }
        }
    }
}