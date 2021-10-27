using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : SettingsSaveable
{
    [SerializeField]
    private Slider soundSlider;

    [SerializeField]
    private TextMeshProUGUI soundValueText;

    [SerializeField]
    private AudioMixer audioMixer;

    public void OnSoundChange(float value)
    {
        soundValueText.text = $"{(int)(value * 100)}%";
        settingsSaveData.soundVolume = value;
        audioMixer.SetFloat("Effects", Mathf.Lerp(-80, 20, settingsSaveData.soundVolume));
    }

    public override void Load(SettingsSaveData settingsSaveData)
    {
        base.Load(settingsSaveData);

        soundSlider.value = settingsSaveData.soundVolume;
        audioMixer.SetFloat("Effects", Mathf.Lerp(-80, 20, settingsSaveData.soundVolume));
    }
}