using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputTime : MonoBehaviour
{
    public TMP_InputField timeInputField;
            public int LevelIndex;

    public void OnTimeInputChange()
    {
        // Sprawdzamy, czy wartość pola wejściowego to "23:05:14"
        if (timeInputField.text == "23:05:14")
        {
            // Tutaj możemy wpisać kod akcji, który ma zostać wykonany
        SceneManager.LoadScene(LevelIndex);
        }
    }
}
