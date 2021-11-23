﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;
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
    private int scenesToSkip;

    [SerializeField]
    private int lastTutorialScene;

    private List<LevelSelectionButton> levelButtons;

    private LevelsSaveData lastOpenedLevel;
    [SerializeField]
    private FinishedLevels finishedLevels;

    private const string LevelSaveName = "Level";
    private const string FinishedLevelsSaveName = "FinishedLevels";

    public int CurrentLevel => Mathf.Max(SceneManager.GetActiveScene().buildIndex - scenesToSkip + 1, 0);

    public int LastOpenLevel => lastOpenedLevel.lastOpenLevel;

    public int LevelsCount => SceneManager.sceneCountInBuildSettings - scenesToSkip + 1;

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex > lastOpenedLevel.lastOpenLevel)
        {
            if (scene.buildIndex >= scenesToSkip)
            {
                lastOpenedLevel.lastOpenLevel = scene.buildIndex;

                BinarySaver.SaveToFile(lastOpenedLevel, LevelSaveName);
            }
        }

        string message;

        if (scene.buildIndex >= scenesToSkip)
        {
            message = $"Level {CurrentLevel}";
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

        levelButtons = new List<LevelSelectionButton>(LevelsCount);
    }

    private void OnEnable()
    {
        if (Initialized)
            return;

        LoadLevelsData();

        EndLevel.OnLevelFinished += EndLevel_OnLevelFinished;

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void OnDisable()
    {
        if (Initialized)
            return;

        EndLevel.OnLevelFinished -= EndLevel_OnLevelFinished;
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }

    private void EndLevel_OnLevelFinished()
    {
        var needSave = false;

        if (SceneManager.GetActiveScene().buildIndex == lastTutorialScene)
        {
            finishedLevels.value[0] = true;
            needSave = true;
        }

        if (CurrentLevel > 0)
        {
            needSave = true;
            finishedLevels.value[CurrentLevel] = true;
        }

        if (needSave)
        {
            BinarySaver.SaveToFile(finishedLevels, FinishedLevelsSaveName);
        }
    }

    private void LoadLevelsData()
    {
        lastOpenedLevel = BinarySaver.LoadFromFile<LevelsSaveData>(LevelSaveName) ?? new LevelsSaveData { lastOpenLevel = 1 };
        finishedLevels = BinarySaver.LoadFromFile<FinishedLevels>(FinishedLevelsSaveName) ?? new FinishedLevels(LevelsCount);

        if (finishedLevels.Length != LevelsCount)
        {
            var levels = new FinishedLevels(LevelsCount);

            var count = Mathf.Min(levels.Length, finishedLevels.Length);

            for (int i = 0; i < count; i++)
            {
                levels.value[i] = finishedLevels.value[i];
            }

            finishedLevels = levels;
        }
    }

    private void InitLevelsPanel()
    {
        LoadButton().Init(1, "Tutorial", finishedLevels.value[0]);

        for (int sceneIndex = scenesToSkip; sceneIndex < SceneManager.sceneCountInBuildSettings; sceneIndex++)
        {
            var levelIndex = sceneIndex - scenesToSkip + 1;
            var isFinished = finishedLevels.value[levelIndex];
            LoadButton().Init(sceneIndex, $"Level {levelIndex}", isFinished);
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

        for (int i = 0; i < levelButtons.Count; i++)
        {
            if (finishedLevels.value[i])
                levelButtons[i].SetFinished();
        }
    }

    public void HideLevelsPanel()
    {
        levelsPanel.SetActive(false);
    }
}

[System.Serializable]
public class LevelsSaveData
{
    public int lastOpenLevel;
}

[System.Serializable]
public class FinishedLevels
{
    public BitArray value;

    public int Length => value.Length;

    public FinishedLevels(int levelsCount)
    {
        value = new BitArray(levelsCount, false);
    }
}