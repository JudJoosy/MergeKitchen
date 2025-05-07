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
                Destroy(ingredient.gameObject); // Prevent clutter
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

        UpdateInventoryUI();
    }

    // Reduces the quantity of an ingredient
    public void ReduceIngredientQuantity(string name, int amount)
    {
        foreach (var slot in slots)
        {
            if (slot.GetIngredientName() == name)
            {
                slot.ReduceQuantity(amount);
                if (slot.GetQuantity() <= 0)
                {
                    slot.ClearSlot();
                    UpdateInventoryUI();
                }
                break;
            }
        }
    }

    // Removes a specific ingredient instance from inventory
    public void RemoveIngredient(Ingredient ingredient)
    {
        foreach (var slot in slots)
        {
            if (slot.ContainsIngredient(ingredient))
            {
                slot.ClearSlot();
                break;
            }
        }

        UpdateInventoryUI();
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

    // Reorders the inventory to keep slots compact and ordered
    public void UpdateInventoryUI()
    {
        List<Ingredient> allIngredients = new List<Ingredient>();

        // Extract all ingredients
        foreach (var slot in slots)
        {
            if (slot.GetIngredient() != null)
            {
                allIngredients.Add(slot.GetIngredient());
            }
            slot.ClearSlot(); // Clear everything first
        }

        // Reassign to the front slots
        for (int i = 0; i < allIngredients.Count && i < slots.Count; i++)
        {
            slots[i].SetIngredient(allIngredients[i]);
        }
    }
}