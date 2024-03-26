using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public List<ChangeButtonImage> buttonsOn;
    public List<ChangeButtonImage> buttonsOff;

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

        foreach (ChangeButtonImage button in buttonsOn)
        {
            if (!button.IsOn())
            {
                allButtonsOn = false;
                break;
            }
        }

        foreach (ChangeButtonImage button in buttonsOff)
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
GameManager.LoadNextScene();
    }
}
