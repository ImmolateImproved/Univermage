using Cinemachine;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[System.Serializable]
public class Tooltip
{
    [Multiline]
    public string text;
    public UnityEvent tooltipEvent;
}

public class TooltipManager : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;

    [SerializeField]
    private CinemachineVirtualCamera playerVCam;

    private CinemachineVirtualCamera lastCamera;

    [SerializeField]
    private GameObject tooltipUIHolder;

    [SerializeField]
    private TextMeshProUGUI textMesh;

    [SerializeField]
    private TooltipTrigger tooltipTrigger;

    private void Awake()
    {
        lastCamera = playerVCam;
    }

    private void Start()
    {
        NextTooltip();
    }

    private void OnEnable()
    {
        inputManager.Controls.Tutorial.Enable();

        inputManager.Controls.Tutorial.NextTooltip.performed += NextTooltip;

        GameplaySaveSystem.OnLoad += SaveSystem_OnLoad;
    }

    private void OnDisable()
    {
        inputManager.Controls.Tutorial.Disable();

        inputManager.Controls.Tutorial.NextTooltip.performed -= NextTooltip;

        GameplaySaveSystem.OnLoad -= SaveSystem_OnLoad;
    }

    private void NextTooltip(InputAction.CallbackContext obj)
    {
        NextTooltip();
    }

    public void NextTooltip()
    {
        var tooltip = tooltipTrigger?.NextTooltip();

        var enableTooltipPanel = tooltip != null && !string.IsNullOrEmpty(tooltip.text);

        tooltipUIHolder.SetActive(enableTooltipPanel);

        if (tooltip != null)
            ShowTooltip(tooltip, enableTooltipPanel);
    }

    public void ShowTooltip(Tooltip tooltip, bool enableTooltipPanel = true)
    {
        tooltipUIHolder.SetActive(enableTooltipPanel);

        textMesh.text = tooltip.text;
        tooltip.tooltipEvent?.Invoke();
    }

    public void SetTooltipTrigger(TooltipTrigger tooltipTrigger)
    {
        this.tooltipTrigger = tooltipTrigger;
        NextTooltip();
    }

    public void SetVirtualCamera(CinemachineVirtualCamera virtualCamera)
    {
        lastCamera.Priority = 0;
        virtualCamera.Priority = 10;
    }

    public void ShowMovementControls()
    {
        var keyBindings = KeyRebinder.keyBindings;

        var sb = new StringBuilder(35);

        sb.Append(keyBindings["up"]);
        sb.Append(",");
        sb.Append(keyBindings["down"]);
        sb.Append(",");
        sb.Append(keyBindings["left"]);
        sb.Append(",");
        sb.Append(keyBindings["right"]);
        sb.Append(",");

        sb.Append(" - передвижение");

        ShowTooltip(new Tooltip { text = sb.ToString() });
    }

    public void ShowSaveLoadControls()
    {
        var keyBindings = KeyRebinder.keyBindings;

        var sb = new StringBuilder(40);

        sb.Append(keyBindings[Actions.Save.ToString()]);
        sb.Append(" - cохранить");
        sb.Append("\n");

        sb.Append(keyBindings[Actions.LoadLastSave.ToString()]);
        sb.Append(" - загрузить");
        sb.Append("\n");

        sb.Append(keyBindings[Actions.RestartLevel.ToString()]);
        sb.Append(" - перезапустить уровень");
        sb.Append("\n");

        sb.Append(keyBindings[Actions.FreeCameraToggle.ToString()]);
        sb.Append(" - свободная камера");

        ShowTooltip(new Tooltip { text = sb.ToString() });
    }

    public void ShowSpellCastControls()
    {
        var keyBindings = KeyRebinder.keyBindings;

        var sb = new StringBuilder(30);

        sb.Append(keyBindings[Actions.SpellCast.ToString()]);
        sb.Append(" - использовать заклинание");

        ShowTooltip(new Tooltip { text = sb.ToString() });
    }

    public void ResetVirtualCamera()
    {
        SetVirtualCamera(playerVCam);
    }

    private void SaveSystem_OnLoad()
    {
        tooltipUIHolder.SetActive(false);
        tooltipTrigger = null;
    }
}