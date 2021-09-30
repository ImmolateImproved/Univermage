using UnityEngine;

public class Saveable : MonoBehaviour
{
    private ISaveable saveable;

    public void Init()
    {
        saveable = GetComponent<ISaveable>();
        saveable.Init();
    }

    public bool Save()
    {
        return saveable.Save();
    }

    public void Load(bool data)
    {
        saveable.Load(data);
    }
}