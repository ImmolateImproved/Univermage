using UnityEngine;

[RequireComponent(typeof(Saveable))]
public class SpellScroll : MonoBehaviour, ISaveable
{
    public Spell value;

    void ISaveable.Load(bool state)
    {
        gameObject.SetActive(state);
    }

    SaveablesData ISaveable.Save()
    {
        var data = new SaveablesData { saveable = this, state = gameObject.activeSelf };
        return data;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}