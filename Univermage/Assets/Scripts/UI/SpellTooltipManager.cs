using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;
using System.Collections.Generic;
using MEC;
using TMPro;

public class SpellTooltipManager : MonoBehaviour
{
    [SerializeField]
    private GameObject spellTooltipHolder;

    [SerializeField]
    private TextMeshProUGUI spellNameText;

    [SerializeField]
    private TextMeshProUGUI spellDescriptionText;

    [SerializeField]
    private VideoPlayer videoPlayer;

    [SerializeField]
    private RenderTexture videoTexture;

    private Spell currentSpell;

    [SerializeField]
    private LayerMask spellCsrollMask;

    private Keyboard keyboard;

    private void Start()
    {
        videoTexture.Release();
        keyboard = Keyboard.current;
    }

    private void Update()
    {
        if (keyboard.altKey.isPressed)
        {
            var mousePos = Mouse.current.position.ReadValue();

            var worldPoint = Camera.main.ScreenToWorldPoint(mousePos);

            var spellScrollCollider = Physics2D.OverlapPoint(worldPoint, spellCsrollMask);

            var spell = currentSpell;

            if (spellScrollCollider)
            {
                if (spellScrollCollider.TryGetComponent<SpellScroll>(out var spellScroll))
                {
                    spell = spellScroll.spell;
                }
            }

            Timing.RunCoroutine(ShowTooltip(spell));
        }
        if (keyboard.altKey.wasReleasedThisFrame)
        {
            HideToolTip();
        }
    }

    private IEnumerator<float> ShowTooltip(Spell spell)
    {
        if (spell == null || spellTooltipHolder.activeSelf)
        {
            yield break;
        }

        Cursor.visible = false;

        spellNameText.text = spell.spellName;
        spellDescriptionText.text = spell.description;

        videoPlayer.time = 0;
        videoPlayer.clip = spell.videoClip;
        videoPlayer.Play();

        yield return Timing.WaitForSeconds(0.1f);

        if (keyboard.altKey.isPressed)
            spellTooltipHolder.SetActive(true);
    }

    private void HideToolTip()
    {
        spellTooltipHolder.SetActive(false);
        videoTexture.Release();
        Cursor.visible = true;
        videoPlayer.time = 0;
        videoPlayer.Stop();
    }

    private void SpellCaster_OnSetSpell(Spell spell)
    {
        currentSpell = spell;
    }

    private void SpellCaster_OnSpellUsed()
    {
        currentSpell = null;
    }

    private void OnEnable()
    {
        SpellCaster.OnSetSpell += SpellCaster_OnSetSpell;
        SpellCaster.OnSpellUsed += SpellCaster_OnSpellUsed;
    }

    private void OnDisable()
    {
        SpellCaster.OnSetSpell -= SpellCaster_OnSetSpell;
        SpellCaster.OnSpellUsed -= SpellCaster_OnSpellUsed;
    }
}