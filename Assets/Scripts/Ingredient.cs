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
		  { "Pepper.prefab", new string[] { "Salt", "Salt" } },
		  { "Salt and pepper.prefab", new string[] { "Salt", "Pepper" } },
		  { "Fancy Salt and pepper.prefab", new string[] { "Salt", "Pepper", "Thyme" } },
		  { "The holy trinity.prefab", new string[] { "Garlic_Prop", "Onion_Prop", "Thyme" } },
		  { "Garlic fries.prefab", new string[] { "Garlic_Prop", "Potato_Prop", "Salt" } }
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
		 Vector3 spawnPosition = Vector3.zero;
		 foreach (Ingredient ingredient in selectedIngredients)
		 {
			 spawnPosition += ingredient.transform.position;
		 }
		 spawnPosition /= selectedIngredients.Count;

		 GameObject newDish = Instantiate(Resources.Load<GameObject>("Dishes_Models/" + newDishType), spawnPosition, Quaternion.identity);

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
