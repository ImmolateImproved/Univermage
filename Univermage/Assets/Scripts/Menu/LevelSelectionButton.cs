using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSelectionButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private TextMeshProUGUI levelText;

    [SerializeField]
    private GameObject finishedCheck;

    private int levelIndex;

    public static event Action<int> OnClick = delegate { };

    public void Init(int levelIndex, string levelName, bool isFinished)
    {
        this.levelIndex = levelIndex;
        levelText.text = levelName;
        finishedCheck.SetActive(isFinished);
    }

    public void SetFinished()
    {
        finishedCheck.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick(levelIndex);
    }
}