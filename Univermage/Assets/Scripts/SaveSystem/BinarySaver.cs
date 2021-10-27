using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class BinarySaver
{
    public static void SaveToFile<T>(T saveableData, string saveName)
    {
        var formatter = new BinaryFormatter();
        var stream = new FileStream(GetPathFromName(saveName), FileMode.Create);

        formatter.Serialize(stream, saveableData);
        stream.Close();
    }

    public static T LoadFromFile<T>(string saveName) where T : class
    {
        var path = GetPathFromName(saveName);

        if (File.Exists(path))
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);

            var save = formatter.Deserialize(stream) as T;

            stream.Close();

            return save;
        }

        Debug.Log("Save file not found");

        return null;
    }

    private static string GetPathFromName(string saveName)
    {
        return Application.persistentDataPath + $"/{saveName}.save";
    }
}