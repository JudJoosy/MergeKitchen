using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
// [Lopez,Judith]
//

public class CookingManager : MonoBehaviour
{
	public static CookingManager Instance;  // Singleton reference

	public List<RecipeData> recipes; // Assign all recipes in the inspector
	public List<IngredientData> selectedIngredients = new List<IngredientData>(); // ✅ Declare it

	public Transform cookingSlot1, cookingSlot2; // Drag and drop locations for ingredients
    public Transform craftedDishSpawnPoint; // Where the new dish appears
    public GameObject cookingUIPanel; // UI panel for showing crafting

	public Animator cookingAnimator;


	private void Awake()
	{
		// Singleton pattern: ensures only one instance of CookingManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("More than one instance of CookingManager found in the scene!");
        }
	}

    //
    void Start()
    {
        // Ensure that cooking slots are assigned
        if (cookingSlot1 == null || cookingSlot2 == null)
        {
            Debug.LogError("Cooking slots are not assigned in the inspector.");
        }

        // Ensure that craftedDishSpawnPoint is assigned
        if (craftedDishSpawnPoint == null)
        {
            Debug.LogError("Crafted dish spawn point is not assigned in the inspector.");
        }
    }
    //
	//
	public void AddIngredient(IngredientData ingredient)
	{
		// Check if ingredient is null
        if (ingredient == null)
        {
            Debug.LogError("Ingredient is null!");
            return;
        }

        if (selectedIngredients.Count < 2) // Limiting to 2 ingredients for now
        {
            selectedIngredients.Add(ingredient);
            Debug.Log("Added: " + ingredient.ingredientName);
        }
        else
        {
            Debug.Log("Max ingredients reached!");
        }
	}
    //
    //
	public void CookDish()
    {  
      foreach (RecipeData recipe in recipes)
      {
        if (CheckRecipeMatch(recipe))
        {
            Debug.Log("Crafted: " + recipe.dishName);
            cookingAnimator.SetTrigger("Success");
            SpawnCraftedDish(recipe);
            RemoveUsedIngredients();
            return;
        }
      }
      cookingAnimator.SetTrigger("Failure");
      Debug.Log("Invalid combination!");
    }
    //
    //
	public bool CheckRecipeMatch(RecipeData recipe)
	{
		// Check if recipe is null
        if (recipe == null)
        {
            Debug.Log("No recipe found");
            return false;
        }

        // Ensure Ingredients list is not null and has ingredients to check
        if (recipe.Ingredients != null && recipe.Ingredients.Count > 0)
        {
            return true;
        }

        Debug.Log("Recipe has no valid ingredients");
        return false;
	}
    //
    //
	private void SpawnCraftedDish(RecipeData recipe)
	{
		if (craftedDishSpawnPoint != null && recipe.dishModel != null)
        {
            GameObject craftedDish = Instantiate(recipe.dishModel, craftedDishSpawnPoint.position, Quaternion.identity);
            craftedDish.name = recipe.dishName;
        }
        else
        {
            Debug.LogError("Crafted dish spawn point or dish model is null!");
        }
	}
    //
    //
	private void RemoveUsedIngredients()
	{
		// Ensure InventoryManager instance is available
        if (InventoryManager.Instance != null)
        {
            foreach (IngredientData ingredient in selectedIngredients)
            {
                InventoryManager.Instance.RemoveFromInventory(ingredient);
            }
            selectedIngredients.Clear();
        }
        else
        {
            Debug.LogError("InventoryManager instance is null!");
        }
	}
}
