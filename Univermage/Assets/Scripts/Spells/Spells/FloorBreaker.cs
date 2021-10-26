using UnityEngine;
using System.Collections.Generic;
using MEC;

[CreateAssetMenu(menuName = "ScriptableObjects/Spells/FloorBreaker")]
public class FloorBreaker : Spell
{
    private Transform spawnPosintDown;
    private Transform castPointDown;

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private float delay;

    private CoroutineHandle coroutineHandle;

    public override void Init(SpellController controller)
    {
        base.Init(controller);

        castPointDown = controller.castPointDown;
        spawnPosintDown = controller.spawnPointDown;
    }

    public override void Cast()
    {
        coroutineHandle = Timing.RunCoroutine(Wait(), CoroutineTags.GAMEPLAY);
    }

    private IEnumerator<float> Wait()
    {
        spellController.OnSpellCast(this, 0);

        yield return Timing.WaitForSeconds(delay);

        spellController.OnSpellCast(this, 1);

        var firstConrner = spawnPosintDown.position;
        var secondCorner = castPointDown.position;

        var hit = Physics2D.OverlapArea(firstConrner, secondCorner, mask);// Physics2D.Raycast(castPointDown.position, -castPointDown.up, 1, mask);

        if (hit)
        {
            hit.gameObject.SetActive(false);
        }
    }
}