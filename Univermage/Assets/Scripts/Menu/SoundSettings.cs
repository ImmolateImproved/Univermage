using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : SettingsSaveable
{
    [SerializeField]
    private Slider masterVolumeSlider, musicVolumeSlider, effectsVolumeSlider;

    [SerializeField]
    private TextMeshProUGUI masterValueText, musicValueText, effectsValueText;

    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private float minSoundVolume;

    [SerializeField]
    private float maxSoundVolume;

    //Master
    private void SetMasterVolumeInMixer(float value)
    {
        audioMixer.SetFloat("Master", Mathf.Lerp(minSoundVolume, maxSoundVolume, value));
    }

    private void SetMasterVolumeText(float value)
    {
        masterValueText.text = $"{(int)(value * 100)}%";
    }

    public void OnMasterVolumeChange(float value)
    {
        settingsSaveData.masterVolume = value;
        SetMasterVolumeText(value);
        SetMasterVolumeInMixer(value);
    }

    //Music
    private void SetMusicVolumeInMixer(float value)
    {
        audioMixer.SetFloat("Music", Mathf.Lerp(minSoundVolume, maxSoundVolume, value));
    }

    private void SetMusicVolumeText(float value)
    {
        musicValueText.text = $"{(int)(value * 100)}%";
    }

    public void OnMusicVolumeChange(float value)
    {
        settingsSaveData.musicVolume = value;
        SetMusicVolumeText(value);
        SetMusicVolumeInMixer(value);
    }

    //Effects
    private void SetEffectsVolumeInMixer(float value)
    {
        audioMixer.SetFloat("Effects", Mathf.Lerp(minSoundVolume, maxSoundVolume, value));
    }

    private void SetEffectsVolumeText(float value)
    {
        effectsValueText.text = $"{(int)(value * 100)}%";
    }

    public void OnEffectsVolumeChange(float value)
    {
        settingsSaveData.effectsVolume = value;
        SetEffectsVolumeText(value);
        SetEffectsVolumeInMixer(value);
    }

    public override void Load(SettingsSaveData settingsSaveData)
    {
        base.Load(settingsSaveData);

        //Master
        masterVolumeSlider.SetValueWithoutNotify(settingsSaveData.masterVolume);
        SetMasterVolumeText(settingsSaveData.masterVolume);
        SetMasterVolumeInMixer(settingsSaveData.masterVolume);

        //Music
        musicVolumeSlider.SetValueWithoutNotify(settingsSaveData.musicVolume);
        SetMusicVolumeText(settingsSaveData.musicVolume);
        SetMusicVolumeInMixer(settingsSaveData.musicVolume);

        //Effects
        effectsVolumeSlider.SetValueWithoutNotify(settingsSaveData.effectsVolume);
        SetEffectsVolumeText(settingsSaveData.effectsVolume);
        SetEffectsVolumeInMixer(settingsSaveData.effectsVolume);
    }
}