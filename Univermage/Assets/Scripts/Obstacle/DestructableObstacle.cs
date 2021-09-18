using UnityEngine;

[RequireComponent(typeof(Saveable))]
public class DestructableObstacle : MonoBehaviour, ISaveable
{
    void ISaveable.Load(bool state)
    {
        gameObject.SetActive(state);
    }

    bool ISaveable.Save()
    {
        return gameObject.activeSelf;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}