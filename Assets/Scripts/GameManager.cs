using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static int currentSceneIndex;
    public static int lastStartedSceneIndex;

    static GameManager()
    {
        lastStartedSceneIndex = PlayerPrefs.GetInt("LastStartedSceneIndex", 0);
        currentSceneIndex = lastStartedSceneIndex;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
{
    if (scene.name != "End" && scene.buildIndex > lastStartedSceneIndex)
    {
        lastStartedSceneIndex = scene.buildIndex;
        PlayerPrefs.SetInt("LastStartedSceneIndex", lastStartedSceneIndex);
        PlayerPrefs.Save();
    }

    currentSceneIndex = scene.buildIndex;
}


    public static void Incrementlevel()
    {
        if (currentSceneIndex < lastStartedSceneIndex)
        {
            currentSceneIndex = currentSceneIndex + 1;
        }
    }

    public static void Decrementlevel()
    {
        if (currentSceneIndex > 1)
        {
            currentSceneIndex = currentSceneIndex - 1;
        }
    }

    public static void LoadGame()
    {
        if (currentSceneIndex == 0)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
    }

    public static void Loadmenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
