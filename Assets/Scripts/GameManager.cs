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

        // Znajdź obiekt, nawet jeśli jest nieaktywny
        GameObject rateUp = FindInactiveObjectByName(objectName);

        if (rateUp != null)
        {
            // Ukryj klawiaturę
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

    // Metoda do znajdowania nieaktywnego obiektu po nazwie
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

    // Metoda do ukrycia klawiatury
    private static void HideKeyboard()
    {
        // Usuwanie fokusu z aktywnego pola wejściowego
        EventSystem.current.SetSelectedGameObject(null);
    }
}


