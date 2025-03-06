using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSelectionManager : MonoBehaviour
{
	 public static IngredientSelectionManager instance { get; private set; }

	 private List<Ingredient> selectedIngredients = new List<Ingredient>();  // Stores currently selected ingredients

	 void Awake()
	 {
		 if (instance != null && instance != this)
		 {
			Destroy(gameObject);
		 }
		 else
		 {
			 instance = this;
			 DontDestroyOnLoad(gameObject);
		 }
	 }

	 public void SelectIngredient(Ingredient ingredient)
	 {
		 if (!selectedIngredients.Contains(ingredient))
		 {
			 selectedIngredients.Add(ingredient);

			 // Optional: Prevent selecting more than 2 ingredients
			 if (selectedIngredients.Count > 2)
			 {
				 selectedIngredients.RemoveAt(0); // Remove the oldest selection
			 }
		 }
	 }

	 public void DeselectIngredient(Ingredient ingredient)
	 {
		 selectedIngredients.Remove(ingredient);
	 }

	 public List<Ingredient> GetSelectedIngredients()
	 {
		 return new List<Ingredient>(selectedIngredients); // Return a copy to prevent external modifications
	 }

	 public void ResetSelection()
	 {
		 selectedIngredients.Clear();
	 }

}
