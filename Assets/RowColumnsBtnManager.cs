using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RowColumnsBtnManager : MonoBehaviour
{
    public List<ToggleTagBtn> buttonsOn;
    public List<ToggleTagBtn> buttonsOff;

    private int LevelIndex;

    void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LevelIndex = currentSceneIndex+1;
        CheckButtons();
    }

    public void ButtonStateChanged()
    {
        // Kiedy zmienia się stan przycisku, sprawdzamy, czy wymagane przyciski są ustawione jako "on"
        CheckButtons();
    }

    private void CheckButtons()
    {
        bool allButtonsOn = true;

        // Sprawdzamy, czy przyciski ustawione jako "on" są w stanie "on"
        foreach (ToggleTagBtn button in buttonsOn)
        {
            if (!button.IsOn())
            {
                allButtonsOn = false;
                break;
            }
        }

        // Sprawdzamy, czy przyciski ustawione jako "off" są w stanie "off"
        foreach (ToggleTagBtn button in buttonsOff)
        {
            if (button.IsOn())
            {
                allButtonsOn = false;
                break;
            }
        }

        // Jeśli wszystkie przyciski ustawione jako "on" są w stanie "on" i wszystkie przyciski ustawione jako "off" są w stanie "off"
        if (allButtonsOn)
        {
            AllButtonsOnAction();
        }
    }

    private void AllButtonsOnAction()
    {
        SceneManager.LoadScene(LevelIndex);
    }
}
