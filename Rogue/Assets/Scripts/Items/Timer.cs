using UnityEngine;

public class Timer : MonoBehaviour
{
    float duration;

    void Update()
    {
        duration -= Time.deltaTime;
    }

    public void StartTimer(float _duration)
    {
        duration = _duration;
    }
}