using UnityEngine;
using System.Collections.Generic;

public class IngredientDatabase : MonoBehaviour
{
    public static IngredientDatabase Instance { get; private set; }

    private Dictionary<string, int> ingredientCounts = new Dictionary<string, int>();

    void Awake()
    {
        // If no instance exists, set this one as the instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep it between scenes
            Debug.Log("IngredientDatabase Singleton Initialized");
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }

    // Function to get the current inventory
    public Dictionary<string, int> GetInventory()
    {
        return ingredientCounts;
    }

    // Function to add ingredients to the inventory
    public void AddIngredient(string ingredientName)
    {
        if (ingredientCounts.ContainsKey(ingredientName))
        {
            ingredientCounts[ingredientName]++;
        }
        else
        {
            ingredientCounts.Add(ingredientName, 1);
        }
    }

    // Function to remove ingredients from the inventory
    public void RemoveIngredient(string ingredientName)
    {
        if (ingredientCounts.ContainsKey(ingredientName) && ingredientCounts[ingredientName] > 0)
        {
            ingredientCounts[ingredientName]--;
        }
    }
}
