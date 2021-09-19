using System;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawnView : SpellView
{
    private Transform rootObject;

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private Transform spawnPoint;

    private Queue<GameObject> objectsToDisable;

    public override void Init()
    {
        base.Init();

        rootObject = transform.root;

        objectsToDisable = new Queue<GameObject>();

        actions = new Action[2];
        actions[0] = First;
        actions[1] = Second;
    }

    public override void ResetSpellView()
    {
        base.ResetSpellView();
        foreach (var item in objectsToDisable)
        {
            Destroy(item);
        }
        objectsToDisable.Clear();
    }

    private void First()
    {
        var obj = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        obj.transform.localScale = rootObject.localScale;

        objectsToDisable.Enqueue(obj);
    }

    private void Second()
    {
        var obj = objectsToDisable.Dequeue();
        Destroy(obj);
    }
}