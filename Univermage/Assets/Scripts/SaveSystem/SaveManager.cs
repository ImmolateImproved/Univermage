using MEC;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveSystem))]
public class SaveManager : Singleton<SaveManager>
{
    private SaveSystem saveSystem;

    [SerializeField]
    private int savesCount = 5;

    private bool canSave;

    private CoroutineHandle waitEffectHandle;

    private SaveData lastSave;

    public static event Action<string> SaveEvent = delegate { };

    private const string saveFailedText = "Невозможно сохраниться сейчас.\n Причина: ";
    private Dictionary<int, string> saveFailedCauses;

    public override void Awake()
    {
        base.Awake();
        saveSystem = GetComponent<SaveSystem>();
    }

    private void Start()
    {
        canSave = true;
        lastSave = null;

        saveFailedCauses = new Dictionary<int, string>(5)
        {
            [0] = saveFailedText + "Еффект",
            [1] = saveFailedText + "Недостаточно сохранений"
        };
    }

    public void TrySave()
    {
        if (!canSave)
        {
            SaveEvent(saveFailedCauses[0]);
            return;
        }

        if (savesCount == 0)
        {
            SaveEvent(saveFailedCauses[0]);
            return;
        }

        QuiqSave();

        savesCount--;

        SaveEvent($"Cохранение\nОсталось сохранений: {savesCount}");
    }

    public void TutorialSave()
    {
        QuiqSave();

        SaveEvent($"Cохранение");
    }

    private void QuiqSave()
    {
        var saveIdentifier = new SaveIdentifier(SaveNames.LastSave);

        lastSave = saveSystem.Save(saveIdentifier);
    }

    public void LoadLastSave()
    {
        var saveIdentifier = new SaveIdentifier(SaveNames.LastSave);

        saveSystem.Load(saveIdentifier, lastSave);
    }

    public void AddSaves()
    {
        savesCount++;
        SaveEvent($"Осталось сохранений: {savesCount}");
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