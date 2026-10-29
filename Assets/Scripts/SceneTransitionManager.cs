using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneTransitionManager
{
    public const int SCENE_MAIN_MENU = 0;
    public const int SCENE_LOBBY     = 1;
    public const int SCENE_ELEC      = 2;
    public const int SCENE_FOTO      = 3;
    public const int SCENE_EXCAV     = 4;
    public const int SCENE_MATH_NAME = 5;
    public const int SCENE_MATH_GAME = 6;
    public const int SCENE_END_GAME  = 7;

    public static void LoadScene(int sceneIndex)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public static void ReturnToLobby()
    {
        LoadScene(SCENE_LOBBY);
    }

    public static void ReloadCurrentScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
