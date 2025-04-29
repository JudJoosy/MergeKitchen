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
            // Debugging the ingredients before merging
            Debug.Log("Merging " + ingredient1.ingredientName + " (Quantity: " + ingredient1.quantity + ") with " + ingredient2.ingredientName + " (Quantity: " + ingredient2.quantity + ")");

            // Check if ingredients are the same
            if (ingredient1.ingredientName == ingredient2.ingredientName)
            {
                // Combine the quantities
                ingredient1.quantity += ingredient2.quantity;

                // Destroy the second ingredient after merging
                Destroy(ingredient2.gameObject);

                // Optionally, create a new merged ingredient
                Ingredient mergedIngredient = CreateMergedIngredient(ingredient1);

                // You can spawn it in the world or add it to the inventory as needed
                SpawnMergedIngredient(mergedIngredient);

                // Play merge sound
                if (mergeSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(mergeSound);
                }
            }
            else
            {
                Debug.LogError("Ingredients are not the same, cannot merge.");
            }
        }
        else
        {
            Debug.LogError("One or both ingredients are null.");
        }
    }

    // Create a new merged ingredient
    Ingredient CreateMergedIngredient(Ingredient ingredient)
    {
        // Instead of using "new" keyword, instantiate a new Ingredient from a prefab
        GameObject mergedObject = Instantiate(ingredient.gameObject);  // Instantiate the original ingredient as the base for merged ingredient
        Ingredient mergedIngredient = mergedObject.GetComponent<Ingredient>();  // Get the Ingredient component of the new object

        // Modify the ingredient properties
        mergedIngredient.ingredientName = ingredient.ingredientName + "_merged";  // Example of the merged name
        mergedIngredient.quantity = 1;  // New merged ingredient starts with a quantity of 1
        mergedIngredient.gameObject.SetActive(true);  // Ensure it's active in the scene

        return mergedIngredient;
    }

    // Optionally spawn the merged ingredient in the world (or in an inventory, etc.)
    void SpawnMergedIngredient(Ingredient mergedIngredient)
    {
        // Add your logic here to position the merged ingredient or add it to the inventory
        Debug.Log("Merged ingredient created: " + mergedIngredient.ingredientName + " with quantity: " + mergedIngredient.quantity);

        // Example: Add the new merged ingredient to the inventory
        inventoryManager.AddIngredientToInventory(mergedIngredient);
    }
}