using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(); // Ensure this is populated in Inspector
    public RecipeManager recipeManager;

    private void Start()
    {
        // Ensure inventorySlots is initialized
        if (inventorySlots == null || inventorySlots.Count == 0)
        {
            Debug.LogError("Inventory slots are not initialized or empty.");
            return;
        }

        // Ensure IngredientDatabase is not null
        if (IngredientDatabase.Instance == null)
        {
            Debug.LogError("IngredientDatabase.Instance is null. Make sure it is initialized.");
            return;
        }

        PopulateUI();
    }

    private void PopulateUI()
    {
        // Ensure IngredientDatabase is initialized again (just in case it's not done before)
        if (IngredientDatabase.Instance == null)
        {
            Debug.LogError("IngredientDatabase.Instance is null. Unable to populate UI.");
            return;
        }

        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i] == null)
            {
                Debug.LogError($"Inventory slot at index {i} is null.");
                continue;
            }

            // Get ingredient type and convert it to a string for the database
            IngredientType ingredientType = inventorySlots[i].GetIngredientType();
            string ingredientName = ingredientType.ToString();  // Convert IngredientType to string

            // Fetch ingredient quantity from the database
            int quantity = IngredientDatabase.Instance.GetIngredientQuantity(ingredientName);
            inventorySlots[i].SetQuantity(quantity);
        }
    }

    public void AddIngredientToInventory(Ingredient ingredient)
    {
        // Ensure IngredientDatabase is initialized
        if (IngredientDatabase.Instance == null)
        {
            Debug.LogError("IngredientDatabase.Instance is null. Unable to add ingredient.");
            return;
        }

        foreach (InventorySlot slot in inventorySlots)
        {
            // Compare the ingredient's type and name (converted to string)
            if (slot.GetIngredientType() == ingredient.ingredientType)
            {
                string ingredientName = ingredient.ingredientType.ToString();  // Convert to string for database
                int currentQuantity = IngredientDatabase.Instance.GetIngredientQuantity(ingredientName);

                // Update the quantity in the database
                IngredientDatabase.Instance.AddIngredient(ingredientName, 1);  // Add 1 to the ingredient quantity
                UpdateInventoryUI();
                return;
            }
        }

        // If not found, add a new slot (you may want a better way to spawn slots in the UI later!)
        InventorySlot newSlot = new InventorySlot();
        newSlot.SetIngredient(ingredient);
        inventorySlots.Add(newSlot);
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        // Ensure IngredientDatabase is initialized
        if (IngredientDatabase.Instance == null)
        {
            Debug.LogError("IngredientDatabase.Instance is null. Unable to update UI.");
            return;
        }

        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i] == null)
            {
                Debug.LogError($"Inventory slot at index {i} is null.");
                continue;
            }

            IngredientType ingredientType = inventorySlots[i].GetIngredientType();
            string ingredientName = ingredientType.ToString();  // Convert to string for database
            int quantity = IngredientDatabase.Instance.GetIngredientQuantity(ingredientName);
            inventorySlots[i].SetQuantity(quantity);
        }
    }
}