using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public string ingredientName;
    public Image icon;

    private void Start()
    {
        if (icon != null)
        {
            icon.enabled = !string.IsNullOrEmpty(ingredientName);
        }
    }

    public void SetIngredient(string name, Sprite sprite)
    {
        ingredientName = name;
        icon.sprite = sprite;
        icon.enabled = true;
    }

    public void OnSlotClicked()
    {
        CookingSlotManager.Instance.TryPlaceIngredient(ingredientName);
    }
}