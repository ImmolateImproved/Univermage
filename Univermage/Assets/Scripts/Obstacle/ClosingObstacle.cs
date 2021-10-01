using UnityEngine;

[RequireComponent(typeof(Saveable))]
public class ClosingObstacle : MonoBehaviour, ISaveable
{
    [SerializeField]
    private Collider2D obstacle;

    private SpriteRenderer sr;

    private float opacity;

    private Vector2 positionOnEnter;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        opacity = sr.color.a;
    }

    public void Load(bool state)
    {
        obstacle.isTrigger = state;

        gameObject.layer = state ? PhysicsLayers.ClosingObstacleLayer : PhysicsLayers.Tilemap;

        var color = sr.color;
        color.a = state ? opacity : 1;
        sr.color = color;
    }

    public bool Save()
    {
        return obstacle.isTrigger;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == PhysicsLayers.Player)
        {
            positionOnEnter = collision.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == PhysicsLayers.Player)
        {
            var hit = Physics2D.Linecast(collision.transform.position, positionOnEnter, 1 << gameObject.layer);

            if (hit)
            {
                obstacle.isTrigger = false;
                gameObject.layer = PhysicsLayers.Tilemap;

                var color = sr.color;
                color.a = 1;
                sr.color = color;
            }
        }
    }
}