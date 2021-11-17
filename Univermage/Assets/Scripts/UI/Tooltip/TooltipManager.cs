using Cinemachine;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

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

        textMesh.text = tooltip.GetText();
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