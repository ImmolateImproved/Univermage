using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    bool onLadder, onJetPack;

    [SerializeField] float jetPackSpeed;
    [SerializeField] float ladderSpeed;

    void OnJetPack(bool _onJetPack)
    {
        onJetPack = _onJetPack;
    }

    void OnLadder(bool _onLadder)
    {
        onLadder = _onLadder;
    }

    public float GetDirection(float yInput)
    {
        if (onJetPack)
        {
            return jetPackSpeed * yInput;
        }
        else
        if (onLadder)
        {
            return ladderSpeed * yInput;
        }
        else
        {
            return -10;
        }
    }

    void OnEnable()
    {
        Jetpack.OnJetpack += OnJetPack;
    }

    void OnDisable()
    {
        Jetpack.OnJetpack -= OnJetPack;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            OnLadder(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            OnLadder(false);
        }
    }
}