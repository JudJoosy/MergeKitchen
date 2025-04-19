using UnityEngine;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public TMP_Text ingredientText;
    public SpriteRenderer spriteRenderer;
    public TMP_Text quantityText;

    private string ingredientName;
    private int quantity;

    public void SetIngredient(string name, Sprite sprite, int amount = 1)
    {
        ingredientName = name;
        quantity = amount;

        if (ingredientText != null)
            ingredientText.text = name;

        if (spriteRenderer != null)
            spriteRenderer.sprite = sprite;

        UpdateQuantityDisplay();
    }

    public void AddQuantity(int amount)
    {
        quantity += amount;
        UpdateQuantityDisplay();
    }

    public void ReduceQuantity(int amount)
    {
        quantity -= amount;
        if (quantity < 0) quantity = 0;
        UpdateQuantityDisplay();
    }

    public void ClearSlot()
    {
        ingredientName = null;
        quantity = 0;

        if (ingredientText != null)
            ingredientText.text = "";

        if (spriteRenderer != null)
            spriteRenderer.sprite = null;

        UpdateQuantityDisplay();
    }

    private void UpdateQuantityDisplay()
    {
        if (quantityText != null)
        {
            quantityText.text = quantity > 1 ? $"x{quantity}" : "";
        }
    }

    public bool IsEmpty()
    {
        return string.IsNullOrEmpty(ingredientName);
    }

    public string GetIngredientName() => ingredientName;
    public int GetQuantity() => quantity;
}