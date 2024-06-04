using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class LightSwitch : MonoBehaviour
{
    public List<Image> imagesToChange;

    public List<SpriteRenderer> spritesToChange;

    public List<TextMeshProUGUI> textMeshProsToChange;

    public Sprite onSprite;

    public Sprite offSprite;

    public Image switchImage;

    private bool isWhite = true;

    private void Start()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(false);
        }
    }

    public void ChangeColor()
    {
        Color targetColor = isWhite ? Color.white : new Color(0, 0.14f, 0.44f);
        Color phoneColor = isWhite ? new Color(1f, 1f, 1f, 0.4f) : new Color(1f, 0.99f, 0, 0.42f);

        foreach (Image image in imagesToChange)
        {
            if (image != null)
            {
                image.color = targetColor;
            }
        }

        foreach (SpriteRenderer spriteRenderer in spritesToChange)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.color = phoneColor;
            }
        }

        foreach (TextMeshProUGUI textMeshPro in textMeshProsToChange)
        {
            if (textMeshPro != null)
            {
                textMeshPro.gameObject.SetActive(!isWhite);
            }
        }

        if (switchImage != null)
        {
            switchImage.sprite = isWhite ? onSprite : offSprite;
        }

        isWhite = !isWhite;
    }
}
