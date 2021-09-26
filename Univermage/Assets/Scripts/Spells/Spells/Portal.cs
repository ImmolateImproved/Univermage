using UnityEngine;
using System.Collections.Generic;
using MEC;

[CreateAssetMenu(menuName = "ScriptableObjects/Spells/Portal")]
public class Portal : Spell
{
    private Movement movement;
    private Collider2D collider;

    [SerializeField]
    private float duration;

    [SerializeField]
    private float moveSpeed;

    private CoroutineHandle coroutineHandle;

    public override void Init(SpellController controller)
    {
        base.Init(controller);

        movement = controller.GetComponent<Movement>();
        collider = controller.GetComponent<Collider2D>();
    }

    public override void Cast()
    {
        OnEffectCastInvoke(SpellIcon, duration);
        coroutineHandle = Timing.RunCoroutine(Wait(), CoroutineTags.GAMEPLAY);
    }

    public override void ResetSpell()
    {
        movement.enabled = true;
        collider.enabled = true;
    }

    private IEnumerator<float> Wait()
    {
        var position = movement.GetPosition;
        spellController.OnSpellCast(this, 0);

        yield return Timing.WaitForSeconds(duration);

        Timing.RunCoroutine(MoveBack(position), CoroutineTags.GAMEPLAY);
    }

    private IEnumerator<float> MoveBack(Vector2 startPosition)
    {
        var myTrasform = movement.transform;
        movement.enabled = false;
        collider.enabled = false;

        while (true)
        {
            myTrasform.position = Vector3.MoveTowards(myTrasform.position, startPosition, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(myTrasform.position, startPosition) <= 0.01f)
            {
                spellController.OnSpellCast(this, 1);
                movement.enabled = true;
                collider.enabled = true;
                yield break;
            }

            yield return Timing.WaitForOneFrame;
        }
    }
}