using MEC;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalView : SpellView
{
    [SerializeField]
    private GameObject portalPrefab;

    [SerializeField]
    private Transform spawnPoint;

    private IPool<GameObject> portalPool;

    private Queue<GameObject> portalsToDisable;

    public override void Init()
    {
        base.Init();

        portalsToDisable = new Queue<GameObject>();

        portalPool = new ListPool<GameObject>(() => Instantiate(portalPrefab), (x) => !x.activeSelf);

        actions = new Action[2];
        actions[0] = First;
        actions[1] = Second;
    }

    public override void ResetSpellView()
    {
        base.ResetSpellView();
        foreach (var item in portalsToDisable)
        {
            item.SetActive(false);
        }
        portalsToDisable.Clear();
    }

    private void First()
    {
        var portal = portalPool.GetInstance();
        portal.transform.position = spawnPoint.position;
        portal.SetActive(true);

        portalsToDisable.Enqueue(portal);
    }

    private void Second()
    {
        var portal = portalsToDisable.Dequeue();
        portal.SetActive(false);
    }
}