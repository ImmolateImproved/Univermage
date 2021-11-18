using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Input/InputEnabler")]
public class InputEnabler : ScriptableObject
{
    [SerializeField]
    private InputManager inputManager;

    public Actions[] actions;

    public void EnableInput(bool enable)
    {
        inputManager.EnableInput(this, enable);
    }
}