using UnityEngine;

public class SpellPicker : MonoBehaviour
{
    private SpellCaster spellCaster;

    private void Awake()
    {
        if (!spellCaster)
            spellCaster = GetComponent<SpellCaster>();
    }

    public void Init(SpellCaster spellCaster)
    {
        this.spellCaster = spellCaster;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        var spellScroll = collision.GetComponent<SpellScroll>();

        if (spellScroll)
        {
            spellCaster.PickUpSpell(spellScroll);
        }
    }
}