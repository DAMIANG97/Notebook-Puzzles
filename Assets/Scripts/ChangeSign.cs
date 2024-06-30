using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSign : MonoBehaviour
{
    public TextMeshProUGUI SignText1;
    public TextMeshProUGUI SignText2;
    public TextMeshProUGUI SignText3;
    public TextMeshProUGUI buttonText;
    public string correctValueSet1_1;
    public string correctValueSet1_2;
    public string correctValueSet1_3;
    public string correctValueSet2_1;
    public string correctValueSet2_2;
    public string correctValueSet2_3;
    private int LevelIndex;

    private void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LevelIndex = currentSceneIndex + 1;
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

        if ((value1 == correctValueSet1_1 && value2 == correctValueSet1_2 && value3 == correctValueSet1_3) ||
            (value1 == correctValueSet2_1 && value2 == correctValueSet2_2 && value3 == correctValueSet2_3))
        {
            GameManager.LoadNextScene();
        }
    }
}
