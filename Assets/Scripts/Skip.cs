using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Skip : MonoBehaviour
{
        private int currentSceneIndex;
        public Button InfoButton;
        public TextMeshProUGUI InfoText;
        public void SkipScene()
        {
                int currentCoins = PlayerPrefs.GetInt("Coins", 100);
                if (currentCoins >= 100)
                {
                        PlayerPrefs.SetInt("Coins", currentCoins - 100);
                        PlayerPrefs.Save();
                        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                        Debug.Log(currentSceneIndex);
                        SceneManager.LoadScene(currentSceneIndex + 1);
                }
                else
                {
                        InfoText.text = "You don't have enough erasers.";
                        InfoButton.gameObject.SetActive(true);
                }

        }
}
