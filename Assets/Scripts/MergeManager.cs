using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
  public InventoryManager inventoryManager;  // Reference to Inventory Manager
  public AudioSource audioSource;  
  public AudioClip mergeSound;

  // Merge two identical ingredients
  public void MergeIngredients(Ingredient ingredient1, Ingredient ingredient2)
  {
	 if (ingredient1 != null && ingredient2 != null)
	 {
		 // Accessing the ingredientName from the Ingredient objects
		  Debug.Log("Merging " + ingredient1.ingredientName + " (Quantity: " + ingredient1.quantity + ") with " + ingredient2.ingredientName + " (Quantity: " + ingredient2.quantity + ")");
	 }
	 else
	 {
		  Debug.LogError("One or both ingredients are null.");
	 }

	 if (mergeSound != null && audioSource != null)
	 {
		 audioSource.PlayOneShot(mergeSound);
	 }
  }

  // Create a new merged ingredient
  Ingredient CreateMergedIngredient(Ingredient ingredient)
  {
	  Ingredient newIngredient = new Ingredient
	  {
		ingredientName = ingredient.ingredientName + "_merged",  // Example of the merged name
		ingredientModel = ingredient.ingredientModel,  // Using the same model
		quantity = 1  // New ingredient starts with a quantity of 1
      };
	 return newIngredient;
  }
}
