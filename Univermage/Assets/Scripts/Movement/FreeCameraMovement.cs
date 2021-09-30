using UnityEngine;

public class FreeCameraMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    public void SetMoveDirection(Vector2 direction)
    {
        transform.position += (Vector3)direction.normalized * moveSpeed * Time.deltaTime;
    }
}