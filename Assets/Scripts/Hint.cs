using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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
        hintText.text = "";
        SkipButton.SetActive(false);
    }

    public void ChangeText()
    {
        if (Time.time - lastChangeTime >= minChangeInterval)
        {
            if (!hintsCompleted)
            {
                if (currentIndex >= hints.Count)
                {
                    hintsCompleted = true;
                    hintText.text = "";
                    SkipButton.SetActive(true);
                    HintButton.SetActive(false);
                }
                else
                {
                    int currentCoins = PlayerPrefs.GetInt("Coins", 100);
                    if (currentCoins >= 50)
                    {
                        PlayerPrefs.SetInt("Coins", currentCoins - 50);
                        PlayerPrefs.Save();
                        hintText.text = $"({currentIndex + 1}/{hints.Count}) hint: {hints[currentIndex]}";
                        currentIndex++;
                        lastChangeTime = Time.time;

                    }
                }
            }
        }
    }
}