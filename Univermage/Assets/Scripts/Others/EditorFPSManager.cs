using TMPro;
using UnityEngine;

public class EditorFPSManager : MonoBehaviour
{
    [SerializeField]
    private int fps;

    public void Awake()
    {
#if UNITY_EDITOR
        Application.targetFrameRate = fps;
#endif
    }
}