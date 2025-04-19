using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{
    public string dishName;
    public List<string> requiredIngredients;
}

public class RecipeManager : MonoBehaviour
{
    public List<Recipe> recipes;

    // Matches ingredients regardless of order
    public string TryMakeDish(List<string> currentIngredients)
    {
        foreach (Recipe recipe in recipes)
        {
            if (MatchIngredients(currentIngredients, recipe.requiredIngredients))
            {
                return recipe.dishName;
            }
        }
        return null;
    }

    private bool MatchIngredients(List<string> current, List<string> required)
    {
        if (current.Count != required.Count) return false;

        var currentCopy = new List<string>(current);
        foreach (string ingredient in required)
        {
            if (!currentCopy.Remove(ingredient))
            {
                return false;
            }
        }
        return true;
    }
}