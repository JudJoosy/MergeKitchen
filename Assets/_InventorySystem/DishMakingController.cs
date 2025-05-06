using System.Collections.Generic;
using UnityEngine;

public class DishMakingController : MonoBehaviour
{
    public RecipeManager recipeManager;
    public DishManager dishManager;

    // Call this method from UI button or gameplay logic
    public void MakeDish(List<GameObject> selectedIngredientObjects)
    {
        List<string> ingredientNames = new List<string>();
        List<Ingredient> ingredientScripts = new List<Ingredient>();

        foreach (GameObject obj in selectedIngredientObjects)
        {
            Ingredient ing = obj.GetComponent<Ingredient>();
            if (ing != null)
            {
                ingredientNames.Add(ing.displayName);
                ingredientScripts.Add(ing);
            }
        }

        var dish = recipeManager.TryMakeDish(ingredientNames);

        if (dish != null)
        {
            Debug.Log($"Successfully made: {dish.dishName}");
            dishManager.MakeDish(ingredientScripts.ToArray());
        }
        else
        {
            Debug.Log("No matching recipe found.");
        }
    }
}
