using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public Spell CurrentSpell { get; private set; }

    public static event System.Action<Spell> OnSetSpell = delegate { };
    public static event System.Action OnSpellUsed = delegate { };

    public void SetSpell(Spell spell)
    {
        OnSetSpell(spell);
        CurrentSpell = spell;
    }

    public void PickUpSpell(SpellScroll spell)
    {
        if (CurrentSpell == null)
        {
            SetSpell(spell.value);
            spell.Disable();
        }
    }

    public void UseSpell()
    {
        if (CurrentSpell != null)
        {
            OnSpellUsed();
            CurrentSpell.Cast();
            CurrentSpell = null;
        }
    }
}