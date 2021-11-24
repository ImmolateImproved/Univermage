using UnityEngine;

public class MovementInputHandler : MonoBehaviour
{
    [SerializeField]
    private CharacterMovement characterMovement;

    [SerializeField]
    private FreeCameraMovement freeCameraMovement;

    private IMovementInputReceiver movementInputReceiver;

    private void Awake()
    {
        movementInputReceiver = characterMovement;
    }

    public void SetInputVector(Vector2 inputVector)
    {
        movementInputReceiver.SetInputVector(inputVector);
    }

    public void FreeCameraSetActive(bool active)
    {
        movementInputReceiver.SetInputVector(Vector2.zero);

        if (active)
        {
            movementInputReceiver = freeCameraMovement;
        }
        else
        {
            movementInputReceiver = characterMovement;
        }
    }
}