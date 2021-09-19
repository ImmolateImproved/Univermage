using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MEC;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image currentSpell;

    [SerializeField]
    private TextMeshProUGUI mesasgeText;

    [SerializeField]
    private GameObject deathTextHolder;

    private CoroutineHandle textCoroutineHandle;

    public void ShowDeathText()
    {
        deathTextHolder.SetActive( true);
    }

    public void HideDeathText()
    {
        deathTextHolder.SetActive(false);
    }

    public void ShowMessage(string value)
    {
        mesasgeText.text = value;
        mesasgeText.enabled = true;
    }

    public void HideMessage()
    {
        mesasgeText.enabled = false;
    }

    public void ShowMessage(string value, float duration = 2)
    {
        mesasgeText.text = value;

        Timing.KillCoroutines(textCoroutineHandle);
        textCoroutineHandle = Timing.RunCoroutine(ShowAndHideText(duration));
    }

    private void ShowSaveEventText(string eventText)
    {
        ShowMessage(eventText, 4);
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

    private void SaveSystem_OnLoad()
    {
        HideMessage();
        HideDeathText();
    }

    private void LivingEntity_OnDeath()
    {
        ShowDeathText();
    }

    private void OnEnable()
    {
        SpellCaster.OnSetSpell += OnSetSpell;
        SpellCaster.OnSpellUsed += OnSpellUsed;
        LivingEntity.OnDeath += LivingEntity_OnDeath; 

        SaveManager.SaveEvent += ShowSaveEventText;
        SaveSystem.OnLoad += SaveSystem_OnLoad;
    }

    private void OnDisable()
    {
        SpellCaster.OnSetSpell -= OnSetSpell;
        SpellCaster.OnSpellUsed -= OnSpellUsed;
        LivingEntity.OnDeath -= LivingEntity_OnDeath;

        SaveManager.SaveEvent -= ShowSaveEventText;
        SaveSystem.OnLoad -= SaveSystem_OnLoad;
    }
}