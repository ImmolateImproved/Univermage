using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement
{
    private HashSet<object> verticalMovementTriggers = new HashSet<object>();

    public virtual bool IsVerticalMovement => verticalMovementTriggers.Count > 0;

    public void SetVerticalMovement(object trigger, bool onOf)
    {
        if (onOf)
        {
            verticalMovementTriggers.Add(trigger);
        }
        else
        {
            verticalMovementTriggers.Remove(trigger);
        }
    }

    public static implicit operator bool(VerticalMovement verticalMovement)
    {
        return verticalMovement.IsVerticalMovement;
    }
}