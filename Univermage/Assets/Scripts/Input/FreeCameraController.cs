using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class FreeCameraController : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;

    [SerializeField]
    private CinemachineVirtualCamera playerVCam;

    [SerializeField]
    public CinemachineVirtualCamera freeCamera;

    [SerializeField]
    private MovementInputHandler movementInputHandler;

    private bool activated;

    private void Awake()
    {
        playerVCam.transform.SetParent(null);
        freeCamera.transform.SetParent(null);
    }

    public void ToggleFreeCameraState()
    {
        activated = !activated;

        movementInputHandler.FreeCameraSetActive(activated);

        if (activated)
        {
            freeCamera.transform.position = playerVCam.transform.position;
            inputManager.FreeCameraInputStateEnabled(false);
            inputManager.Controls.FreeCamera.Enable();
            freeCamera.Priority = 15;
        }
        else
        {
            inputManager.FreeCameraInputStateEnabled(true);
            inputManager.Controls.FreeCamera.Disable();
            freeCamera.Priority = 0;
        }
    }
}