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
        quantity = newIngredient.quantity;
        UpdateUI();
    }

    public string GetIngredientName()
    {
        return ingredient != null ? ingredient.displayName : "";
    }

    public int GetQuantity()
    {
        return quantity;
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

    public void ReduceQuantity(int amount)
    {
        quantity -= amount;
        if (quantity < 0) quantity = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (ingredient == null) return;

        if (ingredientNameText != null)
            ingredientNameText.text = ingredient.displayName;

        if (quantityText != null)
            quantityText.text = quantity > 1 ? $"x{quantity}" : "";

        if (ingredientImage != null && ingredient.icon != null)
            ingredientImage.sprite = ingredient.icon;
    }
}