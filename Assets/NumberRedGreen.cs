using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberRedGreen : MonoBehaviour
{
    public TMP_InputField greenInputField;
    public TMP_InputField redInputField;
            public int LevelIndex;
            public string CorrectAnswerGreen;
            public string CorrectAnswerRed;

    public void InputChange()
    {
        // Sprawdzamy, czy wartość pola wejściowego to "23:05:14"
        if (greenInputField.text == CorrectAnswerGreen & redInputField.text == CorrectAnswerRed)
        {
            // Tutaj możemy wpisać kod akcji, który ma zostać wykonany
        SceneManager.LoadScene(LevelIndex);
        }
    }
}
