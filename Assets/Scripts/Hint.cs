using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Hint : MonoBehaviour
{
    public TextMeshProUGUI hintText;
    public GameObject SkipButton;
    public GameObject HintButton;
    private int currentIndex = 0;
    public List<string> hints = new List<string>();

    private float lastChangeTime;
    public float minChangeInterval = 1f;
    private bool hintsCompleted = false;

    private void Start()
    {
        lastChangeTime = -minChangeInterval;
        SkipButton.SetActive(false);
    }

    public void ChangeText()
    {
        string objectName = "RateUpHint";

        GameObject rateUp = FindInactiveObjectByName(objectName);
        if (Time.time - lastChangeTime >= minChangeInterval)
        {
            if (!hintsCompleted)
            {
                if (PlayerPrefs.GetInt("hasRated", 0) == 0 & currentIndex == 0)
                {
                    if (rateUp != null)
                    {
                        EventSystem.current.SetSelectedGameObject(null);

                        bool isButtonActive = rateUp.activeSelf;
                        rateUp.SetActive(!isButtonActive);
                    }
                }

                if (currentIndex < hints.Count)
                {
                    hintText.text = $"({currentIndex + 1}/{hints.Count}) hint: {hints[currentIndex]}";
                    currentIndex++;
                    lastChangeTime = Time.time;
                }
                else
                {
                    hintsCompleted = true;
                    SkipButton.SetActive(true);
                    HintButton.SetActive(false);
                    hintText.text = "";
                }

            }
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
}
