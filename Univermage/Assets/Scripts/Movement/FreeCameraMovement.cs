using UnityEngine;

public class FreeCameraMovement : MonoBehaviour, IMovementInputReceiver
{
    [SerializeField]
    private float moveSpeed;

    public void SetInputVector(Vector2 inputVector)
    {
        transform.position += (Vector3)inputVector.normalized * moveSpeed * Time.deltaTime;
    }
}