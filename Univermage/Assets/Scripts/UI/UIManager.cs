using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MEC;

public class UIManager : MonoBehaviour
{
    public static UIManager inst;

    [SerializeField]
    private Image currentSpell;

    [SerializeField]
    private Text mesasgeText;

    private CoroutineHandle textCoroutineHandle;

    private void Awake()
    {
        inst = this;
    }

    public void ShowText(string value, float duration = 2)
    {
        mesasgeText.text = value;

        Timing.KillCoroutines(textCoroutineHandle);
        textCoroutineHandle = Timing.RunCoroutine(ShowAndHideText(duration));
    }

    private void ShowSaveEventText(string eventText)
    {
        ShowText(eventText, 2);
    }

    private IEnumerator<float> ShowAndHideText(float duration)
    {
        mesasgeText.enabled = true;

        var defaultColor = mesasgeText.color;
        defaultColor.a = 1;
        mesasgeText.color = defaultColor;

        while (mesasgeText.color.a > 0.1f)
        {
            var color = mesasgeText.color;
            color.a -= Time.deltaTime / duration;
            mesasgeText.color = color;

            yield return Timing.WaitForOneFrame;
        }

        mesasgeText.enabled = false;
    }

    public void OnSetSpell(Spell spell)
    {
        var spellIsNotNull = spell?.SpellUi != null;

        currentSpell.enabled = spellIsNotNull;

        if (spellIsNotNull)
            currentSpell.sprite = spell.SpellUi;
    }

    public void OnSpellUsed()
    {
        currentSpell.enabled = false;
    }

    private void OnEnable()
    {
        SpellCaster.OnSetSpell += OnSetSpell;
        SpellCaster.OnSpellUsed += OnSpellUsed;

        SaveManager.OnSave += ShowSaveEventText;
    }

    private void OnDisable()
    {
        SpellCaster.OnSetSpell -= OnSetSpell;
        SpellCaster.OnSpellUsed -= OnSpellUsed;

        SaveManager.OnSave -= ShowSaveEventText;
    }
}