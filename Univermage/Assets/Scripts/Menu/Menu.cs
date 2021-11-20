using TMPro;
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

    [SerializeField]
    private GameObject controlsPanel;

    [SerializeField]
    private KeyRebinder keyRebinder;

    public override void Awake()
    {
        base.Awake();

        if (Initialized)
            return;

        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);
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
        var menuEnabled = !menu.activeSelf || SceneManager.GetActiveScene().buildIndex == 0;

        menu.SetActive(menuEnabled);
        levelLoader.HideLevelsPanel();
        HideSettingsPanel();
        HideControlsPanel();
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
        HideControlsPanel();
        settingsSaveSystem.Save();
    }

    public void OpenControlsPanel()
    {
        var controlsPanelIsOpen = controlsPanel.activeSelf;

        HideControlsPanel();

        if (!controlsPanelIsOpen)
            controlsPanel.SetActive(true);
    }

    public void HideControlsPanel()
    {
        if (!controlsPanel.activeSelf)
            return;

        keyRebinder.CancelRebinding();
        keyRebinder.SaveKeyBindings();
        controlsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}