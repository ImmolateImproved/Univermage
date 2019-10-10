using UnityEngine;

public class FloorBreakerFX : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Active()
    {
        anim.SetTrigger("Exp");
    }

    //Used in animation event
    public void End()
    {
        gameObject.SetActive(false);
    }
}