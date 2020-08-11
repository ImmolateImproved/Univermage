using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public struct BinaryPlayerData
{
    public float[] position;
    public bool facingRight;
    public int itemIndex;
}

[System.Serializable]
public struct BinarySaveableData
{
    public int[] saveableHash;
    public bool[] saveableState;
}

[System.Serializable]
public class BinarySaveData
{
    public BinaryPlayerData playerDataBinary;
    public BinarySaveableData binarySaveableDatas;
}

public static class BinaryFormatterSaveSystem
{
    static readonly string filePath = Application.persistentDataPath + "/Save.save";

    public static void Save(BinarySaveData saveableData)
    {
        var formatter = new BinaryFormatter();
        var stream = new FileStream(filePath, FileMode.Create);

        formatter.Serialize(stream, saveableData);
        stream.Close();
    }

    public static BinarySaveData GetSaveDataFromFile()
    {
        if (File.Exists(filePath))
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(filePath, FileMode.Open);

            var save = formatter.Deserialize(stream) as BinarySaveData;

            stream.Close();

            return save;
        }
        else
        {
            Debug.Log("Save file not found");

            return null;
        }
    }
}