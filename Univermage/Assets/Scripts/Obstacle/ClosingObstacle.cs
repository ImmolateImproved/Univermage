using UnityEngine;

[RequireComponent(typeof(Saveable))]
public class ClosingObstacle : MonoBehaviour, ISaveable
{
    [SerializeField]
    private Collider2D obstacle;

    [SerializeField]
    private LineRenderer line;

    [SerializeField]
    private GameObject sprite;

    private Vector2 positionOnEnter;

    private int myLayer;

    private int playerLayer;

    private void Awake()
    {
        myLayer = 1 << gameObject.layer;
        playerLayer = LayerMask.NameToLayer("Player");
    }

    void ISaveable.Load(bool state)
    {
        obstacle.isTrigger = state;

        line.enabled = state;
        sprite.SetActive(!state);
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

                line.enabled = false;
                sprite.SetActive(true);
            }
        }
    }
}