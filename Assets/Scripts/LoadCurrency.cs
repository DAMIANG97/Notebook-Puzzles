using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadCurrency : MonoBehaviour
{
    public TextMeshProUGUI CurrentValueText;
    void Update()
    {
        int currentCoins = PlayerPrefs.GetInt("Coins", 100);
        CurrentValueText.text = currentCoins.ToString();
    }
}
