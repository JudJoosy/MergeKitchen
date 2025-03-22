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
		if (Instance == null)
		{
			Instance = this;
		}
	}

	
	public void AddIngredient(IngredientData ingredient)
	{
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


	public bool CheckRecipeMatch(RecipeData recipe)
	{
		if (recipe == null)
        {
          Debug.Log("No recipe found");
          return false; // ✅ Always return something
        }

        if (recipe.Ingredients.Count > 0)
        {
           return true;
        }

        return false; // ✅ Default return value
	}


	private void SpawnCraftedDish(RecipeData recipe)
	{
		GameObject craftedDish = Instantiate(recipe.dishModel, craftedDishSpawnPoint.position, Quaternion.identity);
        craftedDish.name = recipe.dishName;
	}


	private void RemoveUsedIngredients()
	{
		foreach (IngredientData ingredient in selectedIngredients)
        {
          InventoryManager.Instance.RemoveFromInventory(ingredient);
        }
        selectedIngredients.Clear();
	}
}
