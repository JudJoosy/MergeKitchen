using UnityEngine;
using TMPro;

namespace _InventorySystem
{
    public class InventorySlotUI : MonoBehaviour
    {
        public string ingredientName;  // Name of the ingredient in this slot
        public TextMeshProUGUI quantityText;  // Reference to the TextMeshProUGUI for quantity
        public GameObject ingredientIcon;  // Reference to the ingredient icon (Sprite or Image)

        // This will set up each slot with an ingredient's name, sprite, and quantity
        public void SetupSlot(string ingredientName, Sprite ingredientSprite, int quantity)
        {
            this.ingredientName = ingredientName;

            if (ingredientIcon != null)
            {
                ingredientIcon.GetComponent<SpriteRenderer>().sprite = ingredientSprite;  // Assign sprite to the icon
            }

            if (quantityText != null)
            {
                quantityText.text = "x" + quantity.ToString();  // Show the quantity
            }
        }

        // Update the quantity in the UI slot (e.g., when an ingredient is added or removed)
        public void UpdateQuantity(int newQuantity)
        {
            if (quantityText != null)
            {
                quantityText.text = "x" + newQuantity.ToString();
            }
        }
    }
}
