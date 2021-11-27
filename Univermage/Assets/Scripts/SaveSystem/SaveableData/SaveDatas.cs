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
    public bool[] saveables;

    public int levelIndex;
}

public static class SaveNames
{
    public const string LastSave = "Level";
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
        return saveIdentifier.saveName + SceneManager.GetActiveScene().name;
    }
}