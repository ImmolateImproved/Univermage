using UnityEngine;
using System.Collections.Generic;
using MEC;
using DG.Tweening;

[CreateAssetMenu(menuName = "ScriptableObjects/Spells/Portal")]
public class Portal : Spell
{
    private CharacterMovement movement;
    private Collider2D collider;

    [SerializeField]
    private Ease movementEase;

    [SerializeField]
    private float duration;

    [SerializeField]
    private float returnSpeed;

    [SerializeField]
    private float castDelay;

    private CoroutineHandle coroutineHandle;

    public override void Init(SpellController controller)
    {
        base.Init(controller);

        movement = controller.GetComponent<CharacterMovement>();
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

    protected virtual Vector2 GetPositon()
    {
        return movement.GetPosition;
    }

    private IEnumerator<float> CastDelay()
    {
        yield return Timing.WaitForSeconds(castDelay);
    }

    private IEnumerator<float> Wait()
    {
        spellController.OnSpellCast(this, 0);

        yield return Timing.WaitUntilDone(Timing.RunCoroutine(CastDelay(), CoroutineTags.GAMEPLAY));

        var returnPosition = GetPositon();

        yield return Timing.WaitForSeconds(duration);

        var myTrasform = movement.transform;
        movement.enabled = false;
        collider.enabled = false;

        var distance = Vector2.Distance(myTrasform.position, returnPosition);

        myTrasform.DOMove(returnPosition, distance / returnSpeed).SetEase(movementEase).OnComplete(() =>
        {
            spellController.OnSpellCast(this, 1);
            movement.enabled = true;
            collider.enabled = true;
        });
    }
}