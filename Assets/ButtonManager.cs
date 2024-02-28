using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public List<ChangeButtonImage> buttonsOn;
    public List<ChangeButtonImage> buttonsOff;

        public int LevelIndex;

    void Start()
    {
        // Przy starcie gry sprawdzamy, czy wymagane przyciski są ustawione jako "on"
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
        foreach (ChangeButtonImage button in buttonsOn)
        {
            if (!button.IsOn())
            {
                allButtonsOn = false;
                break;
            }
        }

        // Sprawdzamy, czy przyciski ustawione jako "off" są w stanie "off"
        foreach (ChangeButtonImage button in buttonsOff)
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
        // Tutaj możesz wpisać kod akcji, który ma zostać wykonany, gdy wszystkie przyciski ustawione jako "on" są w stanie "on", a wszystkie przyciski ustawione jako "off" są w stanie "off"
        SceneManager.LoadScene(LevelIndex);
    }
}
