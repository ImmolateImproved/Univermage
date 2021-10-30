using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : SettingsSaveable
{
    [SerializeField]
    private Slider soundVolumeSlider;

    [SerializeField]
    private TextMeshProUGUI soundValueText;

    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private float minSoundVolume;

    [SerializeField]
    private float maxSoundVolume;

    private void SetVolumeInMixer(float value)
    {
        audioMixer.SetFloat("Effects", Mathf.Lerp(minSoundVolume, maxSoundVolume, value));
    }

    private void SetVolumeText(float value)
    {
        soundValueText.text = $"{(int)(value * 100)}%";
    }

    public void OnSoundChange(float value)
    {
        settingsSaveData.soundVolume = value;
        SetVolumeText(value);
        SetVolumeInMixer(value);
    }

    public override void Load(SettingsSaveData settingsSaveData)
    {
        base.Load(settingsSaveData);

        soundVolumeSlider.SetValueWithoutNotify(settingsSaveData.soundVolume);
        SetVolumeText(settingsSaveData.soundVolume);
        SetVolumeInMixer(settingsSaveData.soundVolume);
    }
}