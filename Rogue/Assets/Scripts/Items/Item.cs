using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField] Sprite sprite;

    public Sprite Sprite
    {
        get { return sprite; }
    }

    public abstract void Init(ItemInitializer itemInitializer);

    public abstract void Use();

    public abstract void Reset();
}