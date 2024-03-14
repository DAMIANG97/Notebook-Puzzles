using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonSequenceChecker : MonoBehaviour
{
    public Button[] sequence;
    private int currentIndex = 0;
    private bool inputEnabled = true;

    void Start()
    {
        foreach (Button button in sequence)
        {
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
        inputEnabled = true; // Włącz możliwość kolejnych kliknięć po opóźnieniu
    }

    void LoadNextScene()
    {
GameManager.LoadNextScene();
    }
}
