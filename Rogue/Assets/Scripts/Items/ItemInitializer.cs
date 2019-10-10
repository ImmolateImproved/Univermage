using UnityEngine;
using System;

public class ItemInitializer : MonoBehaviour
{
    public GameObject jetpack, wallBreaker, player, ghost;
    public Transform castPoint, spawnPoint;

    [SerializeField] Item[] items;

    void Awake()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].Init(this);
        }
    }

    public Item GetItemFromIndex(int index)
    {
        return index == -1 ? null : items[index];
    }

    public int GetItemIndex(Item item)
    {
        if (item == null)
            return -1;
        
        return Array.IndexOf(items, item);
    }

    public void ResetItems()
    {
        MEC.Timing.KillCoroutines();
        for (int i = 0; i < items.Length; i++)
        {
            items[i].Reset();
        }
    }
}