using UnityEngine;

public abstract class SettingsSaveable : MonoBehaviour
{
    protected SettingsSaveData settingsSaveData;

    public virtual void Load(SettingsSaveData settingsSaveData)
    {
        this.settingsSaveData = settingsSaveData;
    }
}