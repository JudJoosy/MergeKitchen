using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
   public string ingredientType;
   private static Ingredient selectedIngredient = null;

   void OnMouseDown()
   {
	   if (selectedIngredient == null)
	   {
		   selectedIngredient = this;
	   }
	   else
	   {
		   TryMergeIngredients(selectedIngredient, this);
		   selectedIngredient = null;
	   }
   }

   void TryMergeIngredients(Ingredient firstIngredient, Ingredient secondIngredient)
   {
	   if (firstIngredient.ingredientType == "Salt" && secondIngredient.ingredientType == "Salt")
	   {
		   MergeToDish("Pepper", firstIngredient, secondIngredient);
	   }
	   else if (firstIngredient.ingredientType == "Salt" && secondIngredient.ingredientType == "Pepper")
	   {
		    MergeToDish("Salt and Pepper Dish", firstIngredient, secondIngredient);
	   }
	   else if (firstIngredient.ingredientType == "Salt" && secondIngredient.ingredientType == "Pepper" && CheckForThyme())
	   {
		   MergeToDish("Fancy Salt and Pepper Dish", firstIngredient, secondIngredient);
	   }
	   else if (firstIngredient.ingredientType == "Garlic" && secondIngredient.ingredientType == "Onion" && CheckForThyme())
	   {
		    MergeToDish("Somewhat Holy Trinity Dish", firstIngredient, secondIngredient);
	   }
	   else if (firstIngredient.ingredientType == "Garlic" && secondIngredient.ingredientType == "Potato" && CheckForSalt())
	   {
		   MergeToDish("Garlic Fries Dish", firstIngredient, secondIngredient);
	   }
   }

   void MergeToDish(string dishType, Ingredient firstIngredient, Ingredient secondIngredient)
   {
	     InstantiateDish(dishType);

		 Destroy(firstIngredient.gameObject);
		 Destroy(secondIngredient.gameObject);
   }

   void InstantiateDish(string dishType)
   {
	   ///
   }

   bool CheckForThyme()
   {
	   return true;
   }

   bool CheckForSalt()
   {
	   return true;
   }

}
