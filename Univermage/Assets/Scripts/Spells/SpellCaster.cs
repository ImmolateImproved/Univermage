using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public Spell CurrentSpell { get; private set; }

    public static event System.Action<Spell> OnSetSpell = delegate { };
    public static event System.Action OnSpellUsed = delegate { };

    public void SetSpell(Spell spell)
    {
        CurrentSpell = spell;
        OnSetSpell(CurrentSpell);
    }

    public void PickUpSpell(SpellScroll spell)
    {
        if (!CurrentSpell)
        {
            SetSpell(spell.value);
            spell.Disable();
        }
    }

    public void UseSpell()
    {
        if (CurrentSpell)
        {
            OnSpellUsed();
            CurrentSpell.Use();
            CurrentSpell = null;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (CurrentSpell)
            return;

        var spellScroll = collision.GetComponent<SpellScroll>();

        if (spellScroll)
        {
            PickUpSpell(spellScroll);
        }
    }
}