using MEC;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : Singleton<BackgroundMusicManager>
{
    private const string MusicRoutineTag = "BGMUSIC";

    [SerializeField]
    private AudioSource backbroundAudioSource;

    [SerializeField]
    private AudioClip[] backgroundMusic;

    private int currentClipIndex;

    private bool IsMenuScene
    {
        get => SceneManager.GetActiveScene().buildIndex == 0;
    }

    private void Start()
    {
        if (Initialized)
            return;

        Timing.RunCoroutine(MusicRoutine(false), MusicRoutineTag);
    }

    private void OnEnable()
    {
        LevelSelectionButton.OnClick += LevelSelectionButton_OnClick;
    }

    private void OnDisable()
    {
        LevelSelectionButton.OnClick -= LevelSelectionButton_OnClick;
    }

    private void LevelSelectionButton_OnClick(int obj)
    {
        if (!IsMenuScene)
            return;

        SetNewRandomClip();
    }

    public void SetNewRandomClip()
    {
        if (!IsMenuScene)
            return;

        Timing.KillCoroutines(MusicRoutineTag);
        Timing.RunCoroutine(MusicRoutine(true), MusicRoutineTag);
    }

    private IEnumerator<float> MusicRoutine(bool excludeMenuClip)
    {
        while (true)
        {
            var isMenu = SceneManager.GetActiveScene().buildIndex == 0;

            currentClipIndex = (isMenu && !excludeMenuClip) ? 0 : Random.Range(1, backgroundMusic.Length);

            backbroundAudioSource.clip = backgroundMusic[currentClipIndex];
            backbroundAudioSource.Play();

            var audioLength = backgroundMusic[currentClipIndex].length;

            yield return Timing.WaitForSeconds(audioLength);
        }
    }
}