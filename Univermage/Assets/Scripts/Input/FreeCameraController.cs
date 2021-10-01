﻿using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class FreeCameraController : MonoBehaviour
{
    [SerializeField]
    public InputManager inputManager;

    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    private FreeCameraMovement freeCamera;

    private InputAction movementAction;

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
        if (movementAction.enabled)
        {
            inputManager.GameplayInputEnabled(false);
            inputManager.Controls.FreeCamera.Disable();
            virtualCamera.Priority = 0;
        }
        else
        {
            inputManager.GameplayInputEnabled(true); 
            inputManager.Controls.Player.FreeCameraToggle.Enable();
            inputManager.Controls.FreeCamera.Enable();
            virtualCamera.Priority = 15;
        }
    }

    private void MovementInput()
    {
        var direction = movementAction.ReadValue<Vector2>();

        freeCamera.SetMoveDirection(direction);
    }
}