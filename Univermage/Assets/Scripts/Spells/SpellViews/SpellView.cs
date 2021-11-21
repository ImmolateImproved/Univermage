using System;
using UnityEngine;

public abstract class SpellView : MonoBehaviour
{
    [field: SerializeField]
    public Spell Spell { get; private set; }

    [SerializeField]
    protected AudioClip[] spellSFX;

    [SerializeField]
    protected AudioSource audioSource;

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

    protected virtual void PlaySpellSFX(int index = 0)
    {
        if (spellSFX != null && spellSFX.Length > 0 && audioSource != null)
        {
            audioSource.PlayOneShot(spellSFX[index]);
        }
    }
}