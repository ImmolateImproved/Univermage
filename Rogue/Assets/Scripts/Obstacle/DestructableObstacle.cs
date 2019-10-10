using UnityEngine;

[RequireComponent(typeof(Saveable))]
public class DestructableObstacle : MonoBehaviour, ISaveable
{
    void ISaveable.Load(bool state)
    {
        gameObject.SetActive(state);
    }

    SaveablesData ISaveable.Save()
    {
        var data = new SaveablesData { saveable = this, state = gameObject.activeSelf };
        return data;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}