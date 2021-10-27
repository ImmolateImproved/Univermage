using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSelectionButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private TextMeshProUGUI levelText;

    private int levelIndex;

    public static event Action<int> OnClick = delegate { };

    public void Init(int levelIndex, string levelName)
    {
        this.levelIndex = levelIndex;
        levelText.text = $"Level {levelName}";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick(levelIndex);
    }
}