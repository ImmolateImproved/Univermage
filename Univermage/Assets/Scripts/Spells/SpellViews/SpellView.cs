using System;
using UnityEngine;

public abstract class SpellView : MonoBehaviour
{
    [field: SerializeField]
    public Spell Spell { get; private set; }

    [field: SerializeField]
    public AudioClip SpellSFX { get; private set; }

    public static event Action<AudioClip> OnSpellSFX = delegate { };

    protected Action[] actions;

    public virtual void ResetSpellView()
    {

    }

    public virtual void Init()
    {

    }

    public void Invoke(int actionIndex)
    {
        actions[actionIndex].Invoke();
    }

    protected void PlaySpellSFX()
    {
        OnSpellSFX(SpellSFX);
    }
}