using MEC;
using UnityEngine.SceneManagement;

public static class LevelManager
{
    public static void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void Restart()
    {
        Timing.KillCoroutines();

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        SaveManager.inst.RestartLevel();
    }
}