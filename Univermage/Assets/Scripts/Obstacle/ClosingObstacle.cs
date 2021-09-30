using UnityEngine;

[RequireComponent(typeof(Saveable))]
public class ClosingObstacle : MonoBehaviour, ISaveable
{
    [SerializeField]
    private Collider2D obstacle;

    private SpriteRenderer sr;

    private float opacity;

    private Vector2 positionOnEnter;

    private int closingObstacleLayer;

    private int playerLayer;
    private int tilemapLayer;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        opacity = sr.color.a;
        closingObstacleLayer = 1 << gameObject.layer;

        playerLayer = LayerMask.NameToLayer("Player");
        tilemapLayer = LayerMask.NameToLayer("Tilemap");
    }

    public void Init()
    {
 
    }

    void ISaveable.Load(bool state)
    {
        obstacle.isTrigger = state;

        gameObject.layer = state ? closingObstacleLayer : tilemapLayer;

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
            var hit = Physics2D.Linecast(collision.transform.position, positionOnEnter, closingObstacleLayer);

            if (hit)
            {
                obstacle.isTrigger = false;
                gameObject.layer = tilemapLayer;

                var color = sr.color;
                color.a = 1;
                sr.color = color;
            }
        }
    }
}