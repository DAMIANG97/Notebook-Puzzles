using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChangeButtonImage : MonoBehaviour
{
    public Sprite imageOn;
    public Sprite imageOff;

    private Image buttonImage;
    private bool isOn = false;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        SetButtonState(isOn);
    }

    public void ToggleButton()
    {
        isOn = !isOn;
        SetButtonState(isOn);

        ButtonManager buttonManager = FindObjectOfType<ButtonManager>();
        if (buttonManager != null)
        {
            buttonManager.ButtonStateChanged();
        }
    }

    private void SetButtonState(bool state)
    {
        if (state)
        {
            buttonImage.sprite = imageOn;
        }
        else
        {
            buttonImage.sprite = imageOff;
        }
    }

    public bool IsOn()
    {
        return isOn;
    }
}
