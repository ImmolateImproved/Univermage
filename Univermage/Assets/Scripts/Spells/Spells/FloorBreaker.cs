using UnityEngine;
using System.Collections.Generic;
using MEC;

[CreateAssetMenu(menuName = "ScriptableObjects/Spells/FloorBreaker")]
public class FloorBreaker : Spell
{
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
    }

    public override void Cast()
    {
        coroutineHandle = Timing.RunCoroutine(Wait(), CoroutineTags.GAMEPLAY);
    }

    private IEnumerator<float> Wait()
    {
        spellController.OnSpellCast(this, 0);

        yield return Timing.WaitForSeconds(delay);

        var hit = Physics2D.Raycast(castPointDown.position, -castPointDown.up, 1, mask);

        if (hit)
        {
            hit.collider.gameObject.SetActive(false);   
        }        
    }
}