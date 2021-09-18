using UnityEngine;
using UnityEngine.Events;

public class EndLevel : MonoBehaviour
{
    public UnityEvent OnLevelEnd;

    private bool loadNextLevel;

    public void Activate()
    {
        loadNextLevel = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!loadNextLevel) return;

        if (collision.CompareTag("Player"))
        {
            OnLevelEnd.Invoke();
            LevelManager.NextLevel();
        }
    }
}
