using UnityEngine;

public class DragAndMove : MonoBehaviour
{
    private Plane dragPlane;
    private Vector3 offset;
    private bool isDragging = false;

    void Update()
    {
        if (isDragging)
        {
            MoveObjectWithMouse();
        }
    }

    void OnMouseDown()
    {
        dragPlane = new Plane(Camera.main.transform.forward, transform.position);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        dragPlane.Raycast(ray, out float enter);
        Vector3 hitPoint = ray.GetPoint(enter);
        offset = transform.position - hitPoint;

        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void MoveObjectWithMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (dragPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);

            transform.position = hitPoint + offset;
        }
    }
}
