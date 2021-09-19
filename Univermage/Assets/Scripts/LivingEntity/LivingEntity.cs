using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    private Animator animator;
    private PlayerInput playerInput;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }

    public void ResetState()
    {
        playerInput.EnableGameplayInput();
        animator.SetTrigger("Restart");
    }

    public void Death()
    {
        UIManager.inst?.ShowDeathText();

        animator.SetTrigger("Death");
        playerInput.DisableGameplayInput();
    }
}