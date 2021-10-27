using UnityEngine;

public class EditorFPSManager : MonoBehaviour
{
    [SerializeField]
    private int fps;

    public void Awake()
    {
        Application.targetFrameRate = int.MaxValue;

#if UNITY_EDITOR
        Application.targetFrameRate = fps;
#endif
    }
}