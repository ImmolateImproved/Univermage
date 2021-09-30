using System;
using UnityEngine;
using UnityEngine.Video;

public abstract class Spell : ScriptableObject
{
    [field: SerializeField]
    public Sprite SpellIcon { get; private set; }

    public string spellName;

    [Multiline]
    public string description;

    public VideoClip videoClip;

    protected SpellController spellController;

    public static event Action<Sprite, float> OnEffectCast = delegate { };

    public abstract void Cast();

    public virtual void Init(SpellController spellController)
    {
        this.spellController = spellController;
    }

    public virtual void ResetSpell()
    {

    }

    protected void OnEffectCastInvoke(Sprite effectIcon, float effectDuration)
    {
        OnEffectCast(effectIcon, effectDuration);
    }
}