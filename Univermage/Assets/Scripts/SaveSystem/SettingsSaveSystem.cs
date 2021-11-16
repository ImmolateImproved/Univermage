using UnityEngine;

public class SettingsSaveSystem : MonoBehaviour
{
    [SerializeField]
    private ResolutionSettings resolutionSettings;

    [SerializeField]
    private SoundSettings soundSettings;

    [SerializeField]
    private KeyRebinder keyRebinder;

    [SerializeField]
    private ScreenSettingsSaveData defaultScreenSettings;
    [SerializeField]
    private VolumeSettingsSaveData defaultVolumeSettings;

    private ScreenSettingsSaveData screenSettingsSaveData;
    private VolumeSettingsSaveData volumeSettingsSaveData;
    private KeyBindigsSaveData keyBindigsSaveData;

    private const string screenSettingsSaveName = "screenSettings";
    private const string volumeSettingsSaveName = "volumeSettings";
    private const string keyBindingsSaveName = "keyBindings";

    private void Start()
    {
        Load();
    }

    public void Save()
    {
        BinarySaver.SaveToFile(screenSettingsSaveData, screenSettingsSaveName);
        BinarySaver.SaveToFile(volumeSettingsSaveData, volumeSettingsSaveName);
        BinarySaver.SaveToFile(keyBindigsSaveData, keyBindingsSaveName);
    }

    public void Load()
    {
        screenSettingsSaveData = BinarySaver.LoadFromFile<ScreenSettingsSaveData>(screenSettingsSaveName);
        volumeSettingsSaveData = BinarySaver.LoadFromFile<VolumeSettingsSaveData>(volumeSettingsSaveName);
        keyBindigsSaveData = BinarySaver.LoadFromFile<KeyBindigsSaveData>(keyBindingsSaveName);

        screenSettingsSaveData ??= defaultScreenSettings;
        volumeSettingsSaveData ??= defaultVolumeSettings;
        keyBindigsSaveData ??= new KeyBindigsSaveData();

        resolutionSettings.Load(screenSettingsSaveData);
        soundSettings.Load(volumeSettingsSaveData);
        keyRebinder.Load(keyBindigsSaveData);
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}

[System.Serializable]
public class ScreenSettingsSaveData
{
    public int resolutionIndex;
    public int fullScreenModeIndex;
}

[System.Serializable]
public class VolumeSettingsSaveData
{
    public float masterVolume;
    public float musicVolume;
    public float effectsVolume;
}

[System.Serializable]
public class KeyBindigsSaveData
{
    public string keyBindings;
}