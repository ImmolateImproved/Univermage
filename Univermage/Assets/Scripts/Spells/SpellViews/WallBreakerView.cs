using System;
using UnityEngine;

public class WallBreakerView : SpellView
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Transform effect;

    [SerializeField]
    private Transform spawnPoint;

    private int animationHash;

    public override void Init()
    {
        base.Init();

        animationHash = Animator.StringToHash("Attack2");

        actions = new Action[2];
        actions[0] = First;
        actions[1] = Second;
    }

    private void First()
    {
        anim.SetTrigger(animationHash);
    }

    private void Second()
    {
        var effect = Instantiate(this.effect);
        effect.position = spawnPoint.position;
        effect.parent = transform;
        Destroy(effect.gameObject, 2);
    }
}