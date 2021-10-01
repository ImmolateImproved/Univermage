using UnityEngine;

[RequireComponent(typeof(Saveable))]
public class SpellScroll : MonoBehaviour, ISaveable
{
    public Spell spell;

    public void Load(bool state)
    {
        gameObject.SetActive(state);
    }

    public bool Save()
    {
        return gameObject.activeSelf;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}