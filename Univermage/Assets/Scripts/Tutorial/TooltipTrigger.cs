using UnityEngine;
using UnityEngine.Events;

public class TooltipTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<TooltipTrigger> onTrigger;

    [SerializeField]
    private Tooltip[] tooltips;

    private int currentTooltip;

    private LayerMask playerLayer;

    private void Awake()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }

    public Tooltip NextTooltip()
    {
        if (currentTooltip >= tooltips.Length)
            return null;

        var tooltip = tooltips[currentTooltip];
        currentTooltip++;

        return tooltip;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer != playerLayer)
            return;

        onTrigger.Invoke(this);

        gameObject.SetActive(false);
    }
}