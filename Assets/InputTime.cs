using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputTime : MonoBehaviour
{
    public TMP_InputField timeInputField;
    private int LevelIndex;
    public string CorrectAnswer;

void Start(){
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LevelIndex = currentSceneIndex+1;
}
    public void OnTimeInputChange()
    {
        // Zamiana obu wartości na małe litery przed porównaniem
        string inputText = timeInputField.text.ToLower();
        string correctAnswerLower = CorrectAnswer.ToLower();

        // Sprawdzamy, czy wartość pola wejściowego to poprawna odpowiedź (bez względu na wielkość liter)
        if (inputText == correctAnswerLower)
        {
            // Tutaj możemy wpisać kod akcji, który ma zostać wykonany
            SceneManager.LoadScene(LevelIndex);
        }
    }
}
