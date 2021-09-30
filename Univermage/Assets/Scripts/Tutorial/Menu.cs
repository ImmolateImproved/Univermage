using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;

    [SerializeField]
    private GameObject controllsPanel;

    private void OnEnable()
    {
        inputManager.Controls.Menu.ShowControllsPanel.performed += ShowControllsPanel_performed;
        inputManager.ShowControllsPanelEnabled(true);
    }

    private void OnDisable()
    {
        inputManager.Controls.Menu.ShowControllsPanel.performed -= ShowControllsPanel_performed;
        inputManager.ShowControllsPanelEnabled(false);
    }

    private void ShowControllsPanel_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        ShowControllsPanel();
    }

    public void ShowControllsPanel()
    {
        controllsPanel.SetActive(!controllsPanel.activeSelf);
    }
}