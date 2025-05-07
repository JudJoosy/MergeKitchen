using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventorySlot> slots;

    // Adds an ingredient to the inventory
    public void AddToInventory(Ingredient ingredient)
    {
        bool added = false;

        foreach (var slot in slots)
        {
            if (slot.GetIngredientName() == ingredient.displayName)
            {
                slot.AddQuantity(1);
                added = true;
                break;
            }
        }

        if (!added)
        {
            foreach (var slot in slots)
            {
                if (string.IsNullOrEmpty(slot.GetIngredientName()))
                {
                    slot.SetIngredient(ingredient.displayName, ingredient.icon, 1);
                    added = true;
                    break;
                }
            }
        }

        if (!added)
        {
            Debug.LogWarning("Inventory is full!");
        }
    }

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
                }
                break;
            }
        }
    }

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
