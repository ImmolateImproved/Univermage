using UnityEngine;

public abstract class Spell : ScriptableObject
{
    protected SpellController spellController;

    public abstract void Use();

    public virtual void Init(SpellController initializer)
    {
        spellController = initializer;
    }

    public virtual void ResetSpell()
    {

    }
}