using UnityEngine;
using UnityEngine.Events;

public class SwitchListener : MonoBehaviour
{
    public UnityEvent activateEvent;

    [SerializeField]
    private int switchToActivate;
    private int currentSwitchCount;

    public void AddSwitch()
    {
        currentSwitchCount++;
        TryActivate();
    }

    private void TryActivate()
    {
        if (currentSwitchCount >= switchToActivate)
            activateEvent.Invoke();
    }

    public int Save()
    {
        return currentSwitchCount;
    }

    public void Load(int activatedSwitchCount)
    {
        currentSwitchCount = activatedSwitchCount;
        TryActivate();
    }
}