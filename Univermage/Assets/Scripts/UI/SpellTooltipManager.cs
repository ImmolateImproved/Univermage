using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.Video;
using System.Collections.Generic;
using System.Collections;
using MEC;

public class SpellTooltipManager : MonoBehaviour
{
    [SerializeField]
    private GameObject spellTooltipHolder;

    [SerializeField]
    private VideoPlayer videoPlayer;

    [SerializeField]
    private RenderTexture videoTexture;

    [SerializeField]
    private TextMeshProUGUI descriptionText;

    [SerializeField]
    private LayerMask spellCsrollMask;

    private void Start()
    {
        videoTexture.Release();

        Timing.RunCoroutine(ShowTooltip());
    }

    private IEnumerator<float> ShowTooltip()
    {
        while (true)
        {
            var mousePos = Mouse.current.position.ReadValue();

            var worldPoint = Camera.main.ScreenToWorldPoint(mousePos);

            var spellScrollCollider = Physics2D.OverlapPoint(worldPoint, spellCsrollMask);

            if (!spellTooltipHolder.activeSelf && spellScrollCollider && Keyboard.current.altKey.isPressed)
            {
                Cursor.visible = false;

                var spellScroll = spellScrollCollider.GetComponent<SpellScroll>();

                videoTexture.Release();
                videoPlayer.time = 0;
                videoPlayer.clip = spellScroll.spell.videoClip;
                videoPlayer.Play();

                yield return Timing.WaitForSeconds(0.1f);

                spellTooltipHolder.SetActive(true);
            }
            else if (Keyboard.current.altKey.wasReleasedThisFrame)
            {
                spellTooltipHolder.SetActive(false);
                Cursor.visible = true;
                videoPlayer.time = 0;
                videoPlayer.Stop();
            }

            yield return Timing.WaitForOneFrame;
        }
    }
}