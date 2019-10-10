using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T : MonoBehaviour
{
    public static T inst;

    public virtual void Awake()
    {
        if (inst == null)
        {
            DontDestroyOnLoad(gameObject);
            inst = this as T;
        }
        else
        {
            if (inst != this)
            {
                Destroy(gameObject);
            }
        }
    }
}