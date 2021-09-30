using System;
using System.Collections.Generic;
using UnityEngine;

public class PortalView : SpellView
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private Transform spawnPoint;

    private Queue<GameObject> portals;

    protected Transform lastPortal;

    public override void Init()
    {
        base.Init();

        portals = new Queue<GameObject>();

        actions = new Action[2];
        actions[0] = First;
        actions[1] = Second;
    }

    public override void ResetSpellView()
    {
        base.ResetSpellView();
        foreach (var item in portals)
        {
            Destroy(item);
        }
        portals.Clear();
    }

    protected virtual void First()
    {
        var portal = Instantiate(prefab);
        portal.transform.position = spawnPoint.position;

        lastPortal = portal.transform;
        portals.Enqueue(portal);
    }

    private void Second()
    {
        var obj = portals.Dequeue();
        Destroy(obj);
    }
}