using UnityEngine;

public class SaveSystem
{
    private readonly PlayerSaveable player;

    private readonly SwitchListener nextLevelLoader;

    private readonly Saveable[] saveables;

    public SaveSystem(PlayerSaveable player, SwitchListener nextLevelLoader, Saveable[] saveables)
    {
        this.player = player;
        this.nextLevelLoader = nextLevelLoader;
        this.saveables = saveables;
    }

    public SaveData Save(string saveName)
    {
        var save = new SaveData(player, nextLevelLoader, saveables);

        SaveToFile(save, saveName);

        return save;
    }

    private void SaveToFile(SaveData save, string saveName)
    {
        BinarySaveHelper.Save(save, saveName);
    }

    public void Load(SaveData save, string saveName)
    {
        if (save == null)
        {
            save = LoadFromFile(saveName);
        }

        player.Load(save.playerData);

        nextLevelLoader.Load(save.activatedSwitchesCount);

        for (int i = 0; i < saveables.Length; i++)
        {
            saveables[i].Load(save.saveableStates[i]);
        }
    }

    private SaveData LoadFromFile(string saveName)
    {
        var save = BinarySaveHelper.GetSaveDataFromFile(saveName);

        return save;
    }
}