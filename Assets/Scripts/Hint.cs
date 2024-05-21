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
    
    private float lastChangeTime;
    public float minChangeInterval = 1f;

    private void Start()
    {
        lastChangeTime = -minChangeInterval;
    }

    public void ChangeText()
    {
        if (Time.time - lastChangeTime >= minChangeInterval)
        {
            hintText.text =$"({currentIndex+1}/{hints.Count}) hint: {hints[currentIndex]}";
            currentIndex = (currentIndex + 1) % hints.Count;
            lastChangeTime = Time.time; 
        }
    }
}
