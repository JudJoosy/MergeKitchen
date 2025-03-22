using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
   public Ingredient storedIngredient;

   public GameObject slotModel;  // Visual representation of the slot (optional)
   public Ingredient ingredient;  // Reference to the Ingredient component

   void Start()
   {
	   if (ingredient != null)
	   {
		   // Access the ingredient model in the Ingredient class
		   GameObject model = ingredient.ingredientModel;

		   if (model != null)
		   {
			   // Do something with the model (e.g., instantiate it in the inventory slot)
			   Instantiate(model, transform.position, Quaternion.identity);
		   }
		   else
		   {
			   Debug.LogError("Ingredient model not assigned.");
		   }
	   }
   }

   public void SetIngredient(Ingredient ingredient)
   {
	   storedIngredient = ingredient;
   }
}
