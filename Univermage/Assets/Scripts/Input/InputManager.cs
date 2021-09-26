using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "ScriptableObjects/InputManager")]
public class InputManager : ScriptableObject
{
    public Controls Controls { get; private set; }

    public void Init()
    {
        Controls = new Controls();
    }

    public void EnableGameplayInput()
    {
        Controls.Player.Movement.Enable();
        Controls.Player.SpellCast.Enable();
        Controls.Player.Save.Enable();
        Controls.Player.FreeCamera.Enable();
    }

    public void DisableGameplayInput(bool disableFreeCamera = true)
    {
        Controls.Player.Movement.Disable();
        Controls.Player.SpellCast.Disable();
        Controls.Player.Save.Disable();

        if (disableFreeCamera)
            Controls.Player.FreeCamera.Disable();
    }

    public void EnablePlayerInput()
    {
        Controls.Player.Enable();
    }

    public void DisablePlayerInput()
    {
        Controls.Player.Disable();
    }
}