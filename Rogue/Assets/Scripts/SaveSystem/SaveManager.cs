using UnityEngine;

public class SaveManager : MonoBehaviour
{
    static SaveData startLevelSave;

    static int savesCount = 5;

    void Start()
    {
        SaveSystemInit();
        startLevelSave = SaveSystem.Save();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            LoadFromFile();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            LoadLastSave();
        }
    }

    void SaveSystemInit()
    {
        var player = FindObjectOfType<PlayerSaveable>();

        var saveableTags = FindObjectsOfType<Saveable>();
        var saveables = new ISaveable[saveableTags.Length];

        for (int i = 0; i < saveables.Length; i++)
        {
            saveables[i] = saveableTags[i].GetComponent<ISaveable>();
        }

        SaveSystem.Init(player, saveables);
    }

    public void Save()
    {
        if (savesCount == 0)
        {
            UIManager.inst.ShowText($"Save faild.\n Saves count: {savesCount}");
            return;
        }

        var save = SaveSystem.Save();

        SaveSystem.SaveToFile(save);

        savesCount--;

        UIManager.inst.ShowText($"Save succeeded.\n Saves count: {savesCount}");
    }

    public void LoadLastSave()
    {
        SaveSystem.LoadLastSave();
    }

    public void LoadFromFile()
    {
        SaveSystem.LoadFromFile();
    }

    public static void AddSaves()
    {
        savesCount++;
        UIManager.inst.ShowText($"Saves count: {savesCount}");
    }

    public static void RestartLevel()
    {
        SaveSystem.Load(startLevelSave);
    }
}