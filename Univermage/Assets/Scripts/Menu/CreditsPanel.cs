using UnityEngine;
using UnityEngine.InputSystem;

public class CreditsPanel : MonoBehaviour
{
    public GameObject creditsPanel;

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            creditsPanel.SetActive(false);
        }
    }

    public void ToggleActiveState()
    {
        creditsPanel.SetActive(!creditsPanel.activeSelf);
    }
}