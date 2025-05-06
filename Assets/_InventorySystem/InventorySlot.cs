using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public TextMeshProUGUI ingredientNameText;  // UI Text for the ingredient name
    public TextMeshProUGUI quantityText;       // UI Text for the ingredient quantity
    public Image ingredientImage;              // UI Image for the ingredient icon

    private Ingredient ingredient;             // Ingredient stored in this slot
    private int quantity;                      // Quantity of the ingredient

    // Sets the ingredient and updates the UI
    public void SetIngredient(Ingredient newIngredient)
    {
        ingredient = newIngredient;
        quantity = newIngredient.quantity; // Set the initial quantity
        UpdateUI(); // Call to update the UI with the new data
    }

    // Gets the ingredient name
    public string GetIngredientName()
    {
        return ingredient != null ? ingredient.displayName : "";
    }

    // Sets the quantity for this slot and updates the UI
    public void SetQuantity(int newQuantity)
    {
        quantity = newQuantity;
        UpdateUI();
    }

    // Adds a specified quantity to this slot and updates the UI
    public void AddQuantity(int additionalAmount)
    {
        quantity += additionalAmount;
        UpdateUI();
    }

    // Updates the UI based on the ingredient data and quantity
    private void UpdateUI()
    {
        if (ingredient == null) return;

        // Update the ingredient name text
        if (ingredientNameText != null)
            ingredientNameText.text = ingredient.displayName;

        // Update the quantity text
        if (quantityText != null)
            quantityText.text = quantity.ToString();

        // Update the ingredient image (icon) if available
        if (ingredientImage != null && ingredient.icon != null)
            ingredientImage.sprite = ingredient.icon;
    }
}