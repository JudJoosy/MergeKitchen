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

    public Ingredient GetIngredient()
    {
        return ingredient;
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
        if (quantity <= 0)
        {
            ClearSlot();
        }
        else
        {
            UpdateUI();
        }
    }

    public bool ContainsIngredient(Ingredient target)
    {
        return ingredient == target;
    }

    public void ClearSlot()
    {
        ingredient = null;
        quantity = 0;

        if (ingredientNameText != null)
            ingredientNameText.text = "";

        if (quantityText != null)
            quantityText.text = "";

        if (ingredientImage != null)
            ingredientImage.sprite = null;

        // Optionally disable UI elements if needed
        // gameObject.SetActive(false); // Uncomment if your slots are dynamically shown
    }

    private void UpdateUI()
    {
        if (ingredient != null)
        {
            if (ingredientNameText != null)
                ingredientNameText.text = ingredient.displayName;

            if (quantityText != null)
                quantityText.text = quantity > 1 ? $"x{quantity}" : "";

            if (ingredientImage != null && ingredient.icon != null)
                ingredientImage.sprite = ingredient.icon;
        }
    }
}
