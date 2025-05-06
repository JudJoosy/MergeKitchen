using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    [System.Serializable]
    public class Recipe
    {
        public List<string> requiredIngredients;
        public DishDataSO dishData;

        // Check if the recipe matches the given ingredients
        public bool Matches(List<string> ingredients)
        {
            if (ingredients.Count != requiredIngredients.Count)
                return false;

            List<string> requiredCopy = new List<string>(requiredIngredients);

            foreach (string ing in ingredients)
            {
                if (!requiredCopy.Remove(ing))
                    return false;
            }

            return requiredCopy.Count == 0;
        }
    }

    public List<Recipe> recipes;

    // Attempt to make a dish from the provided ingredients
    public DishDataSO TryMakeDish(List<string> ingredients)
    {
        foreach (Recipe recipe in recipes)
        {
            if (recipe.Matches(ingredients))
            {
                return recipe.dishData;  // Return dish data if the recipe matches
            }
        }

        return null;  // Return null if no match is found
    }
}