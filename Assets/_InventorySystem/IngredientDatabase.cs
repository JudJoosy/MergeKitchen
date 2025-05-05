using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class IngredientDatabase : MonoBehaviour
{
    public static IngredientDatabase Instance;

    public List<IngredientData> availableIngredients = new List<IngredientData>()
    {
        new IngredientData { name = "Salt",  cost = 10 },
        new IngredientData { name = "Pepper", cost = 25 },
        new IngredientData { name = "Thyme", cost = 60 },
        new IngredientData { name = "Onion", cost = 125 },
        new IngredientData { name = "Garlic", cost = 175 },
        new IngredientData { name = "Potato", cost = 500 },
        new IngredientData { name = "Milk", cost = 1250 },
        new IngredientData { name = "Butter", cost = 2500 },
        new IngredientData { name = "Dough", cost = 5000 },
        new IngredientData { name = "Bread", cost = 10000 }
    };

    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("IngredientDatabase instance initialized.");
        }
    }

    public IngredientData GetIngredientByName(string name)
    {
        return availableIngredients.FirstOrDefault(i => i.name == name);
    }

    public void AddIngredient(string ingredientName, int amount)
    {
        if (Instance == null)
        {
            Debug.LogError("IngredientDatabase.Instance is not initialized.");
            return;
        }

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

    public int GetIngredientQuantity(string ingredientName)
    {
        if (string.IsNullOrEmpty(ingredientName))
        {
            Debug.LogError("Invalid ingredient name.");
            return 0;
        }

        return inventory.TryGetValue(ingredientName, out int quantity) ? quantity : 0;
    }

    public bool IngredientExists(string ingredientName)
    {
        return inventory.ContainsKey(ingredientName);
    }
}