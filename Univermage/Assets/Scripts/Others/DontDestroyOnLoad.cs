using UnityEngine;

public class DontDestroyOnLoad : Singleton<DontDestroyOnLoad>
{
    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}