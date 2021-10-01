using UnityEngine;

[RequireComponent(typeof(Saveable))]
public class DestructableObstacle : MonoBehaviour, ISaveable
{
    public void Load(bool state)
    {
        gameObject.SetActive(state);
    }

    public bool Save()
    {
        return gameObject.activeSelf;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}