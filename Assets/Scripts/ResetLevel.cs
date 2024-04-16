using UnityEngine;
using UnityEngine.UI;

public class ResetLevel : MonoBehaviour
{
    public void Reset()
    {
        // Resetowanie InputField, który podałeś wcześniej

        // Znajdź wszystkie przyciski w scenie i zmień ich stan oraz sprite
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            ChangeButtonImage buttonImageController = button.GetComponent<ChangeButtonImage>();
            if (buttonImageController != null)
            {
                buttonImageController.SetButtonState(false, buttonImageController.ImageOff);
            }
        }
    }
}
