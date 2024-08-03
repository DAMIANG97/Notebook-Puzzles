using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static int currentSceneIndex;
    public static int lastStartedSceneIndex = 0;

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
        if (scene.buildIndex != 0)
        {
            currentSceneIndex = scene.buildIndex;
        }
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
        string objectName = "PopUpRateUp";

        GameObject rateUp = FindInactiveObjectByName(objectName);

        if (PlayerPrefs.GetInt("hasRated", 0) == 0)
        {
            if (rateUp != null)
            {
                HideKeyboard();

                bool isButtonActive = rateUp.activeSelf;
                rateUp.SetActive(!isButtonActive);
            }
            else
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
        }
        else
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    private static GameObject FindInactiveObjectByName(string name)
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == name && obj.hideFlags == HideFlags.None && obj.scene == SceneManager.GetActiveScene())
            {
                return obj;
            }
        }
        return null;
    }

    private static void HideKeyboard()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}


