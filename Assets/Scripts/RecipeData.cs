using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RecipeData 
{
   public string dishName;
   public IngredientData[] requiredIngredients; // Ingredients needed to craft the dish
   public GameObject dishModel; // 3D Model for the crafted dish
   public Sprite dishIcon; // UI representation

   public string recipeName; // The name of the dish
   public List<IngredientData> ingredients; // ✅ Declare the ingredients list

   public List<IngredientData> Ingredients { get; set; }

   public RecipeData()
   {
	   ingredients = new List<IngredientData>(); // ✅ Initialize the list
   }
}
