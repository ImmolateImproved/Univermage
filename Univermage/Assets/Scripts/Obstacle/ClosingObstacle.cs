using UnityEngine;

[RequireComponent(typeof(Saveable))]
public class ClosingObstacle : MonoBehaviour, ISaveable
{
    [SerializeField] Collider2D obstacle;
    [SerializeField] SpriteRenderer sr;

    static Color startColor, changedColor;

    void Awake()
    {
        startColor = sr.color;
        changedColor = Color.white;
    }

    void ISaveable.Load(bool state)
    {
        obstacle.enabled = state;
        sr.color = state ? changedColor : startColor;
    }

    SaveablesData ISaveable.Save()
    {
        var data = new SaveablesData { saveable = this, state = obstacle.enabled };
        return data;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            obstacle.enabled = true;
            sr.color = changedColor;
        }
    }
}