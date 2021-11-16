using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyRebinder : SettingsSaveable<KeyBindigsSaveData>
{
    [SerializeField]
    private InputManager inputManager;

    [SerializeField]
    private RebindKeyButton[] rebindKeyButtons;

    [SerializeField]
    private Color rebindColor, defaultColor;

    public static Dictionary<string, string> keyBindings { get; private set; }

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    private RebindKeyButton currentRebindingButton;

    private Tweener rebindViewTweener;

    private void OnEnable()
    {
        RebindKeyButton.OnClick += RebindKeyButton_OnClick;
    }

    private void OnDisable()
    {
        RebindKeyButton.OnClick -= RebindKeyButton_OnClick;
    }

    public override void Load(KeyBindigsSaveData settingsSaveData)
    {
        base.Load(settingsSaveData);

        if (!string.IsNullOrEmpty(settingsSaveData.keyBindings))
        {
            inputManager.Controls.LoadBindingOverridesFromJson(settingsSaveData.keyBindings);
        }

        keyBindings = new Dictionary<string, string>();

        string[] actions = System.Enum.GetNames(typeof(Actions));

        var bindingIndex = 0;

        for (int i = 0; i < actions.Length; i++)
        {
            var action = inputManager.Controls.FindAction(actions[i]);

            for (int j = 0; j < action.bindings.Count; j++)
            {
                j = action.bindings[j].isComposite ? j += 1 : j;

                var bindingName = action.bindings[0].isComposite ? action.bindings[j].name : action.name;

                if (bindingIndex >= rebindKeyButtons.Length)
                    return;

                var binding = ToHumanReadableString(action, j);

                keyBindings.Add(bindingName, binding);
                rebindKeyButtons[bindingIndex].buttonText.text = binding;

                bindingIndex++;
            }
        }
    }

    public void CancelRebinding()
    {
        rebindingOperation?.Cancel();
    }

    public void SaveKeyBindings()
    {
        settingsSaveData.keyBindings = inputManager.Controls.SaveBindingOverridesAsJson();
    }

    private void RebindKeyButton_OnClick(RebindKeyButton rebindKeyButton)
    {
        ResesRebindingUI();

        CancelRebinding();

        currentRebindingButton = rebindKeyButton;

        rebindViewTweener = rebindKeyButton.Image.DOColor(rebindColor, 1).SetLoops(-1, LoopType.Yoyo);

        var action = inputManager.Controls.asset.FindAction(rebindKeyButton.action.ToString());

        StartRebinding(action, rebindKeyButton.CompositeIndex);
    }

    private void StartRebinding(InputAction inputAction, int compositeIndex)
    {
        inputManager.PlayerInputEnabled(false);

        inputAction.Disable();

        try
        {
            rebindingOperation = inputAction.PerformInteractiveRebinding(compositeIndex)
                .WithCancelingThrough("<Keyboard>/escape")
                .WithControlsExcluding("Mouse")
                .OnMatchWaitForAnother(0.1f)
                .OnComplete((op) => RebindingComplele(inputAction, compositeIndex))
                .OnCancel(RebindingCanceled)
                .Start();
        }
        catch
        {
            CancelRebinding();
            StopRebinding(inputAction);
        }
    }

    private void RebindingComplele(InputAction action, int bindingIndex = 0)
    {
        var bindingString = ToHumanReadableString(action, bindingIndex); ;
        currentRebindingButton.buttonText.text = bindingString;

        if (keyBindings != null)
        {
            var bindingName = action.bindings[0].isComposite ? action.bindings[bindingIndex].name : action.name;

            if (keyBindings.TryGetValue(bindingName, out var _))
            {
                keyBindings[bindingName] = bindingString;
            }
        }

        action.Enable();
        StopRebinding(action);
    }

    private void RebindingCanceled(InputActionRebindingExtensions.RebindingOperation operation)
    {
        StopRebinding(operation.action);
    }

    private void StopRebinding(InputAction inputAction)
    {
        inputManager.PlayerInputEnabled(true);
        inputAction.Enable();

        rebindingOperation.Dispose();
        rebindingOperation = null;
        ResesRebindingUI();
    }

    private string ToHumanReadableString(InputAction inputAction, int bindingIndex = 0)
    {
        return InputControlPath.ToHumanReadableString(inputAction.bindings[bindingIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
    }

    private void ResesRebindingUI()
    {
        if (currentRebindingButton == null)
            return;

        currentRebindingButton.Image.color = defaultColor;
        rebindViewTweener.Kill();
    }
}