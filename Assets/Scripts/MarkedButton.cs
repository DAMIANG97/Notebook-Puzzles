using UnityEngine;
using UnityEngine.UI;

public class MarkedButton : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        Button[] buttons = FindObjectsOfType<Button>();
        
        foreach (Button button in buttons)
        {
            if (button.tag != "NotToMark")
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
