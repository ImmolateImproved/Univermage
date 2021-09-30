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

    private const string saveFailedText = "���������� ����������� ������.\n �������: ";
    private Dictionary<int, string> saveFailedCauses;

    private void Start()
    {
        canSave = true;
        lastSave = null;

        saveFailedCauses = new Dictionary<int, string>(5)
        {
            [0] = saveFailedText + "������",
            [1] = saveFailedText + "������������ ����������"
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

        SaveEvent($"C���������\n�������� ����������: {savesCount}");
    }

    public void TutorialSave()
    {
        QuiqSave();

        SaveEvent($"C���������");
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
        SaveEvent($"�������� ����������: {savesCount}");
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