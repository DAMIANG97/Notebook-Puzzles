using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonImage : MonoBehaviour
{
    public Sprite imageOn;
    public Sprite imageOff;
    public Sprite ImageOff => imageOff;

    private Image buttonImage;
    private bool isOn = false;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        SetButtonState(isOn, imageOff);
    }

    public void ToggleButton()
    {
        isOn = !isOn;
        if (isOn)
        {
            SetButtonState(true, imageOn);
        }
        else
        {
            SetButtonState(false, imageOff);
        }

        ButtonManager buttonManager = FindObjectOfType<ButtonManager>();
        if (buttonManager != null)
        {
            buttonManager.ButtonStateChanged();
        }
    }

    public void SetButtonState(bool state, Sprite sprite)
    {
        buttonImage.sprite = sprite;
        isOn = state;
    }

    public bool IsOn()
    {
        return isOn;
    }
}
