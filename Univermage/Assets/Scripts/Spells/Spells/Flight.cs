using System.Collections.Generic;
using UnityEngine;
using MEC;

[CreateAssetMenu(menuName = "ScriptableObjects/Spells/Flight")]
public class Flight : Spell
{
    private CharacterMovement movement;

    [SerializeField]
    private float duration;

    private CoroutineHandle coroutineHandle;

    public override void Init(SpellController controller)
    {
        base.Init(controller);

        movement = controller.GetComponent<CharacterMovement>();
    }

    public override void ResetSpell()
    {
        movement.VerticalMovement = false;
    }

    public override void Cast()
    {
        OnEffectCastInvoke(SpellIcon, duration);

        Timing.KillCoroutines(coroutineHandle);
        coroutineHandle = Timing.RunCoroutine(Wait(), CoroutineTags.GAMEPLAY);
    }

    private IEnumerator<float> Wait()
    {
        movement.VerticalMovement = true;
        spellController.OnSpellCast(this, 0);

        yield return Timing.WaitForSeconds(duration);

        spellController.OnSpellCast(this, 1);
        movement.VerticalMovement = false;
    }
}