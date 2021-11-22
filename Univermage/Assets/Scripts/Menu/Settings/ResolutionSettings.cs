using UnityEngine;
using System.Linq;
using TMPro;
using System;

public class ResolutionSettings : SettingsSaveable<ScreenSettingsSaveData>
{
    private Resolution[] resolutions;

    private FullScreenMode[] fullScreenModes;

    private int selectedFullScreenMode;
    private int selectedResolution;

    [SerializeField]
    private TMP_Dropdown resolutionsDropdown;
    [SerializeField]
    private TMP_Dropdown fullScreenModeDropdown;

    private void Init()
    {
        resolutions = Screen.resolutions;

        var resolutionStrings = resolutions.Select(x => x.ToString()).ToList();
        resolutionsDropdown.AddOptions(resolutionStrings);

        fullScreenModes = Enum.GetValues(typeof(FullScreenMode)).Cast<FullScreenMode>().ToArray();

        var fullScreenModeStrings = fullScreenModes.Select(x => x.ToString()).ToList();

        fullScreenModeDropdown.AddOptions(fullScreenModeStrings);
    }

    public override void Load(ScreenSettingsSaveData settingsSaveData)
    {
        base.Load(settingsSaveData);

        Init();

        selectedResolution = Mathf.Clamp(settingsSaveData.resolutionIndex, 0, resolutions.Length - 1);
        selectedFullScreenMode = Mathf.Clamp(settingsSaveData.fullScreenModeIndex, 0, fullScreenModes.Length - 1);

        resolutionsDropdown.SetValueWithoutNotify(selectedResolution);
        fullScreenModeDropdown.SetValueWithoutNotify(selectedFullScreenMode);

        var reso = resolutions[selectedResolution];
        var fullScreen = fullScreenModes[selectedFullScreenMode];

        Screen.SetResolution(reso.width, reso.height, fullScreen);
    }

    public void OnResolutionChange(int index)
    {
        selectedResolution = index;
        settingsSaveData.resolutionIndex = index;

        var reso = resolutions[index];

        Screen.SetResolution(reso.width, reso.height, fullScreenModes[selectedFullScreenMode]);
    }

    public void OnFullScreenModeChange(int index)
    {
        selectedFullScreenMode = index;
        settingsSaveData.fullScreenModeIndex = index;

        var reso = resolutions[selectedResolution];

        Screen.SetResolution(reso.width, reso.height, fullScreenModes[index]);
    }
}