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
        CheckButtons();
    }

    private void CheckButtons()
    {
        bool allButtonsOn = true;

        foreach (ToggleTagBtn button in buttonsOn)
        {
            if (!button.IsOn())
            {
                allButtonsOn = false;
                break;
            }
        }

        foreach (ToggleTagBtn button in buttonsOff)
        {
            if (button.IsOn())
            {
                allButtonsOn = false;
                break;
            }
        }

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
