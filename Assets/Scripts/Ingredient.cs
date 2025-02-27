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

	 private Color normalColor;
	 private Color glowColor = Color.yellow;

	 private Renderer ingredientRenderer;

	 void OnMouseDown()  // Detects tap or click on the ingredient
	 {
		 if (selectedIngredients.Contains(this))
		 {
			 selectedIngredients.Remove(this);
			 IngredientSelectionManager.Instance.DeselectIngredient(this);
			 
			 ApplyGlowEffect(false);
		 }
		 else
		 {
			 selectedIngredients.Add(this); 
			 IngredientSelectionManager.Instance.SelectIngredient(this);
			
			 ApplyGlowEffect(true);
		 }

		 List<Ingredient> selected = IngredientSelectionManager.Instance.GetSelectedIngredients();

		 if (selected.Count >= 2)  // Try merging when two or more are selected
		 {
			 TryMerge();
		 }

		 Debug.Log("Clicked on ingredient: " + ingredientType); // Log ingredient name
		 Debug.Log("Selected ingredients: " + string.Join(", ", selectedIngredients.Select(i => i.ingredientType))); // Log all selected ingredients

		 void ApplyGlowEffect(bool isSelected)
		 {
			 if (ingredientRenderer == null)
			 {
				 Debug.LogWarning("Ingredient does not have a Renderer component, skipping glow effect.");
				 return;
			 }

			 if (isSelected)
			 {
				 ingredientRenderer.material.color = glowColor;
				 LeanTween.scale(gameObject, Vector3.one * 1.2f, 0.1f).setEaseOutBack();
			 }
			 else
			 {
				 ingredientRenderer.material.color = normalColor;
				 LeanTween.scale(gameObject, Vector3.one, 0.1f).setEaseInBack();
			 }
		 }

		 // visual effect for selection
		 LeanTween.scale(gameObject, Vector3.one * 1.2f, 0.1f).setEaseOutBack().setOnComplete(() =>
		 {
			 LeanTween.scale(gameObject, Vector3.one, 0.1f).setEaseInBack();
		 });
	 }

	 void ChangeColor(Color color)
	 {
		 LeanTween.color(gameObject, color, 0.3f); // Change color with smooth animation
	 }

	 void EnableGlow(bool enable)
	 {
		 if (enable)
		 {
			 LeanTween.color(gameObject, Color.yellow, 0.5f).setLoopPingPong(); // Pulsing glow effect
		 }
		 else
		 {
			LeanTween.color(gameObject, normalColor, 0.3f); // Reset color to normal
		 }
	 }

	 void TryMerge()
	 {
	    List<Ingredient> selected = IngredientSelectionManager.Instance.GetSelectedIngredients();

		foreach (var recipe in mergeRecipes)
		{
			if (MatchesRecipe(selected, recipe.Value))
			{
				MergeIngredients(recipe.Key, selected);
				return;
			}
		}

		ResetSelection();
	 }

	 bool MatchesRecipe(List<Ingredient> selected, string[] requiredIngredients)
	 {
		if (selected.Count != requiredIngredients.Length) return false;

		HashSet<string> selectedTypes = new HashSet<string>(selected.Select(i => i.ingredientType));
		HashSet<string> recipeTypes = new HashSet<string>(requiredIngredients);

		return selectedTypes.SetEquals(recipeTypes);
	 }

	 //merging mechanic 
	 void MergeIngredients(string newDishType, List<Ingredient> selected)
	 {
		 if (selected.Count == 0) return; // Prevent errors

		 // calculate the spawn position (average of selected ingredients)
		 Vector3 spawnPosition = Vector3.zero;
		 foreach (Ingredient ingredient in selected)
		 {
			 spawnPosition += ingredient.transform.position;
		 }
		 spawnPosition /= selected.Count;

		 Debug.Log("Calculated spawn position: " + spawnPosition);  // Debug log for spawn position

		 GameObject dishPrefab = Resources.Load<GameObject>("Dishes/" + newDishType);
		 if (dishPrefab == null)
		 {
			 Debug.LogError("Dish not found in Resources: " + newDishType);
			 return;
		 }

		 GameObject newDish = Instantiate(dishPrefab, spawnPosition, Quaternion.identity);

		 newDish.transform.SetParent(null);

         DishManager dishManager = FindObjectOfType<DishManager>();
		 if (dishManager != null)
		 {
			 dishManager.MakeDishDisappear(newDish);
		 }

		 Debug.Log("✅ Spawning dish: " + newDishType);

		 PlayerStats.Instance.AddCurrency(50);

		 foreach (Ingredient ingredient in selected)
		 {
			 Destroy(ingredient.gameObject);
		 }

		 IngredientSelectionManager.Instance.ResetSelection();

		
	 }

	 public void ResetSelection()
	 {
		 selectedIngredients.Clear();
	 }

	 IEnumerator ShrinkAndDestroy(GameObject dish, float duration)
	 {
		 Debug.Log("Shrinking and destroying dish...");  // Debug log to check if coroutine starts
		 Vector3 originalScale = dish.transform.localScale;
		 float elapsed = 0f;

		 // Ensure the dish isn't already too small or scaled incorrectly
		 if (dish == null)
		 {
			 yield break;
		 }

		 while (elapsed < duration)
		 {
			 float scale = Mathf.Lerp(1f, 0f, elapsed / duration);
             dish.transform.localScale = originalScale * scale;
             elapsed += Time.deltaTime;
             yield return null;
		 }

		 Destroy(dish);
	 }			
}
