using UnityEngine;
using System.Collections.Generic;
using MEC;

[CreateAssetMenu(menuName = "ScriptableObjcs/Items/Portal")]
public class Portal : Item
{
    Movement movement;

    IPool<GameObject> portalPool;

    Transform spawnPoint;

    [SerializeField] GameObject portalPrefab;

    [SerializeField]
    float duration;

    CoroutineHandle coroutineHandle;

    public override void Init(ItemInitializer itemInitializer)
    {
        portalPool = new ListPool<GameObject>(() => Instantiate(portalPrefab), (ob) => !ob.activeSelf);
        movement = itemInitializer.GetComponent<Movement>();
        spawnPoint = itemInitializer.spawnPoint;
    }

    public override void Reset()
    {
        portalPool.Reset(x => x.SetActive(false));
    }

    public override void Use()
    {
        coroutineHandle = Timing.RunCoroutine(Wait());
    }

    IEnumerator<float> Wait()
    {
        GameObject ob = portalPool.GetInstance();
        ob.SetActive(true);
        ob.GetComponent<Timer>().StartTimer(duration);
        ob.transform.position = spawnPoint.position;

        var pos = movement.transform.position;

        yield return Timing.WaitForSeconds(duration);

        movement.SetPos(pos);
        ob.SetActive(false);
    }
}