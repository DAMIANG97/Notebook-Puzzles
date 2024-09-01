using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public GameObject objectToToggle;

    public void ToggleActiveState()
    {
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
    }
}
