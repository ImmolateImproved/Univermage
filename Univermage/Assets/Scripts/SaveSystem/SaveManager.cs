using MEC;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField]
    private int savesCount = 5;

    private bool canSave;

    private SaveData lastSave;

    public static event Action<string> SaveEvent = delegate { };

    private void Start()
    {
        canSave = true;
        lastSave = null;
    }

    public void TrySave()
    {
        if (!canSave)
        {
            SaveEvent($"Save faild.\n Reason: effect");
            return;
        }

        if (savesCount == 0)
        {
            SaveEvent($"Save faild.\n Saves count: {savesCount}");
            return;
        }

        QuiqSave();

        savesCount--;

        SaveEvent($"Save succeeded.\n Saves count: {savesCount}");
    }

    private void QuiqSave()
    {
        var saveIdentifier = new SaveIdentifier(SaveNames.LastSave);

        lastSave = SaveSystem.Save(saveIdentifier);
    }

    public void LoadLastSave()
    {
        var saveIdentifier = new SaveIdentifier(SaveNames.LastSave);

        SaveSystem.Load(saveIdentifier, lastSave);
    }

    public void AddSaves()
    {
        savesCount++;
        SaveEvent($"Saves count: {savesCount}");
    }

    private IEnumerator<float> WaitEndEffect(float effecDuration)
    {
        canSave = false;

        yield return Timing.WaitForSeconds(effecDuration);

        canSave = true;
    }

    private void Spell_OnEffectCast(Sprite spell, float effecDuration)
    {
        Timing.RunCoroutine(WaitEndEffect(effecDuration));
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