using Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<CinemachineVirtualCamera>().Follow = FindObjectOfType<CharacterMovement>().transform;
    }
}