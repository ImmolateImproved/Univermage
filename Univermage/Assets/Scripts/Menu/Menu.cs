﻿using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : Singleton<Menu>
{
    [SerializeField]
    private InputManager inputManager;

    [SerializeField]
    private SettingsSaveSystem settingsSaveSystem;

    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private LevelLoader levelLoader;

    [SerializeField]
    private GameObject settingsPanel;

    public override void Awake()
    {
        base.Awake();

        if (Initialized)
            return;

        DontDestroyOnLoad(gameObject);
        inputManager.Init();
    }

    private void OnEnable()
    {
        if (Initialized)
            return;

        inputManager.Controls.Menu.OpenMenu.performed += OpenMenuPerformed;
        inputManager.OpenMenuEnabled(true);

        LevelSelectionButton.OnClick += LevelSelectionButtonOnClick;
    }

    private void OnDisable()
    {
        if (Initialized)
            return;

        inputManager.Controls.Menu.OpenMenu.performed -= OpenMenuPerformed;
        inputManager.OpenMenuEnabled(false);

        LevelSelectionButton.OnClick -= LevelSelectionButtonOnClick;
    }

    private void OpenMenuPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OpenMenu();
    }

    private void LevelSelectionButtonOnClick(int levelInex)
    {
        menu.SetActive(false);
        levelLoader.HideLevelsPanel();
        HideSettingsPanel();

        SceneManager.LoadScene(levelInex);
    }

    public void OpenMenu()
    {
        menu.SetActive(!menu.activeSelf);
        levelLoader.HideLevelsPanel();
        HideSettingsPanel();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(levelLoader.LastOpenLevel);
    }

    public void ShowLevelsPanel()
    {
        levelLoader.ShowLevelsPanel();
    }

    public void ShowSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    public void HideSettingsPanel()
    {
        settingsPanel.SetActive(false);
        settingsSaveSystem.Save();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}