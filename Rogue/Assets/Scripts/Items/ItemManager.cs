using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Item CurrentItem { get; private set; }

    public static event System.Action<Item> OnSetItem = delegate { };
    public static event System.Action OnItemUsed = delegate { };

    public void SetItem(Item item)
    {
        CurrentItem = item;
        OnSetItem(item);
    }

    public void PickUpItem(ItemPickup item)
    {
        if (!CurrentItem)
        {
            SetItem(item.value);
            item.Disable();
        }
    }

    public void UseItem()
    {
        if (CurrentItem)
        {
            OnItemUsed();
            CurrentItem.Use();
            CurrentItem = null;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (CurrentItem)
            return;

        var item = collision.GetComponent<ItemPickup>();

        if (item)
        {
            PickUpItem(item);
        }
    }
}