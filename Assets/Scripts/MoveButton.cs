using UnityEngine;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Button[] buttons = Resources.FindObjectsOfTypeAll<Button>();

        foreach (Button button in buttons)
        {
            if (button.gameObject.scene == this.gameObject.scene && button.tag == "NotToMark")
            {
                button.onClick.AddListener(PlayButtonClickSound);
            }
        }
    }

    void PlayButtonClickSound()
    {
        audioSource.Play();
    }
}
