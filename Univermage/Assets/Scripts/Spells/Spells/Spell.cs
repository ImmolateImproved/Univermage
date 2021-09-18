using UnityEngine;

public abstract class Spell : ScriptableObject
{
    [field: SerializeField]
    public Sprite SpellUi { get; private set; }

    protected SpellController spellController;

    public abstract void Cast();

    public virtual void Init(SpellController initializer)
    {
        spellController = initializer;
    }

    public virtual void ResetSpell()
    {

    }
}