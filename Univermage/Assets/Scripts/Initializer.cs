using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;

    [SerializeField]
    private int fps;

    private void Awake()
    {
        inputManager.Init();

        if (fps > 30)
            Application.targetFrameRate = fps;
        else
            Application.targetFrameRate = int.MaxValue;
    }
}