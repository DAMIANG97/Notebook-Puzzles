using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Hint : MonoBehaviour
{

    public TextMeshProUGUI hintText;
    private int currentIndex = 0;
    public List<string> hints = new List<string>(); 

    public void ChangeText()
    {
        hintText.text = hints[currentIndex];
        currentIndex = (currentIndex + 1) % hints.Count;
        Debug.Log("siema");
    }
}
