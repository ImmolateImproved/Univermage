using UnityEngine;
using TMPro;
using DG.Tweening;

public class MessageTextManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform messageTextHolder;

    [SerializeField]
    private TextMeshProUGUI messageText;

    [SerializeField]
    private GameObject deathTextHolder;

    private Vector2 startPosition;

    [SerializeField]
    private Vector2 position;

    private Sequence sequence;

    private void Awake()
    {
        startPosition = messageTextHolder.anchoredPosition;
        DOTween.KillAll();
    }

    public void ShowDeathText()
    {
        deathTextHolder.SetActive(true);
    }

    public void HideDeathText()
    {
        deathTextHolder.SetActive(false);
    }

    public void ShowMessage(string value, float delay)
    {
        BuildSequence(delay);

        messageText.text = value;
        messageTextHolder.gameObject.SetActive(true);
    }

    public void ShowMessage(string value)
    {
        ShowMessage(value, 2);
    }

    public void HideMessage()
    {
        messageTextHolder.gameObject.SetActive(false);
    }

    private void ShowSaveEventText(string eventText)
    {
        ShowMessage(eventText);
    }

    private void BuildSequence(float delay)
    {
        sequence.Kill();
        sequence = DOTween.Sequence();

        sequence.Append(messageTextHolder.DOAnchorPos(position, 0.5f));
        sequence.AppendInterval(delay);
        sequence.Append(messageTextHolder.DOAnchorPos(startPosition, 0.5f));
        sequence.AppendCallback(() => HideMessage());
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
        LivingEntity.OnDeath += LivingEntity_OnDeath;

        SaveManager.SaveEvent += ShowSaveEventText;
        SaveSystem.OnLoad += SaveSystem_OnLoad;
    }

    private void OnDisable()
    {
        //sequence?.Kill();

        LivingEntity.OnDeath -= LivingEntity_OnDeath;

        SaveManager.SaveEvent -= ShowSaveEventText;
        SaveSystem.OnLoad -= SaveSystem_OnLoad;
    }
}