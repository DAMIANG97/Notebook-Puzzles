using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        Button[] buttons = FindObjectsOfType<Button>();
        
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(PlayButtonClickSound);
        }
    }
    void PlayButtonClickSound()
    {
        audioSource.Play();
    }
}
