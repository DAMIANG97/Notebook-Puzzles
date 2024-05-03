using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResetLevel : MonoBehaviour
{
    public void Reset()
    {
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            ChangeButtonImage buttonImageController = button.GetComponent<ChangeButtonImage>();
            if (buttonImageController != null)
            {
                buttonImageController.SetButtonState(false, buttonImageController.ImageOff);
            }
        }

        ToggleTagBtn[] toggleTagButtons = FindObjectsOfType<ToggleTagBtn>();
        foreach (ToggleTagBtn toggleTagBtn in toggleTagButtons)
        {
            toggleTagBtn.isOn = false;
            
            GameObject buttonObject = toggleTagBtn.gameObject;
            Image buttonImage = buttonObject.GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.sprite = toggleTagBtn.imageOff;
            }
        }

        TMP_InputField[] tmpInputFields = FindObjectsOfType<TMP_InputField>();
        
        foreach (TMP_InputField tmpInputField in tmpInputFields)
        {
            tmpInputField.text = "";
        }

ChangeSign[] changeSigns = FindObjectsOfType<ChangeSign>();
foreach (ChangeSign changeSign in changeSigns)
{
    if (changeSign.SignText1 != null)
    {
        changeSign.SignText1.text = "+"; 
    }

    if (changeSign.SignText2 != null)
    {
        changeSign.SignText2.text = "+"; 
    }

    if (changeSign.SignText3 != null)
    {
        changeSign.SignText3.text = "+"; 
    }
}

    }
}
