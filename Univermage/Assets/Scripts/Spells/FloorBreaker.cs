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
    private float radius, delay;

    private CoroutineHandle coroutineHandle;

    public override void Init(SpellController controller)
    {
        base.Init(controller);

        castPointDown = controller.castPointDown;
    }

    public override void Use()
    {
        coroutineHandle = Timing.RunCoroutine(Wait());
    }

    private IEnumerator<float> Wait()
    {
        spellController.OnSpellUse(this, 0);
        yield return Timing.WaitForSeconds(delay);

        var collider = Physics2D.OverlapCircle(castPointDown.position, radius, mask);

        if (collider)
        {
            collider.GetComponent<DestructableObstacle>().Disable();
        }
    }
}