using System;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    private SaveSystem saveSystem;

    private SaveData startLevelSave;

    private int savesCount = 5;

    public static event Action<string> SaveEvent = delegate { };

    private void Start()
    {
        SaveSystemInit();
        startLevelSave = saveSystem.Save();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            LoadFromFile();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            LoadLastSave();
        }
    }

    public void SaveSystemInit()
    {
        saveSystem = new SaveSystem();

        var player = FindObjectOfType<PlayerSaveable>();

        var saveableTags = FindObjectsOfType<Saveable>();
        var saveables = new ISaveable[saveableTags.Length];

        for (int i = 0; i < saveables.Length; i++)
        {
            saveables[i] = saveableTags[i].GetComponent<ISaveable>();
        }

        saveSystem.Init(player, saveables);
    }

    public void Save()
    {
        if (savesCount == 0)
        {
            SaveEvent($"Save faild.\n Saves count: {savesCount}");
            return;
        }

        var save = saveSystem.Save();

        saveSystem.SaveToFile(save);

        savesCount--;

        SaveEvent($"Save succeeded.\n Saves count: {savesCount}");
    }

    public void LoadLastSave()
    {
        saveSystem.LoadLastSave();
    }

    public void LoadFromFile()
    {
        saveSystem.LoadFromFile();
    }

    public void AddSaves()
    {
        savesCount++;
        SaveEvent($"Saves count: {savesCount}");
    }

    public void RestartLevel()
    {
        saveSystem.Load(startLevelSave);
    }
}