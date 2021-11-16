using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RebindKeyButton : MonoBehaviour, IPointerClickHandler
{
    [field: SerializeField]
    public Actions action;

    [field: SerializeField]
    public TextMeshProUGUI buttonText { get; private set; }

    [field: SerializeField]
    public int CompositeIndex { get; private set; }

    public Image Image { get; private set; }

    public static event Action<RebindKeyButton> OnClick = delegate { };

    private void Awake()
    {
        Image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick(this);
    }
}