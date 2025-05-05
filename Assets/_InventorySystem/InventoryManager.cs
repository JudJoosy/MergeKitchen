using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventorySlot> slots;

    public void AddToInventory(Ingredient ingredient)
    {
        foreach (var slot in slots)
        {
            if (slot.GetIngredientName() == ingredient.displayName)
            {
                slot.AddQuantity(ingredient.quantity); // Corrected to use InventorySlot logic
                return;
            }
        }

        foreach (var slot in slots)
        {
            if (string.IsNullOrEmpty(slot.GetIngredientName()))
            {
                slot.SetIngredient(ingredient);
                return;
            }
        }

        Debug.LogWarning("Inventory is full!");
    }
}