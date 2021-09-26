using MEC;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellEffectUI : MonoBehaviour
{
    [SerializeField]
    private Transform spellEffectHolder;

    [SerializeField]
    private Transform spellEffectPrefab;

    private Queue<GameObject> spellEffectUIs = new Queue<GameObject>();

    private void Awake()
    {
        Timing.KillCoroutines(CoroutineTags.UI);
    }

    public void ResetState()
    {
        Timing.KillCoroutines(CoroutineTags.UI);
        while (spellEffectUIs.Count > 0)
        {
            var spellEffect = spellEffectUIs.Dequeue();
            Destroy(spellEffect);
        }
    }

    private void SpellView_OnSpellEffect(Sprite spellIcon, float duration)
    {
        var spellEffect = Instantiate(spellEffectPrefab, spellEffectHolder);
        spellEffect.GetChild(0).GetComponent<Image>().sprite = spellIcon;

        spellEffectUIs.Enqueue(spellEffect.gameObject);
        Timing.RunCoroutine(Timer(duration, spellEffect), CoroutineTags.UI);
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
        Destroy(spellEffect.gameObject);
    }

    private void OnEnable()
    {
        Spell.OnEffectCast += SpellView_OnSpellEffect;
        SaveSystem.OnLoad += ResetState;
    }

    private void OnDisable()
    {
        Spell.OnEffectCast -= SpellView_OnSpellEffect;
        SaveSystem.OnLoad -= ResetState;
    }
}