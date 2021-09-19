using UnityEngine;

public class SaveableHolder : MonoBehaviour
{
    public PlayerSaveable player;

    public SwitchListener nextLevelLoader;

    public Saveable[] saveables;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        foreach (var item in saveables)
        {
            item.Init();
        }

        SaveSystem.saveableHolder = this;
    }

    public void Load(in SaveData save)
    {
        player.Load(save.playerData);

        nextLevelLoader.Load(save.activatedSwitchesCount);

        for (int i = 0; i < saveables.Length; i++)
        {
            saveables[i].Load(save.saveableStates[i]);
        }
    }

    public void FindSaveables()
    {
        player = FindObjectOfType<PlayerSaveable>();

        nextLevelLoader = FindObjectOfType<EndLevel>().GetComponent<SwitchListener>();

        saveables = FindObjectsOfType<Saveable>();
    }
}