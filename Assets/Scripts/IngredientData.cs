using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewIngredient", menuName = "Cooking/Ingredient")]
public class IngredientData : ScriptableObject
{
   public string ingredientName; // ✅ Add this if missing

   // Other properties
   public int quantity;
   public GameObject ingredientModel;
}
