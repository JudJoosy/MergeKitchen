using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSelectionManager : MonoBehaviour
{
	public static IngredientSelectionManager _instance;
	public static IngredientSelectionManager Instance { get { return _instance; } }

	private List<Ingredient> selectedIngredients = new List<Ingredient>();  // Stores currently selected ingredients


    void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public void SelectIngredient(Ingredient ingredient)
	{
		if (!selectedIngredients.Contains(ingredient))
		{
			selectedIngredients.Add(ingredient);
		}
	}

	public void DeselectIngredient(Ingredient ingredient)
	{
		if (selectedIngredients.Contains(ingredient))
		{
			selectedIngredients.Remove(ingredient);
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
