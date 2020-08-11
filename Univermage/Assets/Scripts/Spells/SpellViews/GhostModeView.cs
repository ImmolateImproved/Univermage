using System;
using UnityEngine;

public class GhostModeView : SpellView
{
    [SerializeField]
    private SpriteRenderer sr;

    private Color32 defaultColor;
    [SerializeField]
    private Color32 ghostColor;

    public override void Init()
    {
        base.Init();

        defaultColor = sr.color;

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
        sr.color = ghostColor;
    }

    private void Second()
    {
        sr.color = defaultColor;
    }
}