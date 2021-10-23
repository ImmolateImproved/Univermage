using UnityEngine;

public class VerticalMovementTrigger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CharacterMovement>(out var characterMovement))
        {
            characterMovement.SetVerticalMovement(this, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CharacterMovement>(out var characterMovement))
        {
            characterMovement.SetVerticalMovement(this, false);
        }
    }
}