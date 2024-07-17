using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadCurrency : MonoBehaviour
{
    public TextMeshProUGUI CurrentValueText;
    void Update()
    {

        CurrentValueText.text = "100";
    }
}
