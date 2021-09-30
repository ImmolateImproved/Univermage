using System;
using UnityEngine;

public class MovementAnimation : MonoBehaviour
{
    private Animator anim;
    private int moveAnimationHash;

    private CharacterMovement movement;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        movement = GetComponent<CharacterMovement>();
        moveAnimationHash = Animator.StringToHash("Speed");
    }

    private void Update()
    {
        anim.SetFloat(moveAnimationHash, Math.Abs(movement.Velocity.x));
    }
}