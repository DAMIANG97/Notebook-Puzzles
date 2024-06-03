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
                currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                Debug.Log(currentSceneIndex);
                SceneManager.LoadScene(currentSceneIndex + 1);
        }
}
