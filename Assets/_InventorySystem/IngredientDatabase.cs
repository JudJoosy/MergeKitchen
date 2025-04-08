using System.Collections.Generic;
using UnityEngine;

public class IngredientDatabase : MonoBehaviour
{
    public static IngredientDatabase Instance;  // Singleton instance
    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    // Initialize the singleton instance
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Add ingredient with quantity to the database
    public void AddIngredient(string ingredientName, int amount)
    {
        if (inventory.ContainsKey(ingredientName))
        {
            inventory[ingredientName] += amount;  // Increase the quantity if it already exists
        }
        else
        {
            inventory[ingredientName] = amount;  // Add new ingredient if it doesn't exist
        }

        Debug.Log($"Added {amount} of {ingredientName}. Current count: {inventory[ingredientName]}");
    }

    // Get the quantity of a specific ingredient
    public int GetIngredientQuantity(string ingredientName)
    {
        if (inventory.ContainsKey(ingredientName))
        {
            return inventory[ingredientName];
        }
        return 0;  // Return 0 if the ingredient doesn't exist
    }

    // Get the inventory (just for illustration)
    public Dictionary<string, int> GetInventory()
    {
        return inventory;
    }
}
