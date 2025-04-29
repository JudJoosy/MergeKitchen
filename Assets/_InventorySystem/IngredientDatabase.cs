using System.Collections.Generic;
using UnityEngine;

public class IngredientDatabase : MonoBehaviour
{
    public static IngredientDatabase Instance;

    // Ingredient database, with ingredient names as keys and quantities as values
    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    private void Awake()
    {
        // Ensure there's only one instance of the IngredientDatabase
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Keep this across scenes if needed
            Debug.Log("IngredientDatabase instance initialized.");
        }
    }

    // Adds an ingredient to the inventory
    public void AddIngredient(string ingredientName, int amount)
    {
        // Validate singleton instance
        if (Instance == null)
        {
            Debug.LogError("IngredientDatabase.Instance is not initialized.");
            return;
        }

        // Validate ingredient name and amount
        if (string.IsNullOrEmpty(ingredientName))
        {
            Debug.LogError("Invalid ingredient name.");
            return;
        }

        if (amount <= 0)
        {
            Debug.LogError("Amount must be greater than zero.");
            return;
        }

        // Add or update the ingredient quantity in the inventory
        if (inventory.ContainsKey(ingredientName))
        {
            inventory[ingredientName] += amount;
        }
        else
        {
            inventory.Add(ingredientName, amount);
        }

        Debug.Log($"Added {amount} of {ingredientName}. Current count: {inventory[ingredientName]}");
    }

    // Retrieves the quantity of a specific ingredient
    public int GetIngredientQuantity(string ingredientName)
    {
        // Validate ingredient name
        if (string.IsNullOrEmpty(ingredientName))
        {
            Debug.LogError("Invalid ingredient name.");
            return 0;
        }

        // Return the quantity if ingredient exists
        if (inventory.ContainsKey(ingredientName))
        {
            return inventory[ingredientName];
        }

        return 0; // Return 0 if ingredient doesn't exist
    }

    // Optionally, you can have a method to check if an ingredient exists
    public bool IngredientExists(string ingredientName)
    {
        return inventory.ContainsKey(ingredientName);
    }
}