using UnityEngine;
using UnityEngine.UI;

public class ObjectLocationChecker : MonoBehaviour
{
    public Transform object1;
    public Transform object2;
    public Transform object3;

    public Button buttonToActivate;

    public Vector3 targetPosition;

    public float tolerance = 1.0f;

    void Update()
    {
        if (IsObjectInTargetPosition(object1) &&
            IsObjectInTargetPosition(object2) &&
            IsObjectInTargetPosition(object3))
        {
            buttonToActivate.gameObject.SetActive(true);
        }
        else
        {
            buttonToActivate.gameObject.SetActive(false);
        }
    }

    bool IsObjectInTargetPosition(Transform obj)
    {
        float distance = Vector3.Distance(obj.position, targetPosition);

        return distance <= tolerance;
    }
}
