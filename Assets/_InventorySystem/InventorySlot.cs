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
        UpdateUI();
    }

    public IngredientType GetIngredientType()
    {
        return ingredient.ingredientType;
    }

    public void SetQuantity(int newQuantity)
    {
        quantity = newQuantity;
        UpdateUI();
    }

    public string GetIngredientName()
    {
        return ingredient.ingredientName;  // Keep this if you still need it for displaying names
    }

    private void UpdateUI()
    {
        if (ingredientNameText != null)
            ingredientNameText.text = ingredient.ingredientName;

        if (quantityText != null)
            quantityText.text = quantity.ToString();

        if (ingredientImage != null && ingredient.icon != null)
            ingredientImage.sprite = ingredient.icon;
    }
}