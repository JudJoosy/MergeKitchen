using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public TextMeshProUGUI quantityText;
    public Image ingredientImage;
    private string ingredientName;

    // Setup the slot with ingredient name, sprite, and count
    public void SetupSlot(string name, Sprite sprite, int quantity)
    {
        ingredientName = name;
        ingredientImage.sprite = sprite;
        UpdateQuantity(quantity);
    }

    // Update the quantity in the UI
    public void UpdateQuantity(int quantity)
    {
        quantityText.text = quantity.ToString();
    }
}
