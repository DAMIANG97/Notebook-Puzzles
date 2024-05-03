using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSelf : MonoBehaviour
{
   private void Start()
    {
    gameObject.SetActive(false);
    }
}
