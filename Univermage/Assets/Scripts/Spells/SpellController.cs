using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class SpellController : MonoBehaviour
{
    [SerializeField]
    private Spell[] spells;

    [SerializeField]
    private SpellView[] spellViews;

    private Dictionary<Spell, SpellView> spellToViewMap = new Dictionary<Spell, SpellView>();

    public Transform castPoint, castPointDown, spawnPoint;

    private void Awake()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            spells[i].Init(this);
        }

        for (int i = 0; i < spellViews.Length; i++)
        {
            spellViews[i].Init();

            spellToViewMap.Add(spells[i], spellViews[i]);
        }
    }

    public void OnSpellCast(Spell spell, int actionIndex)
    {
        if (spellToViewMap.TryGetValue(spell, out var spellView))
        {
            spellView.Invoke(actionIndex);
        }
    }

    public Spell GetSpellFromIndex(int index)
    {
        return index == -1 ? null : spells[index];
    }

    public int GetSpellIndex(Spell spell)
    {
        if (spell == null)
            return -1;

        for (int i = 0; i < spells.Length; i++)
        {
            if (spells[i] == spell)
                return i;
        }

        return -1;
    }

    public void ResetSpells()
    {
        MEC.Timing.KillCoroutines(CoroutineTags.GAMEPLAY);

        for (int i = 0; i < spells.Length; i++)
        {
            spells[i].ResetSpell();
        }

        for (int i = 0; i < spellViews.Length; i++)
        {
            spellViews[i].ResetSpellView();
        }
    }
}