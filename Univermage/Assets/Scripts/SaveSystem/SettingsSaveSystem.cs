using UnityEngine;

public class SettingsSaveSystem : MonoBehaviour
{
    [SerializeField]
    private ResolutionSettings resolutionSettings;

    [SerializeField]
    private SoundSettings soundSettings;

    private SettingsSaveData settingsSaveData = new SettingsSaveData();

    private const string SettingsSaveName = "settings";

    private void Awake()
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

        if (settingsSaveData == null)
        {
            settingsSaveData = new SettingsSaveData
            {
                fullScreenModeIndex = 0,
                resolutionIndex = int.MaxValue,
                soundVolume = 1

            };
        }

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
    public float soundVolume;
}