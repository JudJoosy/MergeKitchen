using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventorySlot> slots; // List of inventory slots

    // Adds an ingredient to the inventory
    public void AddToInventory(Ingredient ingredient)
    {
        bool ingredientAdded = false;

        // Try to find a slot with the same ingredient
        foreach (var slot in slots)
        {
            if (slot.GetIngredientName() == ingredient.displayName)
            {
                slot.AddQuantity(ingredient.quantity); // Add quantity to the existing slot
                ingredientAdded = true;
                break;
            }
        }

        // If no existing slot found, try to find an empty one
        if (!ingredientAdded)
        {
            foreach (var slot in slots)
            {
                if (string.IsNullOrEmpty(slot.GetIngredientName()))
                {
                    slot.SetIngredient(ingredient); // Assign new ingredient to an empty slot
                    ingredientAdded = true;
                    break;
                }
            }
        }

        // If no space found, inventory is full
        if (!ingredientAdded)
        {
            Debug.LogWarning("Inventory is full!");
        }
    }

    // Reduces the quantity of an ingredient
    public void ReduceIngredientQuantity(string name, int amount)
    {
        foreach (var slot in slots)
        {
            if (slot.GetIngredientName() == name)
            {
                slot.ReduceQuantity(amount);
                break;
            }
        }
    }

    // Checks if there’s at least 1 of the ingredient in inventory
    public bool HasIngredient(string name)
    {
        foreach (var slot in slots)
        {
            if (slot.GetIngredientName() == name && slot.GetQuantity() > 0)
                return true;
        }
        return false;
    }
}