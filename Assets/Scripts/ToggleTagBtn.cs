using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ToggleTagBtn : MonoBehaviour
{
    public Sprite imageOn;
    public Sprite imageOff;

    public bool isOn = false;
    public List<string> layersToToggle;
    public List<string> tagsToToggle;

    void Start()
    {
        SetButtonState(isOn);
    }

    public void ToggleButton()
    {
        isOn = !isOn;
        SetButtonState(isOn);

        RowColumnsBtnManager RowColumnsBtnManager = FindObjectOfType<RowColumnsBtnManager>();
        if (RowColumnsBtnManager != null)
        {
            RowColumnsBtnManager.ButtonStateChanged();
        }
    }

    private void SetButtonState(bool state)
    {
        GameObject[] buttons = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject buttonObject in buttons)
        {
            foreach (string layerName in layersToToggle)
            {
                if (buttonObject.layer == LayerMask.NameToLayer(layerName))
                {
                    ToggleImage(buttonObject);
                    continue;
                }
            }

            foreach (string tagName in tagsToToggle)
            {
                if (buttonObject.CompareTag(tagName))
                {
                    ToggleImage(buttonObject);
                    continue;
                }
            }
        }
    }

private void ToggleImage(GameObject buttonObject)
{
    ToggleTagBtn toggleBtn = buttonObject.GetComponent<ToggleTagBtn>();

    if (toggleBtn != null)
    {
        Image buttonImage = buttonObject.GetComponent<Image>();

        if (buttonImage != null)
        {
            toggleBtn.isOn = !toggleBtn.isOn;

            buttonImage.sprite = toggleBtn.isOn ? toggleBtn.imageOn : toggleBtn.imageOff;
        }
    }
}



    public bool IsOn()
    {
        return isOn;
    }
}
