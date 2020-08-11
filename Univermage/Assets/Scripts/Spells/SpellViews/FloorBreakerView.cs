using System;
using UnityEngine;

public class FloorBreakerView : SpellView
{
    [SerializeField]
    private Animator anim;
    private int animationHash;

    public override void Init()
    {
        animationHash = Animator.StringToHash("Attack1");

        actions = new Action[1];
        actions[0] = First;
    }

    private void First()
    {
        anim.SetTrigger(animationHash);
    }
}