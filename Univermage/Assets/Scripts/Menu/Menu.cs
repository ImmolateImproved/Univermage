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
    private GameObject levelsPanel;

    [SerializeField]
    private GameObject settingsPanel;

    [SerializeField]
    private Transform levelsPanelContent;

    [SerializeField]
    private LevelSelectionButton levelSelectionButtonPrefab;

    [SerializeField]
    private int redundantLevelsCount;

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
        SceneManager.LoadScene(levelInex);
    }

    private void InitLevelsPanel()
    {
        for (int i = redundantLevelsCount; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            var levelButton = Instantiate(levelSelectionButtonPrefab);
            levelButton.Init(i, (i - redundantLevelsCount + 1).ToString());
            levelButton.transform.SetParent(levelsPanelContent);
            levelButton.transform.localScale = Vector3.one;
        }
    }

    public void OpenMenu()
    {
        menu.SetActive(!menu.activeSelf);
        HideLevelsPanel();
        HideSettingsPanel();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowLevelsPanel()
    {
        levelsPanel.SetActive(true);
        InitLevelsPanel();
    }

    public void HideLevelsPanel()
    {
        levelsPanel.SetActive(false);

        foreach (Transform item in levelsPanelContent)
        {
            Destroy(item.gameObject);
        }
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