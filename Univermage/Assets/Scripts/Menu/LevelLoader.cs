using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : Singleton<LevelLoader>
{
    private PoolerBase<LevelSelectionButton> levelButtonsPool;

    [SerializeField]
    private LevelSelectionButton levelSelectionButtonPrefab;

    [SerializeField]
    private GameObject levelsPanel;

    [SerializeField]
    private Transform levelsPanelContent;

    [SerializeField]
    private int redundantLevelsCount;

    private List<LevelSelectionButton> levelButtons;

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

    private void Start()
    {
        if (Initialized)
            return;

        var levelsCount = SceneManager.sceneCountInBuildSettings - redundantLevelsCount;

        levelButtons = new List<LevelSelectionButton>(levelsCount);

        levelButtonsPool = new PoolerBase<LevelSelectionButton>();

        levelButtonsPool.InitPool(levelSelectionButtonPrefab, levelsCount, levelsCount + 1);
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

    private void InitLevelsPanel()
    {
        LoadButton().Init(1, "Tutorial");

        for (int i = redundantLevelsCount; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            LoadButton().Init(i, $"Level {i - redundantLevelsCount + 1}");
        }

        LevelSelectionButton LoadButton()
        {
            var levelButton = levelButtonsPool.Get();

            levelButton.transform.SetParent(levelsPanelContent);
            levelButton.transform.localScale = Vector3.one;
            levelButtons.Add(levelButton);

            return levelButton;
        }
    }

    private void ActivateLevelButtons()
    {
        for (int i = 0; i < levelButtons.Count; i++)
        {
            levelButtonsPool.Get();
        }
    }

    public void ShowLevelsPanel()
    {
        levelsPanel.SetActive(true);

        if (levelButtons.Count == 0)
        {
            InitLevelsPanel();
        }
        else
        {
            ActivateLevelButtons();
        }
    }

    public void HideLevelsPanel()
    {
        if (!levelsPanel.activeSelf)
            return;

        levelsPanel.SetActive(false);

        foreach (var item in levelButtons)
        {
            levelButtonsPool.Pool.Release(item);
        }
    }
}

[System.Serializable]
public class LevelSaveData
{
    public int lastOpenLevel;
}