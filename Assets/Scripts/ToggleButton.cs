using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    // Odniesienie do przycisku, którego widoczność będziemy kontrolować
    public GameObject buttonToToggle;

    // Ta metoda będzie wywoływana, gdy użytkownik kliknie ten przycisk
    public void OnButtonClick()
    {
        // Sprawdź bieżący stan aktywności obiektu
        bool isButtonActive = buttonToToggle.activeSelf;
        
        // Zmień stan aktywności obiektu na przeciwny
        buttonToToggle.SetActive(!isButtonActive);
    }
}
