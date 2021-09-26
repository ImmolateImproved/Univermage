﻿using UnityEngine;
using MEC;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ScriptableObjects/Spells/AstralBody")]
public class AstralBody : Spell
{
    [SerializeField]
    private GameObject astralBodyPrefab;

    private Queue<GameObject> allAstralBodies = new Queue<GameObject>();

    [SerializeField]
    private float duration;

    private CoroutineHandle coroutineHandle;

    public override void Cast()
    {
        OnEffectCastInvoke(SpellIcon, duration);
        coroutineHandle = Timing.RunCoroutine(Wait(), CoroutineTags.GAMEPLAY);
    }

    public override void ResetSpell()
    {
        for (int i = 0; i < allAstralBodies.Count; i++)
        {
            GameObject.Destroy(allAstralBodies.Dequeue());
        }
    }

    private IEnumerator<float> Wait()
    {
        var astralBody = GameObject.Instantiate(astralBodyPrefab);
        allAstralBodies.Enqueue(astralBody);

        astralBody.transform.position = spellController.castPoint.position;
        astralBody.GetComponent<SpellPicker>().Init(spellController.GetComponent<SpellCaster>());

        var astralBodyMovement = astralBody.GetComponent<CharacterMovement>();
        astralBodyMovement.VerticalMovement = true;
        astralBodyMovement.GetComponent<Animator>().SetBool("Flight", true);
        Move(astralBodyMovement);

        yield return Timing.WaitForSeconds(duration);

        astralBodyMovement.GetComponent<Animator>().SetBool("Flight", false);

        allAstralBodies.Dequeue();
        GameObject.Destroy(astralBody);
    }

    private void Move(CharacterMovement movement)
    {
        var myDirection = spellController.GetComponent<CharacterDirection>();
        movement.transform.localScale = myDirection.transform.localScale;

        movement.SetMoveDirection(myDirection.Direction);
    }
}