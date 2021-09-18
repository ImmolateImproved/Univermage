using System;
using UnityEngine;

public static class SaveNames
{
    public const string LEVEL_START = "levelStart";
    public const string LAST_SAVE = "lastSave";
}

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField]
    private PlayerSaveable playerSaveable;

    [SerializeField]
    private SwitchListener nextLevelLoader;

    [SerializeField]
    private Saveable[] saveables;

    private SaveSystem saveSystem;

    private SaveData startLevelSave;

    private SaveData lastSave;

    [SerializeField]
    private int savesCount = 5;

    public static event Action<string> OnSave = delegate { };

    private void Start()
    {
        Init();

        startLevelSave = saveSystem.Save(SaveNames.LEVEL_START);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
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
        for (int i = 0; i < saveables.Length; i++)
        {
            saveables[i].Init();
        }
        saveSystem = new SaveSystem(playerSaveable, nextLevelLoader, saveables);
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
            OnSave($"Save faild.\n Saves count: {savesCount}");
            return;
        }

        lastSave = saveSystem.Save(SaveNames.LAST_SAVE);

        savesCount--;

        OnSave($"Save succeeded.\n Saves count: {savesCount}");
    }

    public void RestartLevel()
    {
        saveSystem.Load(startLevelSave, SaveNames.LEVEL_START);
    }

    public void LoadLastSave()
    {
        saveSystem.Load(lastSave, SaveNames.LAST_SAVE);
    }

    public void AddSaves()
    {
        savesCount++;
        OnSave($"Saves count: {savesCount}");
    }
}