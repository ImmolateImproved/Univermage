using MEC;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellsUI : MonoBehaviour
{
    [SerializeField]
    private Transform spellEffectHolder;

    [SerializeField]
    private Transform spellEffectPrefab;

    private Queue<Transform> spellEffectUIs = new Queue<Transform>();

    private PoolerBase<Transform> spellEffectPool;

    [SerializeField]
    private Image currentSpell;

    private void Awake()
    {
        Timing.KillCoroutines(CoroutineTags.UI);
        spellEffectPool = new PoolerBase<Transform>();
        spellEffectPool.InitPool(spellEffectPrefab, 3, 10);
    }

    public void ResetState()
    {
        Timing.KillCoroutines(CoroutineTags.UI);
        while (spellEffectUIs.Count > 0)
        {
            var spellEffect = spellEffectUIs.Dequeue();
            spellEffectPool.Release(spellEffect);
        }
    }

    private void SpellView_OnSpellEffect(Sprite spellIcon, float duration)
    {
        var spellEffect = spellEffectPool.Get();
        spellEffect.SetParent(spellEffectHolder);
        spellEffect.GetChild(0).GetComponent<Image>().sprite = spellIcon;

        spellEffectUIs.Enqueue(spellEffect);
        Timing.RunCoroutine(Timer(duration, spellEffect.transform), CoroutineTags.UI);
    }

    private IEnumerator<float> Timer(float duration, Transform spellEffect)
    {
        var timer = duration;

        var timerText = spellEffect.GetChild(1).GetComponent<Image>();

        while (timer > 0)
        {
            timerText.fillAmount = timer / duration;
            timer -= Time.deltaTime;

            yield return Timing.WaitForOneFrame;
        }

        spellEffectUIs.Dequeue();
        spellEffectPool.Release(spellEffect);
    }

    public void OnSetSpell(Spell spell)
    {
        var spellIsNotNull = spell?.SpellIcon != null;

        currentSpell.enabled = spellIsNotNull;

        if (spellIsNotNull)
            currentSpell.sprite = spell.SpellIcon;
    }

    public void OnSpellUsed()
    {
        currentSpell.enabled = false;
    }

    private void OnEnable()
    {
        SpellCaster.OnSetSpell += OnSetSpell;
        SpellCaster.OnSpellUsed += OnSpellUsed;

        Spell.OnEffectCast += SpellView_OnSpellEffect;
        GameplaySaveSystem.OnLoad += ResetState;
        LivingEntity.OnDeath += ResetState;
    }

    private void OnDisable()
    {
        SpellCaster.OnSetSpell -= OnSetSpell;
        SpellCaster.OnSpellUsed -= OnSpellUsed;

        Spell.OnEffectCast -= SpellView_OnSpellEffect;
        GameplaySaveSystem.OnLoad -= ResetState;
        LivingEntity.OnDeath -= ResetState;
    }
}