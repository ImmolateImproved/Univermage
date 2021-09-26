using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct PlayerSaveData
{
    public float[] position;
    public int direction;
    public int spellIndex;
}

[System.Serializable]
public class SaveData
{
    public PlayerSaveData playerData;
    public int activatedSwitchesCount;
    public bool[] saveableStates;

    public int levelIndex;

    public SaveData(SaveableHolder saveableHolder)
    {
        this.levelIndex = SceneManager.GetActiveScene().buildIndex;

        playerData = saveableHolder.player.Save();

        this.activatedSwitchesCount = saveableHolder.nextLevelLoader.Save();

        saveableStates = new bool[saveableHolder.saveables.Length];

        for (int i = 0; i < saveableHolder.saveables.Length; i++)
        {
            this.saveableStates[i] = saveableHolder.saveables[i].Save();
        }
    }
}

public static class BinarySaveHelper
{
    public static void SaveToFile(SaveData saveableData, string saveName)
    {
        var formatter = new BinaryFormatter();
        var stream = new FileStream(GetPathFromName(saveName), FileMode.Create);

        formatter.Serialize(stream, saveableData);
        stream.Close();
    }

    public static SaveData LoadFromFile(string saveName)
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