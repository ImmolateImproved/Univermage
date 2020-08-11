using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MEC;

public class UIManager : MonoBehaviour
{
    public static UIManager inst;

    [SerializeField]
    private Image currentTool;

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

    public void OnSetItem(Spell toolSprite)
    {
        var itemIsNotNull = toolSprite != null;

        currentTool.enabled = itemIsNotNull;

        //if (itemIsNotNull)
        //    currentTool.sprite = toolSprite.Sprite;
    }

    public void OnItemUsed()
    {
        currentTool.enabled = false;
    }

    private void OnEnable()
    {
        SpellCaster.OnSetSpell += OnSetItem;
        SpellCaster.OnSpellUsed += OnItemUsed;

        SaveManager.SaveEvent += ShowSaveEventText;
    }

    private void OnDisable()
    {
        SpellCaster.OnSetSpell -= OnSetItem;
        SpellCaster.OnSpellUsed -= OnItemUsed;
        SaveManager.SaveEvent -= ShowSaveEventText;
    }
}