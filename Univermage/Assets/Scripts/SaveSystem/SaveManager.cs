using System;
using System.Collections.Generic;
using UnityEngine;

public static class SaveNames
{
    public const string LEVEL_START = "levelStart";
    public const string LAST_SAVE = "lastSave";
}

public class SaveManager : Singleton<SaveManager>
{
    private SaveSystem saveSystem;

    [SerializeField]
    private PlayerSaveable playerSaveable;

    [SerializeField]
    private SwitchListener nextLevelLoader;

    [SerializeField]
    private Saveable[] saveables;

    private Dictionary<string, SaveData> saves;

    [SerializeField]
    private int savesCount = 5;

    public static event Action<string> SaveEvent = delegate { };

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        foreach (var item in saveables)
        {
            item.Init();
        }

        saveSystem = new SaveSystem(playerSaveable, nextLevelLoader, saveables);

        saves = new Dictionary<string, SaveData>(2)
        {
            { SaveNames.LEVEL_START, saveSystem.Save(SaveNames.LEVEL_START) },
            { SaveNames.LAST_SAVE, null }
        };
    }

    public void FindSaveables()
    {
        playerSaveable = FindObjectOfType<PlayerSaveable>();

        nextLevelLoader = FindObjectOfType<EndLevel>().GetComponent<SwitchListener>();

        saveables = FindObjectsOfType<Saveable>();
    }

    public void Save()
    {
        if (savesCount == 0)
        {
            SaveEvent($"Save faild.\n Saves count: {savesCount}");
            return;
        }

        saves[SaveNames.LAST_SAVE] = saveSystem.Save(SaveNames.LAST_SAVE);

        savesCount--;

        SaveEvent($"Save succeeded.\n Saves count: {savesCount}");
    }

    public void RestartLevel()
    {
        saveSystem.Load(saves[SaveNames.LEVEL_START], SaveNames.LEVEL_START);
    }

    public void LoadLastSave()
    {
        saveSystem.Load(saves[SaveNames.LAST_SAVE], SaveNames.LAST_SAVE);
    }

    public void AddSaves()
    {
        savesCount++;
        SaveEvent($"Saves count: {savesCount}");
    }
}