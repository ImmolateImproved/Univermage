using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Actions
{
    Movement, SpellCast, FreeCameraToggle, RestartLevel, Save, LoadLastSave
}

public enum KeyBindingsNames
{
    up, down, left, right, SpellCast, FreeCameraToggle, RestartLevel, Save, LoadLastSave
}

[CreateAssetMenu(menuName = "ScriptableObjects/Input/InputManager")]
public class InputManager : ScriptableObject
{
    private Controls controls;

    private Dictionary<Actions, InputAction> actionMap = new Dictionary<Actions, InputAction>();

    public string[] ActionsStrings { get; private set; }

    public Controls Controls
    {
        get
        {
            if (controls == null)
            {
                controls = new Controls();

                Init();
            }

            return controls;
        }
    }

    private void Init()
    {
        ActionsStrings = ActionsToStringArray();
        var valuesAsArray = ActionToValuesArray();

        for (int i = 0; i < ActionsStrings.Length; i++)
        {
            actionMap.Add(valuesAsArray[i], controls.FindAction(ActionsStrings[i]));
        }
    }

    private string[] ActionsToStringArray()
    {
        return System.Enum.GetNames(typeof(Actions));
    }

    private List<Actions> ActionToValuesArray()
    {
        return System.Enum.GetValues(typeof(Actions)).Cast<Actions>().ToList();
    }

    public void EnableInput(InputEnabler inputEnabler, bool enable)
    {
        if (enable)
        {
            foreach (var action in inputEnabler.actions)
            {
                actionMap[action].Enable();
            }
        }
        else
        {
            foreach (var action in inputEnabler.actions)
            {
                actionMap[action].Disable();
            }
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