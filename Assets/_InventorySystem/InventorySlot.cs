using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public TextMeshProUGUI ingredientNameText;
    public TextMeshProUGUI quantityText;
    public Image ingredientImage;

    private Ingredient ingredient;
    private int quantity;

    public void SetIngredient(Ingredient newIngredient)
    {
        ingredient = newIngredient;
        quantity = newIngredient.quantity; // Set initial quantity
        UpdateUI();
    }

    public string GetIngredientName()
    {
        return ingredient != null ? ingredient.displayName : "";
    }

    public void SetQuantity(int newQuantity)
    {
        quantity = newQuantity;
        UpdateUI();
    }

    public void AddQuantity(int additionalAmount)
    {
        quantity += additionalAmount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (ingredient == null) return;

        if (ingredientNameText != null)
            ingredientNameText.text = ingredient.displayName;

        if (quantityText != null)
            quantityText.text = quantity.ToString();

        if (ingredientImage != null && ingredient.icon != null)
            ingredientImage.sprite = ingredient.icon;
    }
}