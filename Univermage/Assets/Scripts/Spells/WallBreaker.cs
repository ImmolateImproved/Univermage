using UnityEngine;
using System.Collections.Generic;
using MEC;

[CreateAssetMenu(menuName = "ScriptableObjects/Spells/WallBreaker")]
public class WallBreaker : Spell
{
    private Transform castPoint;

    private CharacterDirection direction;

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private float distance;

    [SerializeField]
    private float delay;

    private CoroutineHandle coroutineHandle;

    public override void Init(SpellController controller)
    {
        base.Init(controller);

        castPoint = controller.castPoint;
        direction = controller.GetComponent<CharacterDirection>();
    }

    public override void Use()
    {
        Timing.RunCoroutine(Wait());
    }

    private IEnumerator<float> Wait()
    {
        spellController.OnSpellUse(this, 0);
        yield return Timing.WaitForSeconds(delay);

        RaycastHit2D hit = Physics2D.Raycast(castPoint.position, direction.CastDirection, distance, mask);

        if (hit)
        {
            hit.transform.GetComponent<DestructableObstacle>().Disable();
        }
    }
}
