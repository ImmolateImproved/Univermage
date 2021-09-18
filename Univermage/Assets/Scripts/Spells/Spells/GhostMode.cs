using UnityEngine;
using MEC;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ScriptableObjects/Spells/GhostMode")]
public class GhostMode : Spell
{
    [SerializeField]
    private float duration;

    private int playerLayer, ghostObstacle;

    private CoroutineHandle coroutineHandle;

    private void Awake()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        ghostObstacle = LayerMask.NameToLayer("GhostObstacle");
    }

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
        Physics2D.IgnoreLayerCollision(playerLayer, ghostObstacle, enable);
    }
}