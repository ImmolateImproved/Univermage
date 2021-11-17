using MEC;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameplaySaveSystem))]
public class GameplaySaveManager : Singleton<GameplaySaveManager>
{
    private GameplaySaveSystem saveSystem;

    private bool canSave;

    private CoroutineHandle waitEffectHandle;

    private SaveData lastSave;

    public static event Action<string> SaveManagerEvent = delegate { };

    private const string saveSuccessText = "Cохранение";

    private const string saveFailedText = "Невозможно cохраниться пока действует заклинание";

    private const string loadSuccess = "Загрузка";
    private const string loadFailText = "Вы еще не cохранялись на этом уровне";

    public override void Awake()
    {
        base.Awake();
        saveSystem = GetComponent<GameplaySaveSystem>();
    }

    private void Start()
    {
        canSave = true;
        lastSave = null;
    }

    public void TrySave()
    {
        if (!canSave)
        {
            SaveManagerEvent(saveFailedText);
            return;
        }

        Save();

        SaveManagerEvent(saveSuccessText);
    }

    public void Save()
    {
        var saveIdentifier = new SaveIdentifier(SaveNames.LastSave);

        lastSave = saveSystem.Save(saveIdentifier);
    }

    public void LoadLastSave()
    {
        var saveIdentifier = new SaveIdentifier(SaveNames.LastSave);

        var loadResult = saveSystem.Load(saveIdentifier, lastSave);

        SaveManagerEvent(loadResult ? loadSuccess : loadFailText);
    }

    private IEnumerator<float> WaitEndEffect(float effecDuration)
    {
        canSave = false;

        yield return Timing.WaitForSeconds(effecDuration);

        canSave = true;
    }

    private void Spell_OnEffectCast(Sprite spell, float effecDuration)
    {
        Timing.KillCoroutines(waitEffectHandle);
        waitEffectHandle = Timing.RunCoroutine(WaitEndEffect(effecDuration));
    }

    private void OnEnable()
    {
        Spell.OnEffectCast += Spell_OnEffectCast;
    }

    private void OnDisable()
    {
        Spell.OnEffectCast -= Spell_OnEffectCast;
    }
}