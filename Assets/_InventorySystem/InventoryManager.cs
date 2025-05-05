using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventorySlot> slots;

    public void AddToInventory(Ingredient ingredient)
    {
        foreach (var slot in slots)
        {
            // Use displayName instead of ingredientName
            if (slot.GetIngredientName() == ingredient.displayName)
            {
                slot.SetQuantity(slot.GetComponent<Ingredient>().quantity + ingredient.quantity);
                return;
            }
        }

        foreach (var slot in slots)
        {
            if (string.IsNullOrEmpty(slot.GetIngredientName()))
            {
                slot.SetIngredient(ingredient);
                slot.SetQuantity(ingredient.quantity);
                return;
            }
        }

        Debug.LogWarning("Inventory is full!");
    }
}