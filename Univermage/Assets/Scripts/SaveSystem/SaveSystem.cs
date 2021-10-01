using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class SaveSystem : MonoBehaviour
{
    [SerializeField]
    private PlayerSaveable player;

    [SerializeField]
    private SwitchListener nextLevelLoader;

    [SerializeField]
    private Saveable[] saveables;

    public static event Action OnLoad = delegate { };

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        foreach (var saveable in saveables)
        {
            saveable.Init();
        }
    }

    private SaveData CostructSaveData()
    {
        var boolSaveables = saveables.Select(x => x.Save()).ToArray();

        var saveData = new SaveData
        {
            saveables = boolSaveables,
            activatedSwitchesCount = nextLevelLoader.Save(),
            playerData = player.Save(),

            levelIndex = SceneManager.GetActiveScene().buildIndex
        };

        return saveData;
    }

    public SaveData Save(SaveIdentifier saveIdentifier)
    {
        var save = CostructSaveData();

        BinarySaveHelper.SaveToFile(save, saveIdentifier);

        return save;
    }

    public void Load(SaveIdentifier saveIdentifier, SaveData save = null)
    {
        if (save == null)
        {
            save = BinarySaveHelper.LoadFromFile(saveIdentifier);
        }

        player.Load(save.playerData);

        nextLevelLoader.Load(save.activatedSwitchesCount);

        for (int i = 0; i < saveables.Length; i++)
        {
            saveables[i].Load(save.saveables[i]);
        }

        OnLoad();
    }

    public void FindSaveables()
    {
        player = FindObjectOfType<PlayerSaveable>(true);

        nextLevelLoader = FindObjectOfType<EndLevel>(true).GetComponent<SwitchListener>();

        saveables = FindObjectsOfType<Saveable>(true);
    }
}