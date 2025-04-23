using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    [System.Serializable]
    public class Recipe
    {
        public List<string> requiredIngredients;
        public CookingSlotManager.DishData dishData;

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

    public CookingSlotManager.DishData TryMakeDish(List<string> ingredients)
    {
        foreach (Recipe recipe in recipes)
        {
            if (recipe.Matches(ingredients))
            {
                return recipe.dishData;
            }
        }

        return null;
    }
}