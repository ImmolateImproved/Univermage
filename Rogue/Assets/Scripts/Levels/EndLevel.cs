using UnityEngine;
using UnityEngine.Events;

public class EndLevel : MonoBehaviour
{
    public UnityEvent OnLevelEnd;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnLevelEnd.Invoke();
            LevelManager.NextLevel();
        }
    }
}
