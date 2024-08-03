using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateUp : MonoBehaviour
{
    private string googlePlayURL = "https://play.google.com/store/apps/details?id=com.PixelPuzzles.NotebookPuzzles";

    public void Rateup()
    {
#if UNITY_ANDROID
        Application.OpenURL(googlePlayURL);
        PlayerPrefs.SetInt("hasRated", 1);
        PlayerPrefs.Save();
#endif
    }

}
