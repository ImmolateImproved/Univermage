using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : SettingsSaveable
{
    [SerializeField]
    private TextMeshProUGUI soundValueText;

    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private float minSoundVolume;

    [SerializeField]
    private float maxSoundVolume;

    private void SetVolume(float value)
    {
        settingsSaveData.soundVolume = value;
        audioMixer.SetFloat("Effects", Mathf.Lerp(minSoundVolume, maxSoundVolume, settingsSaveData.soundVolume));
    }

    public void OnSoundChange(float value)
    {
        soundValueText.text = $"{(int)(value * 100)}%";
        SetVolume(value);
    }

    public override void Load(SettingsSaveData settingsSaveData)
    {
        base.Load(settingsSaveData);

        SetVolume(settingsSaveData.soundVolume);
    }
}