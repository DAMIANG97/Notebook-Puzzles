using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSelf : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }
}
