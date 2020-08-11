using UnityEngine;
using System.Collections.Generic;
using MEC;

[CreateAssetMenu(menuName = "ScriptableObjects/Spells/Portal")]
public class Portal : Spell
{
    private Movement movement;

    [SerializeField]
    private float duration;

    private CoroutineHandle coroutineHandle;

    public override void Init(SpellController controller)
    {
        base.Init(controller);

        movement = controller.GetComponent<Movement>();
    }

    public override void Use()
    {
        coroutineHandle = Timing.RunCoroutine(Wait());
    }

    private IEnumerator<float> Wait()
    {
        var position = movement.GetPosition;
        spellController.OnSpellUse(this, 0);

        yield return Timing.WaitForSeconds(duration);

        spellController.OnSpellUse(this, 1);
        movement.SetPosition(position);
    }
}