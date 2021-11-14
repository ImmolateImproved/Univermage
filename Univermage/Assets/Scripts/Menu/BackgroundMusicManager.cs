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

    [SerializeField]
    private int menuMusicMaxIndex;

    private int currentClipIndex;

    private void Start()
    {
        if (Initialized)
            return;

        Timing.RunCoroutine(MusicRoutine(), MusicRoutineTag);
    }

    private IEnumerator<float> MusicRoutine()
    {
        while (true)
        {
            var maxIndex = menuMusicMaxIndex + 1;

            currentClipIndex = Random.Range(0, maxIndex);
            backbroundAudioSource.clip = backgroundMusic[currentClipIndex];
            backbroundAudioSource.Play();

            var audioLength = backgroundMusic[currentClipIndex].length;

            yield return Timing.WaitForSeconds(audioLength);
        }
    }

    private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode loadMode)
    {
        // Timing.RunCoroutine(MusicRoutine(), MusicRoutineTag);
    }

    private void SceneManager_sceneUnloaded(Scene scene)
    {
        // Timing.KillCoroutines(MusicRoutineTag);
        // backbroundAudioSource.Stop();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.sceneUnloaded += SceneManager_sceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        SceneManager.sceneUnloaded -= SceneManager_sceneUnloaded;
    }
}