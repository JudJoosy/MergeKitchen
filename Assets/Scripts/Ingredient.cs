using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems; 

public class Ingredient : MonoBehaviour
{
	 public string ingredientType;  // Name of the ingredient
	 private static List<Ingredient> selectedIngredients = new List<Ingredient>(); // Stores tapped ingredients
	 private static Dictionary<string, string[]> mergeRecipes = new Dictionary<string, string[]>()
	 {
		  { "Salt and pepper", new string[] { "Salt", "Pepper" } },
		  { "Fancy Salt and pepper", new string[] { "Salt", "Pepper", "Thyme" } },
		  { "The holy trinity", new string[] { "Garlic_Prop", "Onion_Prop", "Thyme" } },
		  { "Garlic fries", new string[] { "Garlic_Prop", "Potato_Prop", "Salt" } }
	 };

	 void OnMouseDown()  // Detects tap or click on the ingredient
	 {
		 if (!selectedIngredients.Contains(this))
		 {
			 selectedIngredients.Add(this);
		 }

		 if (selectedIngredients.Count >= 2)  // Try merging when two or more are selected
		 {
			 TryMerge();
		 }

		 Debug.Log("Clicked on ingredient: " + ingredientType); // Log ingredient name
		 if (!selectedIngredients.Contains(this))
		 {
			 selectedIngredients.Add(this);
		 }

		 Debug.Log("Selected ingredients: " + string.Join(", ", selectedIngredients.Select(i => i.ingredientType))); // Log all selected ingredients

		  LeanTween.scale(gameObject, Vector3.one * 1.2f, 0.1f).setEaseOutBack().setOnComplete(() =>
		  {
			  LeanTween.scale(gameObject, Vector3.one, 0.1f).setEaseInBack();
		  });

		 if (selectedIngredients.Count >= 2)  // Try merging when two or more are selected
		 {
			 TryMerge();
		 }
	 }

	 void TryMerge()
	 {
		foreach (var recipe in mergeRecipes)
		{
			if (MatchesRecipe(recipe.Value))
			{
				MergeIngredients(recipe.Key);
				return;
			}
		}

		ResetSelection();
	 }

	 bool MatchesRecipe(string[] requiredIngredients)
	 {
		 if (selectedIngredients.Count != requiredIngredients.Length) return false;
		 List<string> selectedTypes = new List<string>();
		 foreach (Ingredient ingredient in selectedIngredients)
		 {
			 selectedTypes.Add(ingredient.ingredientType);
		 }

		 selectedTypes.Sort();
		 List<string> sortedRecipe = new List<string>(requiredIngredients);
		 sortedRecipe.Sort();


		 return selectedTypes.SequenceEqual(sortedRecipe);
	 }

	 void MergeIngredients(string newDishType)
	 {
		 if (selectedIngredients.Count == 0) return; // Prevent errors

		 Vector3 spawnPosition = Vector3.zero;
		 foreach (Ingredient ingredient in selectedIngredients)
		 {
			 spawnPosition += ingredient.transform.position;
		 }
		 spawnPosition /= selectedIngredients.Count;

		 GameObject dishPrefab = Resources.Load<GameObject>("Dishes/" + newDishType);
		 if (dishPrefab == null)
		 {
			 Debug.LogError("Dish not found in Resources: " + newDishType);
			 return;
		 }

		 Debug.Log("✅ Spawning dish: " + newDishType);

		 GameObject newDish = Instantiate(dishPrefab, spawnPosition, Quaternion.identity);

		 List<Ingredient> ingredientsToDestroy = new List<Ingredient>(selectedIngredients);

		 selectedIngredients.Clear();

		 foreach (Ingredient ingredient in selectedIngredients)
		 {
			 Destroy(ingredient.gameObject);
		 }

		 selectedIngredients.Clear();
	 }

	 void ResetSelection()
	 {
		 selectedIngredients.Clear();
	 }
}
