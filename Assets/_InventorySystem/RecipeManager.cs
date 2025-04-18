using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance;

    public List<Recipe> recipes;
    public Transform dishSpawnPoint;

    private void Awake()
    {
        Instance = this;
    }

    // 💡 Add this Start method for testing!
    void Start()
    {
        TryMakeDish(new List<string> { "Pepper", "Salt" });   // Should match Salt and Pepper Dish
        TryMakeDish(new List<string> { "Salt", "Garlic" });   // Should return no match
    }

    public void TryMakeDish(List<string> inputIngredients)
    {
        inputIngredients.Sort();

        foreach (var recipe in recipes)
        {
            var sortedRecipe = new List<string>(recipe.ingredientNames);
            sortedRecipe.Sort();

            if (IsMatch(inputIngredients, sortedRecipe))
            {
                Debug.Log("Dish created: " + recipe.dishName);
                Instantiate(recipe.dishPrefab, dishSpawnPoint.position, Quaternion.identity);
                return;
            }
        }

        Debug.Log("No matching recipe found.");
    }

    private bool IsMatch(List<string> input, List<string> recipe)
    {
        if (input.Count != recipe.Count)
            return false;

        for (int i = 0; i < input.Count; i++)
        {
            if (input[i] != recipe[i])
                return false;
        }

        return true;
    }
}