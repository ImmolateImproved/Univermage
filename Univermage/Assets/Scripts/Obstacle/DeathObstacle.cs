using UnityEngine;

public class DeathObstacle : MonoBehaviour
{
    private static int playerLayer;

    private void Awake()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            LevelManager.Restart();
        }
    }
}