using UnityEngine;

public class PlayerSaveable : MonoBehaviour
{
    private SpellCaster spellManager;
    private Movement movement;
    private CharacterDirection characterDirection;

    public SpellController spellInitializer { get; private set; }

    private void Awake()
    {
        spellManager = GetComponent<SpellCaster>();
        movement = GetComponent<Movement>();
        characterDirection = GetComponent<CharacterDirection>();
        spellInitializer = GetComponent<SpellController>();
    }

    public void Save(ref SaveData save)
    {
        save.playerData.position = transform.position;
        save.playerData.facingRight = GetComponent<CharacterDirection>().FacingRight;
        save.playerData.currentSpell = spellManager.CurrentSpell;
    }

    public void Load(in PlayerData playerData)
    {
        spellInitializer.ResetSpells();
        spellManager.SetSpell(playerData.currentSpell);

        movement.SetPosition(playerData.position);

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
            itemIndex = spellInitializer.GetSpellIndex(playerData.currentSpell)
        };

        return binaryPlayerData;
    }

    public PlayerData GetPlayerDataFormBinary(in BinaryPlayerData binaryData)
    {
        var playerData = new PlayerData()
        {
            currentSpell = spellInitializer.GetSpellFromIndex(binaryData.itemIndex),
            position = new Vector2(binaryData.position[0], binaryData.position[1]),
            facingRight = binaryData.facingRight
        };

        return playerData;
    }
}