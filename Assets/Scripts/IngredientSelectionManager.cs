using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSelectionManager : MonoBehaviour
{
	public static IngredientSelectionManager Instance;
	private List<Ingredient> selectedIngredients = new List<Ingredient>();

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}

	public void SelectIngredient(Ingredient ingredient)
	{
		if (!selectedIngredients.Contains(ingredient))
		{
			selectedIngredients.Add(ingredient);
		}
	}

	public List<Ingredient> GetSelectedIngredients()
	{
		return selectedIngredients;
	}

	public void ResetSelection()
	{
		selectedIngredients.Clear();
	}

}
