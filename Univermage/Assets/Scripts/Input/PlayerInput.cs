using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;

    private Controls controls;
    private InputAction movementAction;

    private CharacterMovement movement;
    private SpellCaster spellCaster;
    private GameplaySaveManager saveManager;

    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
        spellCaster = GetComponent<SpellCaster>();
    }

    private void Start()
    {
        saveManager = GameplaySaveManager.inst;
    }

    private void Update()
    {
        MovementInput();
    }

    private void OnEnable()
    {
        controls = inputManager.Controls;

        movementAction = controls.Player.Movement;
        controls.Player.SpellCast.performed += SpellCast_performed;
        controls.Player.Save.performed += Save_performed;
        controls.Player.LoadLastSave.performed += LoadLastSave_performed;
        controls.Player.RestartLevel.performed += RestartLevel_performed;

        inputManager.PlayerInputEnabled(true);

    }

    private void OnDisable()
    {
        movementAction.Disable();

        controls.Player.SpellCast.performed -= SpellCast_performed;
        controls.Player.Save.performed -= Save_performed;
        controls.Player.LoadLastSave.performed -= LoadLastSave_performed;
        controls.Player.RestartLevel.performed -= RestartLevel_performed;

        inputManager.PlayerInputEnabled(false);
    }

    private void SpellCast_performed(InputAction.CallbackContext value)
    {
        spellCaster.CastSpell();
    }

    private void Save_performed(InputAction.CallbackContext value)
    {
        saveManager.TrySave();
    }

    private void LoadLastSave_performed(InputAction.CallbackContext value)
    {
        saveManager.LoadLastSave();
    }

    private void RestartLevel_performed(InputAction.CallbackContext value)
    {
        LevelManager.Restart();
    }

    private void MovementInput()
    {
        var direction = movementAction.ReadValue<Vector2>();

        movement.SetMoveDirection(direction);
    }
}