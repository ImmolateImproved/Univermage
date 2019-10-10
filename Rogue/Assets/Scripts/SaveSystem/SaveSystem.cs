using System.Collections.Generic;
using UnityEngine;

public struct PlayerData
{
    public Vector2 position;
    public bool facingRight;
    public Item currentItem;
}

public struct SaveablesData
{
    public ISaveable saveable;
    public bool state;
}

public struct SaveData
{
    public PlayerData playerData;

    public List<SaveablesData> saveableDatas;

    public BinarySaveData ToBinarySave(PlayerSaveable player)
    {
        var binarySave = new BinarySaveData();

        binarySave.playerDataBinary = player.GetBinaryData(playerData);

        binarySave.binarySaveableDatas.saveableHash = new int[saveableDatas.Count];
        binarySave.binarySaveableDatas.saveableState = new bool[saveableDatas.Count];

        for (int i = 0; i < saveableDatas.Count; i++)
        {
            binarySave.binarySaveableDatas.saveableHash[i] = saveableDatas[i].saveable.GetHashCode();
            binarySave.binarySaveableDatas.saveableState[i] = saveableDatas[i].state;
        }

        return binarySave;
    }

    public static SaveData FromBinarySave(BinarySaveData binarySave, PlayerSaveable player, Dictionary<int, ISaveable> saveableHasMap)
    {
        var save = new SaveData();

        save.playerData = player.GetPlayerDataFormBinary(binarySave.playerDataBinary);
        save.saveableDatas = new List<SaveablesData>(binarySave.binarySaveableDatas.saveableHash.Length);

        for (int i = 0; i < binarySave.binarySaveableDatas.saveableHash.Length; i++)
        {
            var saveableData = new SaveablesData
            {
                saveable = saveableHasMap[binarySave.binarySaveableDatas.saveableHash[i]],
                state = binarySave.binarySaveableDatas.saveableState[i]
            };

            save.saveableDatas.Add(saveableData);
        }

        return save;
    }

    public static SaveData Default()
    {
        var save = new SaveData
        {
            playerData = new PlayerData(),
            saveableDatas = new List<SaveablesData>()
        };

        return save;
    }
}

public static class SaveSystem
{
    static PlayerSaveable player;

    static ISaveable[] saveables;

    static Dictionary<int, ISaveable> saveableHashMap = new Dictionary<int, ISaveable>();

    static SaveData LastSave;

    public static void Init(PlayerSaveable _player, ISaveable[] _saveables)
    {
        player = _player;

        saveables = _saveables;

        saveableHashMap.Clear();
        foreach (var item in saveables)
        {
            saveableHashMap.Add(item.GetHashCode(), item);
        }
    }

    public static SaveData Save()
    {
        var save = SaveData.Default();

        player.Save(ref save);

        foreach (var item in saveables)
        {
            save.saveableDatas.Add(item.Save());
        }

        LastSave = save;

        return save;
    }

    public static void SaveToFile(SaveData save)
    {
        var binarySave = save.ToBinarySave(player);
        BinaryFormatterSaveSystem.Save(binarySave);
    }

    public static void Load(SaveData save)
    {
        player.Load(save.playerData);

        foreach (var item in save.saveableDatas)
        {
            item.saveable.Load(item.state);
        }
    }

    public static void LoadFromFile()
    {
        var binarySave = BinaryFormatterSaveSystem.GetSaveDataFromFile();
        var save = SaveData.FromBinarySave(binarySave, player, saveableHashMap);

        Load(save);
    }

    public static void LoadLastSave()
    {
        Load(LastSave);
    }
}