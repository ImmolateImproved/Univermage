using UnityEngine;

public class DeathObstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var livingEntity = collision.GetComponent<LivingEntity>();

        if (livingEntity)
        {
            livingEntity.Death();
        }
    }
}