using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;
    private bool isDragging;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        if (mainCamera == null) return;
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (!isDragging || mainCamera == null) return;
        transform.position = GetMouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(mainCamera.transform.position.z); // distance from camera
        return mainCamera.ScreenToWorldPoint(mousePos);
    }
}
