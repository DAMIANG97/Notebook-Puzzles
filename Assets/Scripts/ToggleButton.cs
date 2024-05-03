using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public GameObject buttonToToggle;

    public void OnButtonClick()
    {
        bool isButtonActive = buttonToToggle.activeSelf;
        
        buttonToToggle.SetActive(!isButtonActive);
    }
}
