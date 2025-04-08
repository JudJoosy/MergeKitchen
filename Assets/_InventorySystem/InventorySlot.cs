using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image ingredientImage;
    public string ingredientName; // The name of the ingredient, e.g., "salt", "pepper", etc.

    private Transform originalParent;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // When the drag starts, we store the original parent and make the slot temporarily disappear.
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false; // To prevent other UI elements from blocking the drag
    }

    // During the drag, we move the ingredient.
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    // When the drag ends, we check if it was dropped into a craft slot.
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent);
        canvasGroup.blocksRaycasts = true; // Allow raycasting again
    }
}
