using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class FreeCameraController : MonoBehaviour
{
    [SerializeField]
    public InputManager inputManager;


    [SerializeField]
    private CinemachineVirtualCamera freeCamera;

    [SerializeField]
    private CinemachineVirtualCamera playerVCam;

    [SerializeField]
    private FreeCameraMovement freeCameraMovement;

    private InputAction movementAction;

    private bool activated;

    private void Start()
    {
        movementAction = inputManager.Controls.FreeCamera.Movement;
    }

    private void Update()
    {
        MovementInput();
    }

    private void OnEnable()
    {
        inputManager.Controls.Player.FreeCameraToggle.performed += FreeCamera_performed;
    }

    private void OnDisable()
    {
        inputManager.Controls.Player.FreeCameraToggle.performed -= FreeCamera_performed;
    }

    private void FreeCamera_performed(InputAction.CallbackContext obj)
    {
        activated = !activated;

        if (activated)
        {
            freeCamera.transform.position = playerVCam.transform.position;
            inputManager.GameplayInputEnabled(false);
            inputManager.Controls.FreeCamera.Enable();
            freeCamera.Priority = 15;
        }
        else
        {
            inputManager.GameplayInputEnabled(true);
            inputManager.Controls.FreeCamera.Disable();
            freeCamera.Priority = 0;
        }
    }

    private void MovementInput()
    {
        var direction = movementAction.ReadValue<Vector2>();

        freeCameraMovement.SetMoveDirection(direction);
    }
}