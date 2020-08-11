using System;
using UnityEngine;

public class FlightView : SpellView
{
    [SerializeField]
    private Animator anim;
    private int animationHash;

    public override void Init()
    {
        base.Init();
        animationHash = Animator.StringToHash("Flight");

        actions = new Action[2];
        actions[0] = First;
        actions[1] = Second;
    }

    public override void ResetSpellView()
    {
        base.ResetSpellView();
        Second();
    }

    private void First()
    {
        anim.SetBool(animationHash, true);
    }

    private void Second()
    {
        anim.SetBool(animationHash, false);
    }
}