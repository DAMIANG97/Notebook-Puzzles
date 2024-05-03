using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class SizeColliderChange : MonoBehaviour
{
    public TMP_InputField timeInputField;
    public GameObject targetObject;

    public List<string> CorrectAnswers;

void Start(){

}
    public void BoxColliderChange()
    {
        string inputText = timeInputField.text.ToLower();

        foreach (string correctAnswer in CorrectAnswers)
        {
        string correctAnswerLower = correctAnswer.ToLower();

            if (inputText == correctAnswerLower)
            {
            BoxCollider2D boxCollider = targetObject.GetComponent<BoxCollider2D>();
                if (boxCollider != null)
                {
                boxCollider.size = new Vector2(310.0f, 400.0f);
                }
            }
        }
    }
}
