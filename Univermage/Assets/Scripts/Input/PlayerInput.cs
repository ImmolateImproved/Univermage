using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Controls controls;
    private InputAction movementAction;

    private Movement movement;
    private SpellCaster spellManager;
    private SaveManager saveManager;

    private void Awake()
    {
        controls = new Controls();

        movement = GetComponent<Movement>();
        spellManager = GetComponent<SpellCaster>();
    }

    private void Start()
    {
        saveManager = SaveManager.inst;
    }

    private void Update()
    {
        MovementInput();
    }

    private void OnEnable()
    {
        movementAction = controls.Player.Movement;
        movementAction.Enable();

        controls.Player.SpellCast.performed += SpellCast_performed;
        controls.Player.SpellCast.Enable();

        controls.Player.Save.performed += Save_performed;
        controls.Player.Save.Enable();

        controls.Player.LoadLastSave.performed += LoadLastSave_performed;
        controls.Player.LoadLastSave.Enable();

        controls.Player.RestartLevel.performed += RestartLevel_performed;
        controls.Player.RestartLevel.Enable();
    }

    private void OnDisable()
    {
        movementAction.Disable();
        controls.Player.SpellCast.Disable();
        controls.Player.Save.Disable();
        controls.Player.LoadLastSave.Disable();
        controls.Player.RestartLevel.Disable();
    }

    public void EnableGameplayInput()
    {
        movementAction.Enable();
        controls.Player.SpellCast.Enable();
    }

    public void DisableGameplayInput()
    {
        movementAction.Disable();
        controls.Player.SpellCast.Disable();
    }

    //public void EnableInput()
    //{
    //    controls.Enable();
    //}

    //public void DisableInput()
    //{
    //    controls.Disable();
    //}

    private void SpellCast_performed(InputAction.CallbackContext value)
    {
        spellManager.CastSpell();
    }

    private void Save_performed(InputAction.CallbackContext value)
    {
        saveManager.Save();
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

        movement.SetInputDirection(direction);
    }
}