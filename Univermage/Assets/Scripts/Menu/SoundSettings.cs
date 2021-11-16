using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : SettingsSaveable<VolumeSettingsSaveData>
{
    public const string masterGroup = "Master";
    public const string musicGroup = "Music";
    public const string effectsGroup = "Effects";

    [SerializeField]
    private SoundSettingsSlider[] soundSettingsSliders;

    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private float minSoundVolume;

    [SerializeField]
    private float maxSoundVolume;

    public override void Load(VolumeSettingsSaveData settingsSaveData)
    {
        base.Load(settingsSaveData);

        //Master
        foreach (var item in soundSettingsSliders)
        {
            item.Init(minSoundVolume, maxSoundVolume, audioMixer, settingsSaveData);
            item.Load(settingsSaveData);
        }
    }
}

[System.Serializable]
public class SoundSettingsSlider
{
    [SerializeField]
    private Slider volumeSlider;

    [SerializeField]
    private TextMeshProUGUI volumeText;

    [SerializeField]
    private string audioMixerGroup;

    private AudioMixer audioMixer;

    private VolumeSettingsSaveData settingsSaveData;

    private float minSoundVolume;

    private float maxSoundVolume;

    public void Init(float minSoundVolume, float maxSoundVolume, AudioMixer audioMixer, VolumeSettingsSaveData volumeSettingsSaveData)
    {
        this.minSoundVolume = minSoundVolume;
        this.maxSoundVolume = maxSoundVolume;

        this.audioMixer = audioMixer;
        this.settingsSaveData = volumeSettingsSaveData;

        volumeSlider.onValueChanged.RemoveAllListeners();
        volumeSlider.onValueChanged.AddListener(OnVolumeChange);
    }

    public void Load(VolumeSettingsSaveData settingsSaveData)
    {
        var volume = audioMixerGroup switch
        {
            SoundSettings.masterGroup => settingsSaveData.masterVolume,
            SoundSettings.musicGroup => settingsSaveData.musicVolume,
            SoundSettings.effectsGroup => settingsSaveData.effectsVolume,
            _=> 0
        };

        volumeSlider.SetValueWithoutNotify(volume);
        SetVolumeText(volume);
        SetVolumeInMixer(volume);
    }

    private void SetVolumeInMixer(float value)
    {
        audioMixer.SetFloat(audioMixerGroup, Mathf.Lerp(minSoundVolume, maxSoundVolume, value));
    }

    private void SetVolumeText(float value)
    {
        volumeText.text = $"{(int)(value * 100)}%";
    }

    private void OnVolumeChange(float value)
    {
        switch (audioMixerGroup)
        {
            case SoundSettings.masterGroup: { settingsSaveData.masterVolume = value; } break;
            case SoundSettings.musicGroup: { settingsSaveData.musicVolume = value; } break;
            case SoundSettings.effectsGroup: { settingsSaveData.effectsVolume = value; } break;
        }

        SetVolumeText(value);
        SetVolumeInMixer(value);
    }
}