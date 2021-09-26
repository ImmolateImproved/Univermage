using UnityEngine;

[RequireComponent(typeof(Saveable))]
public class SpellScroll : MonoBehaviour, ISaveable
{
    public Spell value;

    void ISaveable.Load(bool state)
    {
        gameObject.SetActive(state);
    }

    bool ISaveable.Save()
    {
        return gameObject.activeSelf;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}