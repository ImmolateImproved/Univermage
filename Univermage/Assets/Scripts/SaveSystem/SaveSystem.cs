using System.Collections.Generic;
using UnityEngine;

public struct PlayerData
{
    public Vector2 position;
    public bool facingRight;
    public Spell currentSpell;
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
        var binarySave = new BinarySaveData(player, playerData, saveableDatas);

        return binarySave;
    }

    public static SaveData FromBinarySave(BinarySaveData binarySave, PlayerSaveable player, ISaveable[] _saveables)
    {
        var save = new SaveData();

        save.playerData = player.GetPlayerDataFormBinary(binarySave.playerDataBinary);
        save.saveableDatas = new List<SaveablesData>(binarySave.binarySaveableDatas.saveableIndices.Length);

        for (int i = 0; i < binarySave.binarySaveableDatas.saveableIndices.Length; i++)
        {
            var saveableData = new SaveablesData
            {
                saveable = _saveables[binarySave.binarySaveableDatas.saveableIndices[i]],
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

public class SaveSystem
{
    private PlayerSaveable player;

    private ISaveable[] saveables;

    private SaveData LastSave;

    public void Init(PlayerSaveable _player, ISaveable[] _saveables)
    {
        player = _player;

        saveables = _saveables;
    }

    public SaveData Save()
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

    public void SaveToFile(SaveData save)
    {
        var binarySave = save.ToBinarySave(player);
        BinaryFormatterSaveSystem.Save(binarySave);
    }

    public void Load(SaveData save)
    {
        player.Load(save.playerData);

        foreach (var item in save.saveableDatas)
        {
            item.saveable.Load(item.state);
        }
    }

    public void LoadFromFile()
    {
        var binarySave = BinaryFormatterSaveSystem.GetSaveDataFromFile();
        var save = SaveData.FromBinarySave(binarySave, player, saveables);

        Load(save);
    }

    public void LoadLastSave()
    {
        Load(LastSave);
    }
}