using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public enum AudioMixerGroups
{
    Master, Music, Effects, Steps
}

public class SoundSettings : SettingsSaveable<VolumeSettingsSaveData>
{
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
    private AudioMixerGroups audioMixerGroup;

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
        var volume = settingsSaveData.volumes[(int)audioMixerGroup];

        volumeSlider.SetValueWithoutNotify(volume);
        SetVolumeText(volume);
        SetVolumeInMixer(volume);
    }

    private void SetVolumeInMixer(float value)
    {
        audioMixer.SetFloat(audioMixerGroup.ToString(), Mathf.Lerp(minSoundVolume, maxSoundVolume, value));
    }

    private void SetVolumeText(float value)
    {
        volumeText.text = $"{(int)(value * 100)}%";
    }

    private void OnVolumeChange(float value)
    {
        settingsSaveData.volumes[(int)audioMixerGroup] = value;

        SetVolumeText(value);
        SetVolumeInMixer(value);
    }
}