using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, ISaveable
{
    private SpriteRenderer sr;

    [SerializeField]
    private Sprite defaultSprite;

    [SerializeField]
    private Sprite activeStateSprite;

    [SerializeField]
    private SwitchListener listener;

    private bool activate;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public bool Save()
    {
        return activate;
    }

    public void Load(bool data)
    {
        activate = data;

        if (activate)
        {
            sr.sprite = activeStateSprite;
        }
        else
        {
            sr.sprite = defaultSprite;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (activate) return;

        if (collision.CompareTag("Player"))
        {
            activate = true;

            sr.sprite = activeStateSprite;
            listener.AddSwitch();
        }
    }
}