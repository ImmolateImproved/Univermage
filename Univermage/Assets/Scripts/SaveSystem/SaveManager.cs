using System;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField]
    private int savesCount = 5;

    private SaveData lastSave;

    public static event Action<string> SaveEvent = delegate { };

    private void Start()
    {
        lastSave = null;
    }

    public void TrySave()
    {
        if (savesCount == 0)
        {
            SaveEvent($"Save faild.\n Saves count: {savesCount}");
            return;
        }

        QuiqSave();

        savesCount--;

        SaveEvent($"Save succeeded.\n Saves count: {savesCount}");
    }

    private void QuiqSave()
    {
        var saveIdentifier = new SaveIdentifier(SaveNames.LastSave);

        lastSave = SaveSystem.Save(saveIdentifier);
    }

    public void LoadLastSave()
    {
        var saveIdentifier = new SaveIdentifier(SaveNames.LastSave);

        SaveSystem.Load(saveIdentifier, lastSave);
    }

    public void AddSaves()
    {
        savesCount++;
        SaveEvent($"Saves count: {savesCount}");
    }
}