using System;
using UnityEngine;

public abstract class SpellView : MonoBehaviour
{
    [field: SerializeField]
    public Spell Spell { get; private set; }

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
}