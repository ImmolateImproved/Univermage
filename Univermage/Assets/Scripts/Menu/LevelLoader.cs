using System;
using System.Collections.Generic;
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
    private int levelsToSkip;

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

        string message;

        if (scene.buildIndex > levelsToSkip)
        {
            message = $"Level {scene.buildIndex - levelsToSkip + 1}";
        }
        else
        {
            message = $"Tutorial {scene.buildIndex}";
        }

        MessageTextManager.inst.ShowMessage(message);
    }

    private void Start()
    {
        if (Initialized)
            return;

        var levelsCount = SceneManager.sceneCountInBuildSettings - levelsToSkip;

        levelButtons = new List<LevelSelectionButton>(levelsCount);
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

        for (int i = levelsToSkip; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            var levelNameIndex = i - levelsToSkip + 1;
            LoadButton().Init(i, $"Level {levelNameIndex}");
        }

        LevelSelectionButton LoadButton()
        {
            var levelButton = Instantiate(levelSelectionButtonPrefab);

            levelButton.transform.SetParent(levelsPanelContent);
            levelButton.transform.localScale = Vector3.one;
            levelButtons.Add(levelButton);

            return levelButton;
        }
    }

    public void ShowLevelsPanel()
    {
        levelsPanel.SetActive(true);

        if (levelButtons.Count == 0)
        {
            InitLevelsPanel();
        }
    }

    public void HideLevelsPanel()
    {
        levelsPanel.SetActive(false);
    }
}

[System.Serializable]
public class LevelSaveData
{
    public int lastOpenLevel;
}