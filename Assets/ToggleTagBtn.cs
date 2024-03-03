using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ToggleTagBtn : MonoBehaviour
{
    public Sprite imageOn;
    public Sprite imageOff;

    private bool isOn = false;
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

        // Po zmianie stanu przycisku, wywołujemy funkcję w menedżerze przycisków
        RowColumnsBtnManager RowColumnsBtnManager = FindObjectOfType<RowColumnsBtnManager>();
        if (RowColumnsBtnManager != null)
        {
            RowColumnsBtnManager.ButtonStateChanged();
        }
    }

    private void SetButtonState(bool state)
    {
        // Znajdujemy wszystkie przyciski spełniające kryteria warstw lub tagów
        GameObject[] buttons = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject buttonObject in buttons)
        {
            // Sprawdzamy warstwy przycisku
            foreach (string layerName in layersToToggle)
            {
                if (buttonObject.layer == LayerMask.NameToLayer(layerName))
                {
                    ToggleImage(buttonObject);
                    continue;
                }
            }

            // Sprawdzamy tagi przycisku
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
    // Pobieramy komponent ToggleTagBtn przypisany do przycisku
    ToggleTagBtn toggleBtn = buttonObject.GetComponent<ToggleTagBtn>();

    // Sprawdzamy czy komponent ToggleTagBtn istnieje
    if (toggleBtn != null)
    {
        // Pobieramy komponent Image przycisku
        Image buttonImage = buttonObject.GetComponent<Image>();

        // Jeśli komponent Image istnieje
        if (buttonImage != null)
        {
            // Sprawdzamy aktualny stan przycisku i ustawiamy przeciwny
            toggleBtn.isOn = !toggleBtn.isOn;

            // Ustawiamy sprite przycisku na podstawie jego aktualnego stanu
            buttonImage.sprite = toggleBtn.isOn ? toggleBtn.imageOn : toggleBtn.imageOff;
        }
    }
}



    public bool IsOn()
    {
        return isOn;
    }
}
