using System;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField]
    private PlayerSaveable playerSaveable;

    [SerializeField]
    private Saveable[] saveableTags;

    private ISaveable[] saveables;

    private SaveSystem saveSystem;

    private SaveData startLevelSave;

    private int savesCount = 5;

    public static event Action<string> SaveEvent = delegate { };

    private void Start()
    {
        Init();

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

    private void Init()
    {
        saveSystem = new SaveSystem();

        saveables = new ISaveable[saveableTags.Length];

        for (int i = 0; i < saveables.Length; i++)
        {
            saveables[i] = saveableTags[i].GetComponent<ISaveable>();
        }

        saveSystem.Init(playerSaveable, saveables);
    }

    public void FindSaveables()
    {
        playerSaveable = FindObjectOfType<PlayerSaveable>();

        saveableTags = FindObjectsOfType<Saveable>();
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