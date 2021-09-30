using System;
using UnityEngine;

public class FloorBreakerView : SpellView
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Transform explosionPrefab;

    [SerializeField]
    private Transform spawnPoint;

    private int animationHash;

    public override void Init()
    {
        base.Init();

        animationHash = Animator.StringToHash("Attack1");

        actions = new Action[2];
        actions[0] = First;
        actions[1] = Second;
    }

    private void First()
    {
        anim.SetTrigger(animationHash);
    }

    private void Second()
    {
        var explosion = Instantiate(explosionPrefab);
        explosion.position = spawnPoint.position;
        Destroy(explosion.gameObject, 2);
    }
}