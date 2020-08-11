using System.Collections.Generic;
using UnityEngine;
using MEC;

[CreateAssetMenu(menuName = "ScriptableObjects/Spells/Flight")]
public class Flight : Spell
{
    private Movement movement;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float duration;

    private CoroutineHandle coroutineHandle;

    public override void Init(SpellController controller)
    {
        base.Init(controller);

        movement = controller.GetComponent<Movement>();
    }

    public override void ResetSpell()
    {
        movement.SetVerticalMovement(false);
    }

    public override void Use()
    {
        Timing.KillCoroutines(coroutineHandle);
        coroutineHandle = Timing.RunCoroutine(Wait());
    }

    private IEnumerator<float> Wait()
    {
        movement.SetVerticalMovement(true);
        spellController.OnSpellUse(this, 0);

        yield return Timing.WaitForSeconds(duration);

        spellController.OnSpellUse(this, 1);
        movement.SetVerticalMovement(false);
    }
}