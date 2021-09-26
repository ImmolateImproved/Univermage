using UnityEngine;
using System;

public class LivingEntity : MonoBehaviour
{
    private Animator animator;
    private PlayerInput playerInput;
    private SpellController spellController;

    public static event Action OnDeath;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spellController = GetComponent<SpellController>();
        playerInput = GetComponent<PlayerInput>();
    }

    public void ResetState()
    {
        playerInput.EnableGameplayInput();
        animator.SetTrigger("Restart");
    }

    public void Death()
    {
        OnDeath();

        spellController.ResetSpells();
        animator.SetTrigger("Death");
        playerInput.DisableGameplayInput();
    }
}