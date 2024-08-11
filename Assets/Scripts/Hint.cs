using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Hint : MonoBehaviour
{
    public TextMeshProUGUI hintText;
    public GameObject SkipButton;
    public GameObject HintButton;
    public Button InfoButton;
    public TextMeshProUGUI InfoText;
    private int currentIndex = 0; // Zaczynamy od 0
    public List<string> hints = new List<string>();

    private float lastChangeTime;
    public float minChangeInterval = 1f;
    private bool hintsCompleted = false;

    private void Start()
    {
        lastChangeTime = -minChangeInterval;
        SkipButton.SetActive(false);


        hintText.text = $"(1/{hints.Count}) hint: {hints[currentIndex]}";
        currentIndex = currentIndex + 1;
    }

    public void ChangeText()
    {
        if (Time.time - lastChangeTime >= minChangeInterval)
        {
            if (!hintsCompleted)
            {
                // Sprawdzenie, czy są dostępne wskazówki
                if (currentIndex < hints.Count)
                {
                    int currentCoins = PlayerPrefs.GetInt("Coins", 100);
                    if (currentCoins >= 50)
                    {
                        PlayerPrefs.SetInt("Coins", currentCoins - 50);
                        PlayerPrefs.Save();

                        // Wyświetlenie wskazówki
                        hintText.text = $"({currentIndex + 1}/{hints.Count}) hint: {hints[currentIndex]}";
                        currentIndex++; // Zwiększenie indexu po wyświetleniu

                        // Sprawdzenie, czy to ostatnia wskazówka
                        if (currentIndex > hints.Count)
                        {
                            hintsCompleted = true;
                            SkipButton.SetActive(true);
                            HintButton.SetActive(false);
                            hintText.text = ""; // Opcjonalne, aby wyczyścić pole tekstowe
                        }

                        lastChangeTime = Time.time;
                    }
                    else
                    {
                        InfoText.text = "You don't have enough erasers.";
                        InfoButton.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
