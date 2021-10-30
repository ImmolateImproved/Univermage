using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : Singleton<LevelLoader>
{
    [SerializeField]
    private LevelSelectionButton levelSelectionButtonPrefab;

    [SerializeField]
    private GameObject levelsPanel;

    [SerializeField]
    private Transform levelsPanelContent;

    [SerializeField]
    private int redundantLevelsCount;

    private LevelSaveData levelSaveData;

    private const string LevelSaveName = "Level";

    public int LastOpenLevel => levelSaveData.lastOpenLevel;

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex > levelSaveData.lastOpenLevel)
        {
            levelSaveData.lastOpenLevel = scene.buildIndex;
            BinarySaver.SaveToFile(levelSaveData, LevelSaveName);
        }
    }

    private void OnEnable()
    {
        if (Initialized)
            return;

        levelSaveData = BinarySaver.LoadFromFile<LevelSaveData>(LevelSaveName) ?? new LevelSaveData { lastOpenLevel = 1 };
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void OnDisable()
    {
        if (Initialized)
            return;

        SceneManager.sceneLoaded -= OnLevelLoaded;
    }

    public void InitLevelsPanel()
    {
        LoadButton().Init(1, "Tutorial");

        for (int i = redundantLevelsCount; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            LoadButton().Init(i, $"Level {i - redundantLevelsCount + 1}");
        }

        LevelSelectionButton LoadButton()
        {
            var levelButton = Instantiate(levelSelectionButtonPrefab);
            levelButton.transform.SetParent(levelsPanelContent);
            levelButton.transform.localScale = Vector3.one;

            return levelButton;
        }
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
}

[System.Serializable]
public class LevelSaveData
{
    public int lastOpenLevel;
}