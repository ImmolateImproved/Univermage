using UnityEngine;

public class PlayerSaveable : MonoBehaviour
{
    ItemManager itemManager;
    Movement movement;
    CharacterDirection characterDirection;
    public ItemInitializer itemInitializer { get; private set; }

    void Awake()
    {
        itemManager = GetComponent<ItemManager>();
        movement = GetComponent<Movement>();
        characterDirection = GetComponent<CharacterDirection>();
        itemInitializer = GetComponent<ItemInitializer>();
    }

    public void Save(ref SaveData save)
    {
        save.playerData.position = transform.position;
        save.playerData.facingRight = GetComponent<CharacterDirection>().FacingRight;
        save.playerData.currentItem = itemManager.CurrentItem;
    }

    public void Load(in PlayerData playerData)
    {
        itemInitializer.ResetItems();
        itemManager.SetItem(playerData.currentItem);

        movement.SetPos(playerData.position);

        if (characterDirection.FacingRight != playerData.facingRight)
        {
            characterDirection.Flip();
        }
    }

    public BinaryPlayerData GetBinaryData(in PlayerData playerData)
    {
        var binaryPlayerData = new BinaryPlayerData
        {
            position = new float[2] { playerData.position.x, playerData.position.y },
            facingRight = playerData.facingRight,
            itemIndex = itemInitializer.GetItemIndex(playerData.currentItem)
        };

        return binaryPlayerData;
    }

    public PlayerData GetPlayerDataFormBinary(in BinaryPlayerData binaryData)
    {
        var playerData = new PlayerData()
        {
            currentItem = itemInitializer.GetItemFromIndex(binaryData.itemIndex),
            position = new Vector2(binaryData.position[0], binaryData.position[1]),
            facingRight = binaryData.facingRight
        };

        return playerData;
    }
}