using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientClick : MonoBehaviour
{
	public IngredientData ingredientData;

    private void OnMouseDown()
    {
        CookingManager.Instance.AddIngredient(ingredientData);
        MoveToCookingSlot();
    }

    private void MoveToCookingSlot()
    {
        if (CookingManager.Instance.selectedIngredients.Count == 1)
        {
            transform.position = CookingManager.Instance.cookingSlot1.position;
        }
        else if (CookingManager.Instance.selectedIngredients.Count == 2)
        {
            transform.position = CookingManager.Instance.cookingSlot2.position;
        }
    }
}
