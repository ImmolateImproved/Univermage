using System.Collections.Generic;
using UnityEngine;
using MEC;

[CreateAssetMenu(menuName = "ScriptableObjcs/Items/Jetpack")]
public class Jetpack : Item
{
    GameObject jetPack;
    [SerializeField] float speed;
    [SerializeField] float duration;

    public static event System.Action<bool> OnJetpack = delegate { };

    CoroutineHandle coroutineHandle;

    public override void Init(ItemInitializer itemInitializer)
    {
        jetPack = itemInitializer.jetpack;
    }

    public override void Reset()
    {
        OnJetpack(false);
        jetPack.SetActive(false);
    }

    public override void Use()
    {
        Timing.KillCoroutines(coroutineHandle);
        coroutineHandle = Timing.RunCoroutine(Wait());
    }

    IEnumerator<float> Wait()
    {
        jetPack.SetActive(true);
        OnJetpack(true);
        yield return Timing.WaitForSeconds(duration);
        OnJetpack(false);
        jetPack.SetActive(false);
    }
}
