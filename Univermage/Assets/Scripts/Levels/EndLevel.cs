using UnityEngine;
using UnityEngine.Events;

public class EndLevel : MonoBehaviour, ISaveable
{
    private SpriteRenderer sr;

    [SerializeField]
    private Sprite defaultSprite;
    [SerializeField]
    private Sprite activatedSprite;

    private bool loadNextLevel;

    public void Activate()
    {
        loadNextLevel = true;
        sr.sprite = activatedSprite;
    }

    public void Init()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public bool Save()
    {
        return loadNextLevel;
    }

    public void Load(bool data)
    {
        loadNextLevel = data;

        if (loadNextLevel)
        {
            sr.sprite = activatedSprite;
        }
        else
        {
            sr.sprite = defaultSprite;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!loadNextLevel) return;

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            LevelManager.NextLevel();
        }
    }
}