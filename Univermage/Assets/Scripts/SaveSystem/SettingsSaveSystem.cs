using UnityEngine;

public class SettingsSaveSystem : MonoBehaviour
{
    [SerializeField]
    private ResolutionSettings resolutionSettings;

    [SerializeField]
    private SoundSettings soundSettings;

    [SerializeField]
    private SettingsSaveData defaultSettings;

    private SettingsSaveData settingsSaveData;

    private const string SettingsSaveName = "settings";

    private void Start()
    {
        Load();
    }

    public void Save()
    {
        BinarySaver.SaveToFile(settingsSaveData, SettingsSaveName);
    }

    public void Load()
    {
        settingsSaveData = BinarySaver.LoadFromFile<SettingsSaveData>(SettingsSaveName);

        settingsSaveData ??= defaultSettings;

        resolutionSettings.Load(settingsSaveData);
        soundSettings.Load(settingsSaveData);
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}

[System.Serializable]
public class SettingsSaveData
{
    public int resolutionIndex;
    public int fullScreenModeIndex;

    public float masterVolume;
    public float musicVolume;
    public float effectsVolume;
}