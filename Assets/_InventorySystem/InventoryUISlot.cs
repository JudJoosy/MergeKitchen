using UnityEngine;
using UnityEngine.UI;
using TMPro;  // For using TextMeshProUGUI

public class InventorySlotUI : MonoBehaviour
{
    public string ingredientName;
    public int quantity;
    public UnityEngine.UI.Image ingredientImage;  // Reference to the image for the ingredient
    public TextMeshProUGUI quantityText;          // Reference to the TextMeshPro component for displaying quantity

    // This method is called to set up the slot
    public void SetupSlot(string name, Sprite sprite, int qty)
    {
        ingredientName = name;
        ingredientImage.sprite = sprite;        // Set the ingredient image
        UpdateQuantity(qty);                    // Update the quantity display
    }

    // This method updates the quantity text
    public void UpdateQuantity(int newQuantity)
    {
        quantity = newQuantity;
        if (quantityText != null)
        {
            quantityText.text = "x" + quantity.ToString();  // Display the quantity with "x"
        }
    }
}
