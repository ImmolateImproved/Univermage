using System;
using UnityEngine;
using UnityEngine.Video;

public abstract class Spell : ScriptableObject
{
    [field: SerializeField]
    public Sprite SpellIcon { get; private set; }

    public VideoClip videoClip;

    public string description;

    protected SpellController spellController;

    public static event Action<Sprite, float> OnEffectCast = delegate { };

    public abstract void Cast();

    public virtual void Init(SpellController initializer)
    {
        spellController = initializer;
    }

    public virtual void ResetSpell()
    {

    }

    protected void OnEffectCastInvoke(Sprite effectIcon, float effectDuration)
    {
        OnEffectCast(effectIcon, effectDuration);
    }
}