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
    public static RecipeManager Instance { get; private set; }

    public List<Recipe> recipes = new List<Recipe>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public string TryMakeDish(List<string> currentIngredients)
    {
        foreach (var recipe in recipes)
        {
            if (AreIngredientsMatching(recipe.requiredIngredients, currentIngredients))
            {
                return recipe.dishName;
            }
        }
        return null;
    }

    private bool AreIngredientsMatching(List<string> required, List<string> current)
    {
        var requiredSet = new HashSet<string>(required);
        var currentSet = new HashSet<string>(current);
        return requiredSet.SetEquals(currentSet);
    }
}