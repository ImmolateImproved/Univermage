using UnityEngine;
using System.Collections.Generic;
using MEC;

[CreateAssetMenu(menuName = "ScriptableObjcs/Items/FloorBreaker")]
public class FloorBreaker : Item
{
    [SerializeField]
    LayerMask mask;

    Transform spawnPoint;

    IPool<FloorBreakerFX> floorFXPool;

    public FloorBreakerFX itemFX;

    public float radius, delay;

    CoroutineHandle coroutineHandle;

    public override void Init(ItemInitializer itemInitializer)
    {
        floorFXPool = new ListPool<FloorBreakerFX>(() => Instantiate(itemFX), (ob) => !ob.gameObject.activeSelf);
        spawnPoint = itemInitializer.spawnPoint;
    }

    public override void Reset()
    {
        
    }

    public override void Use()
    {
        coroutineHandle = Timing.RunCoroutine(Wait());
    }

    IEnumerator<float> Wait()
    {
        FloorBreakerFX ob = floorFXPool.GetInstance();
        ob.gameObject.SetActive(true);
        ob.transform.position = spawnPoint.position;

        yield return Timing.WaitForSeconds(delay);

        ob.Active();

        Collider2D col = Physics2D.OverlapCircle(ob.transform.position, radius, mask);

        if (col)
        {
            col.GetComponent<DestructableObstacle>().Disable();
        }
    }
}