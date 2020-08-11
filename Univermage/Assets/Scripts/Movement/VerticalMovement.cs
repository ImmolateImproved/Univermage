using UnityEngine;

public class VerticalMovement
{
    private bool onLadder, onJetPack;

    public void OnJetPack(bool _onJetPack)
    {
        onJetPack = _onJetPack;
    }

    public void OnLadder(bool _onLadder)
    {
        onLadder = _onLadder;
    }

    public float GetVelocity(float inputY)
    {
        return (onJetPack || onLadder) ? inputY : -10;
    }
}