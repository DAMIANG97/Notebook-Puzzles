using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeSign : MonoBehaviour
{
    private TextMeshProUGUI SignText1;
    private TextMeshProUGUI SignText2;
    private TextMeshProUGUI SignText3;
    public TextMeshProUGUI buttonText;
    private int LevelIndex;
private void Start(){
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    LevelIndex = currentSceneIndex+1;
    SignText1 = GameObject.Find("FirstSignText").GetComponent<TextMeshProUGUI>();
    SignText2 = GameObject.Find("SecondSignText").GetComponent<TextMeshProUGUI>();
    SignText3 = GameObject.Find("ThirdSignText").GetComponent<TextMeshProUGUI>();
}
    private int currentIndex = 0;
    private char[] operators = { '+', '-', '×', '÷' };

    public void ChangeText()
    {
        currentIndex = (currentIndex + 1) % operators.Length;
        buttonText.text = operators[currentIndex].ToString();

        string value1 = SignText1.text;
        string value2 = SignText2.text;
        string value3 = SignText3.text;
        if (value1 == "÷" && value2 == "+" && value3 == "×")
        {
GameManager.LoadNextScene();
        }
    }
}









