using Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        GetComponent<CinemachineVirtualCamera>().Follow = FindObjectOfType<CharacterMovement>().transform;
    }
}