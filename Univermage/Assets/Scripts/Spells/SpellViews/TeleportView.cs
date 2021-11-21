using DG.Tweening;
using UnityEngine;

public class TeleportView : PortalView
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    [Range(0, 1)]
    private float moveDuration;

    [SerializeField]
    private Ease movementEase;

    private int animationHash;

    private void TeleportView_OnCast(Vector2 teleportPoint)
    {
        teleportPoint.y = transform.position.y;
        lastPortal.transform.DOMove(teleportPoint, moveDuration).SetEase(movementEase);
    }

    public override void Init()
    {
        base.Init();
        animationHash = Animator.StringToHash("Attack2");
    }

    protected override void First()
    {
        base.First();
        anim.SetTrigger(animationHash);
        PlaySpellSFX(0);
    }

    protected override void PlaySecondSFX()
    {
        PlaySpellSFX(1);
    }

    private void OnEnable()
    {
        ((Teleport)Spell).OnCast += TeleportView_OnCast;
    }

    private void OnDisable()
    {
        ((Teleport)Spell).OnCast -= TeleportView_OnCast;
    }
}