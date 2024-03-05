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
        string inputText = timeInputField.text.ToLower();
        string correctAnswerLower = CorrectAnswer.ToLower();

        if (inputText == correctAnswerLower)
        {
            SceneManager.LoadScene(LevelIndex);
        }
    }
}
