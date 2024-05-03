using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ButtonSequenceChecker : MonoBehaviour
{
    public Button[] sequence;
    private int currentIndex = 0;
    private bool inputEnabled = true;
    private List<Button> allButtons = new List<Button>();

    void Start()
    {
        Button[] buttonsInScene = FindObjectsOfType<Button>();
        foreach (Button button in buttonsInScene)
        {
            allButtons.Add(button);
            button.onClick.AddListener(() => ButtonClicked(button));
        }
    }

    void ButtonClicked(Button button)
    {
        if (inputEnabled)
        {
            inputEnabled = false;
            StartCoroutine(EnableInputAfterDelay(0.1f));

            if (button == sequence[currentIndex])
            {
                currentIndex++;

                if (currentIndex == sequence.Length)
                {
                    LoadNextScene();
                }
            }
            else
            {
                currentIndex = 0;
            }
        }
    }

    IEnumerator EnableInputAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        inputEnabled = true;
    }

    void LoadNextScene()
    {
        GameManager.LoadNextScene();
    }
}
