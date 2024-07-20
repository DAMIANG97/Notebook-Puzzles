using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
        private int currentSceneIndex;
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

        }
}
