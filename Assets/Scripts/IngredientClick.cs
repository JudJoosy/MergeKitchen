using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientClick : MonoBehaviour
{
	public Transform cookingBox; // Assign the cooking box location in Inspector

	private bool isPlaced = false;

	private void OnMouseDown() // Detect touch or click
	{
		if (!isPlaced)
		{
			transform.position = cookingBox.position; // move to the cooking box
			isPlaced = true;
			CookingManager.Instance.AddIngredient(gameObject.name);
		}
	}
}
