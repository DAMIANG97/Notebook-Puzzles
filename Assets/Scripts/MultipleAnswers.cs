using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class MultipleAnswers : MonoBehaviour
{
    public TMP_InputField MultipleInputField;
    private int LevelIndex;
    public List<string> CorrectAnswers;

    void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LevelIndex = currentSceneIndex + 1;
    }

    public void OnInputChange()
    {
        string inputText = MultipleInputField.text.ToLower();

        foreach (string correctAnswer in CorrectAnswers)
        {
            string correctAnswerLower = correctAnswer.ToLower();
            if (inputText == correctAnswerLower)
            {
                GameManager.LoadNextScene();
                return; 
            }
        }
    }
}
