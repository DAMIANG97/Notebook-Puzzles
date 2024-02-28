using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputTime : MonoBehaviour
{
    public TMP_InputField timeInputField;
            public int LevelIndex;
            public string CorrectAnswer;

    public void OnTimeInputChange()
    {
        // Sprawdzamy, czy wartość pola wejściowego to "23:05:14"
        if (timeInputField.text == CorrectAnswer)
        {
            // Tutaj możemy wpisać kod akcji, który ma zostać wykonany
        SceneManager.LoadScene(LevelIndex);
        }
    }
}
