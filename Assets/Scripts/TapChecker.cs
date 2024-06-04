using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapChecker : MonoBehaviour
{
    public GameObject targetObject;
    private int tapCount = 0;
    public void OnButtonClick()
    {
        tapCount++;

        if (tapCount == 2)
        {
            BoxCollider2D boxCollider = targetObject.GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                boxCollider.size = new Vector2(310.0f, 400.0f);
            }
        }
    }
}
