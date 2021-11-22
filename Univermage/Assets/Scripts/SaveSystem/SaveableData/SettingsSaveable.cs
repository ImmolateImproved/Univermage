using UnityEngine;

public abstract class SettingsSaveable<T> : MonoBehaviour
{
    protected T settingsSaveData;

    public virtual void Load(T settingsSaveData)
    {
        this.settingsSaveData = settingsSaveData;
    }
}