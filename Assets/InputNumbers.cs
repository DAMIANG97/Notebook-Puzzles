using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class InputNumbers : MonoBehaviour
{
    public List<TMP_InputField> inputFields = new List<TMP_InputField>();
    public List<string> correctAnswers = new List<string>();
    private int LevelIndex;

    void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LevelIndex = currentSceneIndex + 1;
    }

    public void InputChange()
    {
        if (CheckAnswers())
        {
            SceneManager.LoadScene(LevelIndex);
        }
    }

    bool CheckAnswers()
    {
        if (inputFields.Count != correctAnswers.Count)
        {
            Debug.LogError("Number of input fields does not match number of correct answers!");
            return false;
        }

        for (int i = 0; i < inputFields.Count; i++)
        {
            if (inputFields[i].text != correctAnswers[i])
            {
                return false;
            }
        }
        return true;
    }
}
