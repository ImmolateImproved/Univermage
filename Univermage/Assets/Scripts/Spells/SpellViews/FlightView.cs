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

    protected override void PlaySpellSFX(int index = 0)
    {
        if (audioSource)
            audioSource.Play();
    }

    private void First()
    {
        PlaySpellSFX();
        anim.SetBool(animationHash, true);
    }

    private void Second()
    {
        if (audioSource)
            audioSource.Stop();

        anim.SetBool(animationHash, false);
    }
}