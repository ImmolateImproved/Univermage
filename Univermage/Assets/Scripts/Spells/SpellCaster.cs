using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    [field: SerializeField]
    public Spell CurrentSpell { get; private set; }

    public static event System.Action<Spell> OnSetSpell = delegate { };
    public static event System.Action OnSpellUsed = delegate { };

    private void Start()
    {
        SetSpell(CurrentSpell);
    }

    public void SetSpell(Spell spell)
    {
        OnSetSpell(spell);
        CurrentSpell = spell;
    }

    public void PickUpSpell(SpellScroll spell)
    {
        if (CurrentSpell == null)
        {
            SetSpell(spell.spell);
            spell.Disable();
        }
    }

    public void CastSpell()
    {
        if (CurrentSpell != null)
        {
            OnSpellUsed();
            CurrentSpell.Cast();
            CurrentSpell = null;
        }
    }
}