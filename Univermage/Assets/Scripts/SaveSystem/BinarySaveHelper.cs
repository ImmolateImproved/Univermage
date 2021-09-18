using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public struct PlayerSaveData
{
    public float[] position;
    public bool facingRight;
    public int spellIndex;
}

[System.Serializable]
public class SaveData
{
    public PlayerSaveData playerData;
    public int activatedSwitchesCount;
    public bool[] saveableStates;

    public SaveData(PlayerSaveable playerSaveable, SwitchListener nextLevelLoader, Saveable[] saveables)
    {
        playerData = playerSaveable.Save();

        this.activatedSwitchesCount = nextLevelLoader.Save();

        saveableStates = new bool[saveables.Length];

        for (int i = 0; i < saveables.Length; i++)
        {
            this.saveableStates[i] = saveables[i].Save();
        }
    }
}

public static class BinarySaveHelper
{
    public static void Save(SaveData saveableData, string saveName)
    {
        var formatter = new BinaryFormatter();
        var stream = new FileStream(GetPathFromName(saveName), FileMode.Create);

        formatter.Serialize(stream, saveableData);
        stream.Close();
    }

    public static SaveData GetSaveDataFromFile(string saveName)
    {
        var path = GetPathFromName(saveName);

        if (File.Exists(path))
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);

            var save = formatter.Deserialize(stream) as SaveData;

            stream.Close();

            return save;
        }
        else
        {
            Debug.Log("Save file not found");

            return null;
        }
    }

    public static string GetPathFromName(string saveName)
    {
        return Application.persistentDataPath + $"/{saveName}.save";
    }
}