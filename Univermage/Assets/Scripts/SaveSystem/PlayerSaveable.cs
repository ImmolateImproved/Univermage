using UnityEngine;

public class PlayerSaveable : MonoBehaviour
{
    private SpellCaster spellCaster;
    private Movement movement;
    private CharacterDirection characterDirection;

    public SpellController spellController { get; private set; }

    private void Awake()
    {
        spellCaster = GetComponent<SpellCaster>();
        movement = GetComponent<Movement>();
        characterDirection = GetComponent<CharacterDirection>();
        spellController = GetComponent<SpellController>();
    }

    public PlayerSaveData Save()
    {
        var playerPos = movement.GetPosition;

        var playerData = new PlayerSaveData
        {
            position = new float[2] { playerPos.x, playerPos.y },
            facingRight = characterDirection.FacingRight,
            spellIndex = spellController.GetSpellIndex(spellCaster.CurrentSpell)
        };

        return playerData;
    }

    public void Load(in PlayerSaveData playerSaveData)
    {
        var playerPosition = new Vector2(playerSaveData.position[0], playerSaveData.position[1]);
        var playerDirection = playerSaveData.facingRight ? 1 : -1;
        var playerSpell = spellController.GetSpellFromIndex(playerSaveData.spellIndex);

        movement.SetPosition(playerPosition);
        characterDirection.Flip(playerDirection);
        spellCaster.SetSpell(playerSpell);

        spellController.ResetSpells();
    }
}