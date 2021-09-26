using UnityEngine;
using System;

public class LivingEntity : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;

    private Animator animator;
    private SpellController spellController;

    public static event Action OnDeath;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spellController = GetComponent<SpellController>();
    }

    public void ResetState()
    {
        inputManager.EnableGameplayInput();
        animator.SetTrigger("Restart");
    }

    public void Death()
    {
        OnDeath();

        spellController.ResetSpells();
        animator.SetTrigger("Death");
        inputManager.DisableGameplayInput();
    }
}