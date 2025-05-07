using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public TextMeshProUGUI ingredientNameText;
    public TextMeshProUGUI quantityText;
    public Image ingredientImage;

    private string ingredientName;
    private Sprite ingredientIcon;
    private int quantity;

    public void SetIngredient(string name, Sprite icon, int initialQuantity = 1)
    {
        ingredientName = name;
        ingredientIcon = icon;
        quantity = initialQuantity;
        UpdateUI();
    }

    public string GetIngredientName()
    {
        return ingredientName;
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

    public void AddQuantity(int amount)
    {
        quantity += amount;
        UpdateUI();
    }

    public void ReduceQuantity(int amount)
    {
        quantity -= amount;
        if (quantity < 0) quantity = 0;
        UpdateUI();
    }

    public void ClearSlot()
    {
        ingredientName = "";
        ingredientIcon = null;
        quantity = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (ingredientNameText != null)
            ingredientNameText.text = ingredientName;

        if (quantityText != null)
            quantityText.text = quantity > 1 ? $"x{quantity}" : "";

        if (ingredientImage != null)
            ingredientImage.sprite = ingredientIcon;

        gameObject.SetActive(!string.IsNullOrEmpty(ingredientName) && quantity > 0);
    }
}
