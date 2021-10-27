using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "ScriptableObjects/InputManager")]
public class InputManager : ScriptableObject
{
    public Controls Controls { get; private set; }

    public void Init()
    {
        Controls ??= new Controls();
    }

    public void PlayerInputEnabled(bool enable)
    {
        if (enable)
        {
            Controls.Player.Enable();
        }
        else
        {
            Controls.Player.Disable();
        }
        Controls.Player.RestartLevel.Enable();
    }

    public void GameplayInputEnabled(bool enable)
    {
        if (enable)
        {
            Controls.Player.Movement.Enable();
            Controls.Player.SpellCast.Enable();
        }
        else
        {
            Controls.Player.Movement.Disable();
            Controls.Player.SpellCast.Disable();
        }
    }

    public void PlayerMovementEnabled(bool enable)
    {
        if (enable)
        {
            Controls.Player.Movement.Enable();
        }
        else
        {
            Controls.Player.Movement.Disable();
        }
    }

    public void SaveInputEnabled(bool enable)
    {
        if (enable)
        {
            Controls.Player.Save.Enable();
            Controls.Player.LoadLastSave.Enable();
        }
        else
        {
            Controls.Player.Save.Disable();
            Controls.Player.LoadLastSave.Disable();
        }
    }

    public void LoadInputEnabled(bool enable)
    {
        if (enable)
        {
            Controls.Player.LoadLastSave.Enable();
        }
        else
        {
            Controls.Player.LoadLastSave.Disable();
        }
    }

    public void GameplayAndSaveEnabled(bool enable)
    {
        GameplayInputEnabled(enable);
        SaveInputEnabled(enable);
    }

    public void OpenMenuEnabled(bool enable)
    {
        if (enable)
        {
            Controls.Menu.OpenMenu.Enable();
        }
        else
        {
            Controls.Menu.OpenMenu.Disable();
        }
    }
}