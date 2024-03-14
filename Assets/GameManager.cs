using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    private static int currentSceneIndex;
    private static int lastStartedSceneIndex;

    static GameManager()
    {
        lastStartedSceneIndex = PlayerPrefs.GetInt("LastStartedSceneIndex", 0);
        
        currentSceneIndex = lastStartedSceneIndex;
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        lastStartedSceneIndex = scene.buildIndex;
        PlayerPrefs.SetInt("LastStartedSceneIndex", lastStartedSceneIndex);
        PlayerPrefs.Save();

        currentSceneIndex = lastStartedSceneIndex;
    }
    public static void LoadGame(){
        if (currentSceneIndex==0)
        {
            SceneManager.LoadScene(currentSceneIndex+1);
        }
        else
        {  
            SceneManager.LoadScene(currentSceneIndex);
        }

    }
    public static void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
