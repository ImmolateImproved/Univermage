using UnityEngine.SceneManagement;

public static class LevelManager
{
    public static void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void Restart()
    {
        MEC.Timing.KillCoroutines(CoroutineTags.GAMEPLAY);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}