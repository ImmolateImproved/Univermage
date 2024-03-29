﻿using UnityEngine;
using MEC;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ScriptableObjects/Spells/AstralForm")]
public class AstralForm : Spell
{
    [SerializeField]
    private float duration;

    private CoroutineHandle coroutineHandle;

    public override void Init(SpellController controller)
    {
        base.Init(controller);
        SetGhostMode(false);
    }

    public override void ResetSpell()
    {
        SetGhostMode(false);
    }

    public override void Cast()
    {
        OnEffectCastInvoke(SpellIcon, duration);
        Timing.KillCoroutines(coroutineHandle);
        coroutineHandle = Timing.RunCoroutine(Wait(), CoroutineTags.GAMEPLAY);
    }

    private IEnumerator<float> Wait()
    {
        SetGhostMode(true);
        spellController.OnSpellCast(this, 0);

        yield return Timing.WaitForSeconds(duration);

        spellController.OnSpellCast(this, 1);
        SetGhostMode(false);
    }

    private void SetGhostMode(bool enable)
    {
        Physics2D.IgnoreLayerCollision(PhysicsLayers.Player, PhysicsLayers.GhostObstacle, enable);
    }
}