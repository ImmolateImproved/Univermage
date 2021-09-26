using UnityEngine;

public class PlayerSaveable : MonoBehaviour
{
    private SpellCaster spellCaster;
    private CharacterMovement movement;
    private CharacterDirection characterDirection;
    private LivingEntity livingEntity;

    public SpellController spellController { get; private set; }

    private void Awake()
    {
        spellCaster = GetComponent<SpellCaster>();
        movement = GetComponent<CharacterMovement>();
        characterDirection = GetComponent<CharacterDirection>();
        spellController = GetComponent<SpellController>();
        livingEntity = GetComponent<LivingEntity>();
    }

    public PlayerSaveData Save()
    {
        var playerPos = movement.GetPosition;

        var playerData = new PlayerSaveData
        {
            position = new float[2] { playerPos.x, playerPos.y },
            direction = characterDirection.DirectionX,
            spellIndex = spellController.GetSpellIndex(spellCaster.CurrentSpell)
        };

        return playerData;
    }

    public void Load(in PlayerSaveData playerSaveData)
    {
        var playerPosition = new Vector2(playerSaveData.position[0], playerSaveData.position[1]);
        var playerDirection = playerSaveData.direction;
        var playerSpell = spellController.GetSpellFromIndex(playerSaveData.spellIndex);

        movement.SetPosition(playerPosition);
        characterDirection.Flip(playerDirection);
        spellCaster.SetSpell(playerSpell);

        livingEntity.ResetState();
        spellController.ResetSpells();
    }
}