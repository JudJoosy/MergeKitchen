using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    [Header("Dish Recipes (Scriptable Objects)")]
    [Tooltip("Assign DishDataSO ScriptableObjects here")]
    public List<DishDataSO> recipes = new List<DishDataSO>();

    /// <summary>
    /// Attempts to make a dish from the given list of ingredient names.
    /// Iterates through the assigned DishDataSO recipes to find a matching set of ingredients.
    /// Returns the instantiated dish GameObject if a match is found; otherwise returns null.
    /// </summary>
    public GameObject TryMakeDish(List<string> inputIngredients)
    {
        if (inputIngredients == null || inputIngredients.Count == 0)
        {
            Debug.LogWarning("Input ingredient list is empty or null.");
            return null;
        }

        // Check each recipe (DishDataSO) for a matching ingredients list
        foreach (DishDataSO dishData in recipes)
        {
            if (dishData == null) continue;
            // Compare ingredients ignoring order
            if (IngredientsMatch(inputIngredients, dishData.requiredIngredients))
            {
                // If there's a matching recipe, instantiate its dishPrefab
                if (dishData.dishPrefab != null)
                {
                    return Instantiate(dishData.dishPrefab);
                }
                else
                {
                    Debug.LogWarning($"DishDataSO '{dishData.name}' has no dishPrefab assigned.");
                }
            }
        }

        // No matching recipe found
        return null;
    }

    /// <summary>
    /// Compares two lists of ingredient names, ignoring order.
    /// Returns true if they contain the exact same elements.
    /// </summary>
    private bool IngredientsMatch(List<string> input, List<string> required)
    {
        if (input == null || required == null)
            return false;
        if (input.Count != required.Count)
            return false;

        // Make a copy of the input list so we can remove items
        List<string> remaining = new List<string>(input);

        // Try to match every required ingredient
        foreach (string ingredient in required)
        {
            if (remaining.Contains(ingredient))
            {
                remaining.Remove(ingredient);
            }
            else
            {
                // Missing a required ingredient
                return false;
            }
        }

        // If all required ingredients were found, no extras should remain
        return remaining.Count == 0;
    }
}
