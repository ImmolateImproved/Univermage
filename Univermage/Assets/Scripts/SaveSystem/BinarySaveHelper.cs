using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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