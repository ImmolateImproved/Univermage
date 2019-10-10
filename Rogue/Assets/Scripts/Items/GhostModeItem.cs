using UnityEngine;
using MEC;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ScriptableObjcs/Items/GhostModeItem")]
public class GhostModeItem : Item
{
    [SerializeField] float duration;

    GameObject player, ghost;

    int playerLayer, ghostObstacle;

    CoroutineHandle coroutineHandle;

    public override void Init(ItemInitializer itemInitializer)
    {
        player = itemInitializer.player;
        ghost = itemInitializer.ghost;
        playerLayer = LayerMask.NameToLayer("Player");
        ghostObstacle = LayerMask.NameToLayer("GhostObstacle");
    }

    public override void Reset()
    {
        SetGhostMode(false);
    }

    public override void Use()
    {
        Timing.KillCoroutines(coroutineHandle);
        coroutineHandle = Timing.RunCoroutine(Wait());
    }

    IEnumerator<float> Wait()
    {
        SetGhostMode(true);
        yield return Timing.WaitForSeconds(duration);
        SetGhostMode(false);
    }

    public void SetGhostMode(bool enable)
    {
        player.SetActive(!enable);
        ghost.SetActive(enable);

        Physics2D.IgnoreLayerCollision(playerLayer, ghostObstacle, enable);
    }
}
