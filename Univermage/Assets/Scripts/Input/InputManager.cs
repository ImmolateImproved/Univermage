using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Actions
{
    Movement, SpellCast, FreeCameraToggle, RestartLevel, Save, LoadLastSave
}

[CreateAssetMenu(menuName = "ScriptableObjects/InputManager")]
public class InputManager : ScriptableObject
{
    private Controls controls;

    public Controls Controls
    {
        get
        {
            controls ??= new Controls();

            return controls;
        }
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