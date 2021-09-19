using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveNames
{
    public const string LastSave = "LevelStart";
}

public struct SaveIdentifier
{
    private readonly string saveName;

    public SaveIdentifier(string saveName)
    {
        this.saveName = saveName;
    }

    public static implicit operator string(SaveIdentifier saveIdentifier)
    {
        return saveIdentifier.saveName + SceneManager.GetActiveScene().buildIndex;
    }
}

public static class SaveSystem
{
    public static SaveableHolder saveableHolder;

    public static event Action OnLoad = delegate { };

    public static SaveData Save(SaveIdentifier saveIdentifier)
    {
        var save = new SaveData(saveableHolder);

        BinarySaveHelper.SaveToFile(save, saveIdentifier);

        return save;
    }

    public static void Load(SaveIdentifier saveIdentifier, SaveData save = null)
    {
        if (save == null)
        {
            save = BinarySaveHelper.LoadFromFile(saveIdentifier);
        }

        saveableHolder.Load(save);

        OnLoad();
    }
}