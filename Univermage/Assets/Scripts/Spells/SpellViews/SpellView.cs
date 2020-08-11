using System;
using UnityEngine;

public abstract class SpellView : MonoBehaviour
{
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