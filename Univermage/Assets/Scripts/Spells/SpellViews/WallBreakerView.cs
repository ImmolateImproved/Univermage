using System;
using UnityEngine;

public class WallBreakerView : SpellView
{
    [SerializeField]
    private Animator anim;
    private int animationHash;

    public override void Init()
    {
        base.Init();

        animationHash = Animator.StringToHash("Attack2");

        actions = new Action[1];
        actions[0] = First;
    }

    private void First()
    {
        anim.SetTrigger(animationHash);
    }
}