using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MEC;

public class UIManager : MonoBehaviour
{
    public static UIManager inst;

    [SerializeField]
    Image currentTool;

    [SerializeField]
    Text mesasgeText;

    CoroutineHandle textCoroutineHandle;

    void Awake()
    {
        inst = this;
    }

    public void ShowText(string value, float duration = 2)
    {
        mesasgeText.text = value;

        Timing.KillCoroutines(textCoroutineHandle);
        textCoroutineHandle = Timing.RunCoroutine(ShowAndHideText(duration));
    }

    IEnumerator<float> ShowAndHideText(float duration)
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

    public void OnSetItem(Item toolSprite)
    {
        var itemIsNotNull = toolSprite != null;

        currentTool.enabled = itemIsNotNull;

        if (itemIsNotNull)
            currentTool.sprite = toolSprite.Sprite;
    }

    public void OnItemUsed()
    {
        currentTool.enabled = false;
    }

    void OnEnable()
    {
        ItemManager.OnSetItem += OnSetItem;
        ItemManager.OnItemUsed += OnItemUsed;
    }

    void OnDisable()
    {
        ItemManager.OnSetItem -= OnSetItem;
        ItemManager.OnItemUsed -= OnItemUsed;
    }
}