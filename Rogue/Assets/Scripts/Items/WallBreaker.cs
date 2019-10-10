using UnityEngine;
using System.Collections.Generic;
using MEC;

[CreateAssetMenu(menuName = "ScriptableObjcs/Items/WallBreaker")]
public class WallBreaker : Item
{
    CharacterDirection direction;

    [SerializeField]
    LayerMask mask;

    GameObject wallBreaker;
    Transform castPoint;

    [SerializeField]
    float distance;

    CoroutineHandle coroutineHandle;

    public override void Init(ItemInitializer itemInitializer)
    {
        direction = itemInitializer.GetComponent<CharacterDirection>();
        castPoint = itemInitializer.castPoint;
        wallBreaker = itemInitializer.wallBreaker;
    }

    public override void Reset()
    {
        wallBreaker.SetActive(false);
    }

    public override void Use()
    {
        RaycastHit2D hit = Physics2D.Raycast(castPoint.position, direction.CastDirection, distance, mask);

        coroutineHandle = Timing.RunCoroutine(Wait());

        if (hit)
        {
            hit.transform.GetComponent<DestructableObstacle>().Disable();
        }
    }

    IEnumerator<float> Wait()
    {
        wallBreaker.SetActive(true);
        yield return Timing.WaitForSeconds(0.3f);
        wallBreaker.SetActive(false);
    }
}
