using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResetLevel : MonoBehaviour
{
    public void Reset()
    {
        // Reset dla wszystkich obiektów Button
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            ChangeButtonImage buttonImageController = button.GetComponent<ChangeButtonImage>();
            if (buttonImageController != null)
            {
                buttonImageController.SetButtonState(false, buttonImageController.ImageOff);
            }
        }

        // Reset dla wszystkich obiektów ToggleTagBtn
        ToggleTagBtn[] toggleTagButtons = FindObjectsOfType<ToggleTagBtn>();
        foreach (ToggleTagBtn toggleTagBtn in toggleTagButtons)
        {
            // Resetujemy stan obiektu ToggleTagBtn na wyłączony (false)
            toggleTagBtn.isOn = false;
            
            // Aktualizujemy obraz obiektu ToggleTagBtn na wyłączony (imageOff)
            GameObject buttonObject = toggleTagBtn.gameObject;
            Image buttonImage = buttonObject.GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.sprite = toggleTagBtn.imageOff;
            }
        }

        // Reset dla wszystkich obiektów TMP_InputField
        TMP_InputField[] tmpInputFields = FindObjectsOfType<TMP_InputField>();
        
        foreach (TMP_InputField tmpInputField in tmpInputFields)
        {
            // Resetujemy tekst główny (tekst wprowadzony przez użytkownika) na pusty ciąg znaków
            tmpInputField.text = "";
        }

        // Reset dla wszystkich obiektów z przypisanym skryptem ChangeSign
ChangeSign[] changeSigns = FindObjectsOfType<ChangeSign>();
foreach (ChangeSign changeSign in changeSigns)
{
    // Resetujemy teksty znaków w ChangeSign
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
