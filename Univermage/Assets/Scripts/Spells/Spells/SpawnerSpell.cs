using UnityEngine;
using MEC;
using System.Collections.Generic;

public abstract class SpawnerSpell : Spell
{
    [SerializeField]
    private GameObject spellObjectPrefab;

    private Queue<GameObject> allSpellObjects = new Queue<GameObject>();

    protected Transform spawnPoint;

    [SerializeField]
    protected float duration;

    public override void Init(SpellController spellController)
    {
        base.Init(spellController);
        spawnPoint = spellController.spawnPointMid;
    }

    public override void Cast()
    {
        OnEffectCastInvoke(SpellIcon, duration);

        Timing.RunCoroutine(Wait(), CoroutineTags.GAMEPLAY);
    }

    public override void ResetSpell()
    {
        for (int i = 0; i < allSpellObjects.Count; i++)
        {
            GameObject.Destroy(allSpellObjects.Dequeue());
        }
    }

    public virtual void InitSpellObject(GameObject spellObjcet)
    {

    }

    public virtual void ActionOnEnd(GameObject spellObject)
    {

    }

    private IEnumerator<float> Wait()
    {
        var spellObject = GameObject.Instantiate(spellObjectPrefab);
        allSpellObjects.Enqueue(spellObject);

        spellObject.transform.position = spawnPoint.position;

        InitSpellObject(spellObject);

        yield return Timing.WaitForSeconds(duration);

        ActionOnEnd(spellObject);

        allSpellObjects.Dequeue();
        GameObject.Destroy(spellObject);
    }
}