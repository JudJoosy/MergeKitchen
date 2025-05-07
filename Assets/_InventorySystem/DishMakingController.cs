using System.Collections.Generic;
using UnityEngine;

public class DishMakingController : MonoBehaviour
{
    public RecipeManager recipeManager;
    public DishManager dishManager;
    public InventoryManager inventoryManager; // <-- Added reference

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
                if (!inventoryManager.HasIngredient(ing.displayName))
                {
                    Debug.LogWarning($"Not enough {ing.displayName} to make this dish.");
                    return; // Exit early if any ingredient is missing
                }

                ingredientNames.Add(ing.displayName);
                ingredientScripts.Add(ing);
            }
        }

        var dish = recipeManager.TryMakeDish(ingredientNames);

        if (dish != null)
        {
            Debug.Log($"Successfully made: {dish.dishName}");
            dishManager.MakeDish(ingredientScripts.ToArray());

            // Reduce ingredient quantities from inventory
            foreach (var ing in ingredientScripts)
            {
                inventoryManager.ReduceIngredientQuantity(ing.displayName, 1);
            }
        }
        else
        {
            Debug.Log("No matching recipe found.");
        }
    }
}