using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/InterpolatedStringParameters/KeysBindingsParameters")]
public class KeysBindingsParameters : InterpolatedStringParameters
{
    public KeyBindingsNames[] keyBindingsNames;

    public override string[] GetInterpolatedStringParameters()
    {
        var movementKeys = new string[keyBindingsNames.Length];

        var keyBindings = KeyRebinder.keyBindings;

        for (int i = 0; i < keyBindingsNames.Length; i++)
        {
            movementKeys[i] = keyBindings[keyBindingsNames[i].ToString()];
        }

        return movementKeys;
    }
}